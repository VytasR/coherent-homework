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
            var vacation2 = new Vacation("joe", new DateTime(2021, 7, 15), new DateTime(2021, 7, 30));
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
            //company.AddVacation(vacation6);
            //company.AddVacation(vacation7);
                        
            var averageVacationLength = company.GetAverageVacationLength();

        }
    }
}
