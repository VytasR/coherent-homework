﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationsApp.CompanyEntities
{
    internal class Company
    {
        private List<Vacation> _vacations;

        public Company()
        {
            _vacations = new List<Vacation>();
        }

        public void AddVacation(Vacation newVacation)
        {
            _vacations.Add(newVacation);
        }

        public double GetAverageVacationLength()
        {
            return  _vacations.Average(x => x.GetLength());            
        }

        public IEnumerable<(string, double)> GetAverageVacationLengthPerEmployee()
        {
            var vacationGroupsByEmployeeName = from vacation in _vacations
                                               group vacation by vacation.EmployeeName into employeeVacations
                                               orderby employeeVacations.Key
                                               select new { employeeVacations.Key, employeeVacations };
            
            foreach (var group in vacationGroupsByEmployeeName)
            {                
                yield return (group.Key, group.employeeVacations.Average(x => x.GetLength()));
            }
        }

        // Returns a set of tuples "number of the month of the year - the number of employees on vacation this month".
        // It is considered that an employee was on vacation in a certain month if he spent 1 or more days on vacation that month.
        public IEnumerable<(int, int)> GetMonthsEmployeesOnVacation()
        {
            var vacationGroupsByEmployeeName = from vacation in _vacations
                                               group vacation by vacation.EmployeeName into employeeVacations
                                               orderby employeeVacations.Key
                                               select new { employeeVacations.Key, employeeVacations };

            var employeeVacationMonths = new List<(string, HashSet<int>)>();

            foreach (var group in vacationGroupsByEmployeeName)
            {
                var vacationMonths = new HashSet<int>();
                foreach(var vacation in group.employeeVacations)
                {
                    vacationMonths.Add(vacation.FirstDay.Month);
                    vacationMonths.Add(vacation.LastDay.Month);
                }
                employeeVacationMonths.Add((group.Key, vacationMonths));
            }
                        
            var months = Enumerable.Range(1, 12).ToList();

            var result = new List<(int, int)>();

            foreach (var month in months)
            {
                int numberOfEmployeesOnVacation = 0;
                foreach (var entry in employeeVacationMonths)
                {
                    if (entry.Item2.Contains(month))
                    {
                        numberOfEmployeesOnVacation++;
                    }                    
                }
                result.Add((month, numberOfEmployeesOnVacation));
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
