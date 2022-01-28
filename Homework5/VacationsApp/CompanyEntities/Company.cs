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
            var vacationGroupsByEmployeeName = from vacation in _vacations
                                               group vacation by vacation.EmployeeName into employeeVacations
                                               orderby employeeVacations.Key
                                               select new { employeeVacations.Key, employeeVacations };

            foreach (var group in vacationGroupsByEmployeeName)
            {                
                yield return (group.Key, group.employeeVacations.Average(x => x.GetLength()));
            }
        }
    }
}
