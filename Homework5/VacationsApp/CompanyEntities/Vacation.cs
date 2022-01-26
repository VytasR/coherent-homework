using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationsApp.CompanyEntities
{
    internal class Vacation
    {
        public string EmployeeName { get; }
        public DateTime FirstDay { get; }
        public DateTime LastDay { get; }

        public Vacation(string employeeName, DateTime firstDay, DateTime lastDay)
        {
            EmployeeName = employeeName;
            FirstDay = firstDay;
            LastDay = lastDay;
        }
    }
}
