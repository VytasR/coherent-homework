using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingLib
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class TrackingPropertyAttribute : System.Attribute
    {
        public string PropertyName { get; }

        public TrackingPropertyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }

        public TrackingPropertyAttribute() { }
    }
}
