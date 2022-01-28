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
            if (firstDay > lastDay)
            {
                throw new ArgumentException("First day of vacation can not come later than last day.");
            }
            EmployeeName = employeeName;
            FirstDay = firstDay;
            LastDay = lastDay;
        }

        public double GetLength()
        {
            return (LastDay - FirstDay).Days + 1;
        }
    }
}
