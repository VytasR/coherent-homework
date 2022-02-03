﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationsApp.CompanyEntities;

namespace VacationsApp
{
    internal class Program
    {
        // This program demonstrates the use of Vacation class and vacation statistics in company.
        static void Main(string[] args)
        {
            var company = new Company();

            var vacation1 = new Vacation("Joe", new DateTime(2021, 1, 3), new DateTime(2021, 1, 11));
            var vacation2 = new Vacation("Joe", new DateTime(2021, 7, 15), new DateTime(2021, 7, 30));
            var vacation3 = new Vacation("Dave", new DateTime(2021, 6, 24), new DateTime(2021, 7, 12));
            var vacation4 = new Vacation("Chris", new DateTime(2021, 4, 1), new DateTime(2021, 4, 5));
            var vacation5 = new Vacation("Bill", new DateTime(2021, 9, 1), new DateTime(2021, 9, 16));
            var vacation6 = new Vacation("Bill", new DateTime(2021, 12, 23), new DateTime(2021, 12, 31));
            var vacation7 = new Vacation("Kevin", new DateTime(2021, 8, 15), new DateTime(2021, 8, 22));
            var vacation8 = new Vacation("Joe", new DateTime(2021, 1, 5), new DateTime(2021, 1, 10));
            var vacation9 = new Vacation("Angelina", new DateTime(2021, 7, 28), new DateTime(2021, 8, 6));
            var vacation10 = new Vacation("Angelina", new DateTime(2021, 8, 6), new DateTime(2021, 8, 6));

            company.AddVacation(vacation1);
            company.AddVacation(vacation2);
            company.AddVacation(vacation3);
            company.AddVacation(vacation4);
            company.AddVacation(vacation5);
            company.AddVacation(vacation6);
            company.AddVacation(vacation7);
            company.AddVacation(vacation8);
            company.AddVacation(vacation9);
            company.AddVacation(vacation10);

            var averageVacationLength = company.AverageVacationLength();

            Console.WriteLine("Average length of vacation in the organization was {0:F1} days", averageVacationLength);
                        
            Console.WriteLine("--------------------------------");
            foreach (var item in company.AverageVacationLengthPerEmployee())
            {
                Console.WriteLine("{0} had average vacation length of {1:F1} days", item.Item1, item.Item2);
            }

            Console.WriteLine("--------------------------------");
            foreach (var item in company.MonthsEmployeesOnVacation())
            {
                Console.WriteLine("{0} month {1} employee(s) were on vacation", item.Item1, item.Item2 > 0 ? item.Item2.ToString() : "no");
            }

            Console.WriteLine("--------------------------------");
            var firstDay = new DateTime(2021, 1, 1);
            var lastDay = new DateTime(2021, 12, 31);
            Console.WriteLine($"From {firstDay.ToShortDateString()} to {lastDay.ToShortDateString()} " +
                              $"employees did not take vacations on these dates:");
            int counter = 0;            
            foreach (var date in company.DatesWithoutVacations2021())
            {
                if (counter < 10)
                {
                    Console.Write(date.ToShortDateString() + "   ");
                    counter++;
                }
                else
                {
                    counter = 0;
                    Console.WriteLine();
                }
                
            }

            Console.WriteLine("\n--------------------------------");            
            foreach (var entry in company.GetOverlappingVacationEntries())
            {
                Console.WriteLine($"{entry.Item1.EmployeeName} vacation from {entry.Item1.FirstDay.ToShortDateString()} to {entry.Item1.LastDay.ToShortDateString()}" +
                                  $" overlaps with {entry.Item2.EmployeeName} vacation from {entry.Item2.FirstDay.ToShortDateString()} to {entry.Item2.LastDay.ToShortDateString()}");
            }
        }
    }
}
