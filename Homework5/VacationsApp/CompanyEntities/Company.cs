using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationsApp.CompanyEntities
{
    internal class Company
    {
        // This class simulates a company with a list of employee vacations.

        private List<Vacation> _vacations;

        public Company()
        {
            _vacations = new List<Vacation>();
        }

        public void AddVacation(Vacation newVacation)
        {
            _vacations.Add(newVacation);
        }

        // Returns average length of vacation in the organization.
        public double AverageVacationLength()
        {
            return  _vacations.Average(vacation => vacation.GetLength());            
        }

        // Returns a list of tuples (employee name, average vacation length), sorted by vacation length.
        public IEnumerable<(string, double)> AverageVacationLengthPerEmployee()
        {   
            return _vacations.GroupBy(vacation => vacation.EmployeeName, vacation => vacation.GetLength()).
                              Select(group => (group.Key, group.Average())).OrderBy(item => item.Item2).ToList();
        }

        // Returns a list of tuples "number of the month of the year - the number of employees on vacation this month".
        // It is considered that an employee was on vacation in a certain month if he spent 1 or more days on vacation that month.
        public IEnumerable<(int, int)> MonthsEmployeesOnVacation()
        {
            var employeeVacationMonths = new HashSet<(string, int)>();
            foreach (var vacation in _vacations)
            {
                for (var month = vacation.FirstDay.Month; month <= vacation.LastDay.Month; month++)
                {
                    employeeVacationMonths.Add((vacation.EmployeeName, month));
                }               
            }   

            var monthsNumberOfEmployees = employeeVacationMonths.GroupBy(entry => entry.Item2).Select(group => (group.Key, group.Count()));
            var months = Enumerable.Range(1, 12); 
            var result = from month in months
                         join monthEmployees in monthsNumberOfEmployees
                         on month equals monthEmployees.Key into leftJoin
                         from entry in leftJoin.DefaultIfEmpty()
                         select (month, entry.Item2);

            return result.ToList();
        }

        // Outputs a list of days in year 2021 on which employees did not take vacations.
        public IEnumerable<DateTime> DatesWithoutVacations2021()
        {
            var firstDay = new DateTime(2021, 1, 1);
            var lastDay = new DateTime(2021, 12, 31);
            var result = Enumerable.Range(0, 1 + (lastDay - firstDay).Days).Select(offset => firstDay.AddDays(offset));

            foreach (var vacation in _vacations)
            {                
                result = result.Except(Enumerable.Range(0, 1 + (vacation.LastDay - vacation.FirstDay).Days).
                                                  Select(offset => vacation.FirstDay.AddDays(offset)));                     
            }
            
            return result.ToList();
        }

        // Returns a list of pairs of vacation records in which the names of the employee are the same
        // and the dates of two holidays overlap, sorted by employee name.        
        public IEnumerable<(Vacation, Vacation)> OverlappingVacationEntries()
        {
            var overlappingEntries = from vacation in _vacations
                                     from vacationToCompare in _vacations
                                     where vacation != vacationToCompare &&
                                     vacation.EmployeeName == vacationToCompare.EmployeeName &&
                                     vacationToCompare.FirstDay <= vacation.LastDay &&
                                     vacationToCompare.LastDay >= vacation.FirstDay
                                     orderby vacation.EmployeeName
                                     select (vacation, vacationToCompare);
                    
            var result = new List<(Vacation, Vacation)>();       
            
            foreach (var vacationPair in overlappingEntries) 
            {
                if (!result.Contains((vacationPair.vacationToCompare, vacationPair.vacation)))
                {
                    result.Add(vacationPair);
                }
            }           

            return result;            
        }
    }
}
