using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationsApp.CompanyEntities;

namespace VacationsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var company = new Company();

            var vacation1 = new Vacation("Joe", new DateTime(2021, 1, 1), new DateTime(2021, 1, 11));
            var vacation2 = new Vacation("Joe", new DateTime(2021, 7, 15), new DateTime(2021, 7, 30));
            var vacation3 = new Vacation("Dave", new DateTime(2021, 6, 24), new DateTime(2021, 7, 12));
            var vacation4 = new Vacation("Chris", new DateTime(2021, 4, 1), new DateTime(2021, 4, 5));
            var vacation5 = new Vacation("Bill", new DateTime(2021, 9, 1), new DateTime(2021, 9, 16));
            var vacation6 = new Vacation("Bill", new DateTime(2021, 12, 23), new DateTime(2021, 12, 31));
            var vacation7 = new Vacation("Kevin", new DateTime(2021, 8, 15), new DateTime(2021, 8, 22));

            company.AddVacation(vacation1);
            company.AddVacation(vacation2);
            company.AddVacation(vacation3);
            company.AddVacation(vacation4);
            company.AddVacation(vacation5);
            company.AddVacation(vacation6);
            company.AddVacation(vacation7);
                        
            var averageVacationLength = company.GetAverageVacationLength();

            Console.WriteLine("Average length of vacation in the organization was {0} days", averageVacationLength);

            /*var vacationList = new List<Vacation>();
            vacationList.Add(vacation1);
            vacationList.Add(vacation2);
            vacationList.Add(vacation3);
            vacationList.Add(vacation4);
            vacationList.Add(vacation5);
            vacationList.Add(vacation6);
            vacationList.Add(vacation7);*/

            Console.WriteLine("--------------------------------");
            foreach (var item in company.GetAverageVacationLengthPerEmployee())
            {
                Console.WriteLine("{0} had average vacation length of {1} days", item.Item1, item.Item2);
            }

            Console.WriteLine("--------------------------------");
            foreach (var item in company.GetMonthsEmployeesOnVacation())
            {
                Console.WriteLine("{0} month {1} employee(s) were on vacation", item.Item1, item.Item2);
            }
        }
    }
}
