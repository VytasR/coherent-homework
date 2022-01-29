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
        public IEnumerable<Tuple<string, double>> GetAverageVacationLengthPerEmployee()
        {
            var vacationGroupsByEmployeeName = from vacation in _vacations
                                               group vacation.GetLength() by vacation.EmployeeName into vacationLengths
                                               orderby vacationLengths.Key
                                               select new { vacationLengths.Key, vacationLengths };
           
            return vacationGroupsByEmployeeName.
                    Select(group => new Tuple<string, double>(group.Key, group.vacationLengths.Average())).ToList();            
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

        // Inputs date range and outputs a list of days in that range on which employees did not take vacations.
        public IEnumerable<DateTime> GetDatesWithoutVacations(DateTime firstDay, DateTime lastDay)
        {            
            var result = Enumerable.Range(0, 1 + (lastDay - firstDay).Days).Select(offset => firstDay.AddDays(offset)).ToList();

            foreach (var vacation in _vacations)
            {
                var vacationDates = Enumerable.Range(0, 1 + (vacation.LastDay - vacation.FirstDay).Days).Select(offset => vacation.FirstDay.AddDays(offset)).ToList();
                foreach (var date in vacationDates)
                {
                    result.Remove(date);
                }
            }
            
            return result;
        }

        // Returns a set of pairs of vacation records in which the names of the employee are the same, and the dates of two holidays intersect.
        public IEnumerable<(Vacation, Vacation)> GetIncorrectVacationEntries()
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
                        if (vacationToCompare.FirstDay > firstDay && vacationToCompare.FirstDay <= lastDay ||
                            vacationToCompare.FirstDay <= lastDay && vacationToCompare.LastDay > lastDay)
                        {                            
                            if (!result.Contains((vacation, vacationToCompare)))
                            {
                                result.Add((vacationToCompare, vacation));
                            }                                                        
                        }
                    }
                }
            }
            return result;
        }
    }
}
