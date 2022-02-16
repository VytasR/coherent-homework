using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingLib;

namespace TrackingDemoApp.DemoEntities
{    
    [TrackingEntity]
    public class Person
    {
        [TrackingProperty("First name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [TrackingProperty]
        public int Age { get; set; }

        [TrackingProperty]
        public Address Address { get; set; }

        [TrackingProperty("Pets")]
        public Pet[] _pets;
    }
}
