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
        public double GetAverageVacationLength()
        {
            return  _vacations.Average(x => x.GetLength());            
        }

        // Returns a set of tuples (employee name, average vacation length).
        public IEnumerable<(string, double)> GetAverageVacationLengthPerEmployee()
        {
            var vacationGroupsByEmployeeName = from vacation in _vacations
                                               group vacation.GetLength() by vacation.EmployeeName into vacationLengths                                               
                                               select new { vacationLengths.Key, vacationLengths };
            
            return vacationGroupsByEmployeeName.
                    Select(group => (group.Key, group.vacationLengths.Average())).OrderBy(group => group.Item2).ToList();            
        }

        // Returns a set of tuples "number of the month of the year - the number of employees on vacation this month".
        // It is considered that an employee was on vacation in a certain month if he spent 1 or more days on vacation that month.
        public IEnumerable<(int, int)> GetMonthsEmployeesOnVacation()
        {
            var vacationMonthsByEmployeeName = from vacation in _vacations
                                               group (vacation.FirstDay.Month, vacation.LastDay.Month) by vacation.EmployeeName into employeeVacations
                                               orderby employeeVacations.Key
                                               select new { employeeVacations.Key, employeeVacations };

            var months = Enumerable.Range(1, 12).ToList(); ;
            var result = new List<(int, int)>();

            foreach (var month in months)
            {
                int numberOfEmployees = 0;
                foreach (var group in vacationMonthsByEmployeeName)
                {
                    foreach (var vacationMonths in group.employeeVacations)
                    {
                        if (vacationMonths.Item1 == month || vacationMonths.Item2 == month)
                        {
                            numberOfEmployees++;
                            break;
                        }
                    }
                }
                result.Add((month, numberOfEmployees));
            }           

            return result;
        }

        // Inputs a date range and outputs a list of days in that range on which employees did not take vacations.
        public IEnumerable<DateTime> GetDatesWithoutVacations(DateTime firstDay, DateTime lastDay)
        {            
            var result = Enumerable.Range(0, 1 + (lastDay - firstDay).Days).Select(offset => firstDay.AddDays(offset)).ToList();

            foreach (var vacation in _vacations)
            {   
                if (vacation.FirstDay >= firstDay && vacation.FirstDay <= lastDay ||
                    vacation.LastDay >= firstDay && vacation.LastDay <= lastDay)
                {
                    var date = vacation.FirstDay;
                    while (date <= vacation.LastDay)
                    {
                        result.Remove(date);
                        date = date.AddDays(1);
                    }
                }                
            }
            
            return result;
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
    }
}
