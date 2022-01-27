using System;
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
            return _vacations.Select(x => (x.EmployeeName, (double)(x.LastDay - x.FirstDay).Days + 1)).ToList();
        }
    }
}
