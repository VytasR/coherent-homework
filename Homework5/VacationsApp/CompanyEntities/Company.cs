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
    }
}
