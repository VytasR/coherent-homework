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

        // Returns a set of tuples (employee name, average vacation length).
        public IEnumerable<(string, double)> AverageVacationLengthPerEmployee()
        {   
            return _vacations.GroupBy(vacation => vacation.EmployeeName, vacation => vacation.GetLength()).
                              Select(group => (group.Key, group.Average())).OrderBy(item => item.Item2).ToList();
        }

        // Returns a set of tuples "number of the month of the year - the number of employees on vacation this month".
        // It is considered that an employee was on vacation in a certain month if he spent 1 or more days on vacation that month.
        public IEnumerable<(int, int)> MonthsEmployeesOnVacation()
        {            
            var vacationMonthsByEmployee = _vacations.GroupBy(vacation => vacation.EmployeeName, vacation => new HashSet<int>() { vacation.FirstDay.Month, vacation.LastDay.Month }).
                Select(group => (group.Key, group.Aggregate((x,y) => AddTwoHashSets(x, y))));           
            var months = Enumerable.Range(1, 12).ToList();             
            var result = new List<(int, int)>();

            foreach (var month in months)
            {
                int numberOfEmployees = 0;
                foreach (var item in vacationMonthsByEmployee)
                {
                    if (item.Item2.Contains(month))
                    {
                        numberOfEmployees++;
                    }                    
                }
                result.Add((month, numberOfEmployees));
            }           

            return result;
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

        // Returns a set of pairs of vacation records in which the names of the employee are the same, and the dates of two holidays overlap.
        public IEnumerable<(Vacation, Vacation)> GetOverlappingVacationEntries()
        {            
            var result = new List<(Vacation, Vacation)>();

            var vacationGroupsByEmployeeName = from vacation in _vacations
                                               group vacation by vacation.EmployeeName into employeeVacations
                                               orderby employeeVacations.Key
                                               select new { employeeVacations.Key, employeeVacations };

            foreach (var group in vacationGroupsByEmployeeName)
            {
                foreach (var vacation in group.employeeVacations)
                {
                    var firstDay = vacation.FirstDay;
                    var lastDay = vacation.LastDay;

                    foreach (var vacationToCompare in group.employeeVacations)
                    {
                        if (vacation != vacationToCompare && !result.Contains((vacation, vacationToCompare)) &&
                           (vacationToCompare.FirstDay >= firstDay && vacationToCompare.FirstDay <= lastDay ||
                            vacationToCompare.LastDay >= firstDay && vacationToCompare.LastDay <= lastDay))
                        {
                            result.Add((vacationToCompare, vacation));
                        }                        
                    }
                }
            }

            return result;
        }

        // Inputs two hashsets. Returns a union.

        private HashSet<int> AddTwoHashSets(HashSet<int> firstSet, HashSet<int> secondSet)
        {
            foreach (var item in secondSet)
            {
                firstSet.Add(item);
            }
            return firstSet;
        }
    }
}
