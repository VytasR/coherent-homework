using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrackingLib
{
    public class Logger
    {
        // This class implements method for logging informaton about objects that have [TrackingEntity] attribute applied.
        public string FileName { get; }

        public Logger(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("File name can not be null or empty.");
            }
            FileName = fileName;
        }

        // Inputs an arbitrary object. If this object has the [TrackingEntity] attribute, then the method writes
        // to the JSON file the values of those instance properties and fields of the object that are marked
        // with the [TrackingProperty] attribute. The name of property or field is taken from the [TrackingProperty]
        // attribute. If the name is not specified there, then the name of the property or field to which
        // the [TrackingProperty] attribute is applied is taken. The name of JSON file is taken from Logger class
        // FileName property.
        public void Track(object obj)
        {
            if ((TrackingEntityAttribute)Attribute.GetCustomAttribute(obj.GetType(), typeof(TrackingEntityAttribute)) == null)
            {
                return;
            }

            var jsonBuilder = new StringBuilder("{");
            var isFirstElement = true;

            foreach (var propertyInfo in obj.GetType().GetProperties())
            {
                AddJsonItem(ref isFirstElement, propertyInfo, propertyInfo.GetValue(obj), jsonBuilder);                
            }

            foreach (var fieldInfo in obj.GetType().GetFields())
            {
                AddJsonItem(ref isFirstElement, fieldInfo, fieldInfo.GetValue(obj), jsonBuilder);                
            }

            jsonBuilder.Append("}");            
            File.WriteAllText(FileName, jsonBuilder.ToString());
        }

        // Adds item to StringBuilder of JSON string.
        private void AddJsonItem(ref bool isFirstElement, System.Reflection.MemberInfo memberInfo, object memberValue, StringBuilder jsonBuilder)
        {
            var attribute = (TrackingPropertyAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(TrackingPropertyAttribute));
            if (attribute != null)
            {
                jsonBuilder.Append(isFirstElement ? String.Empty : ",");
                jsonBuilder.Append($"\"{(attribute.PropertyName != null ? attribute.PropertyName : memberInfo.Name)}\":");
                jsonBuilder.Append(JsonSerializer.Serialize(memberValue));
                isFirstElement = false;
            }
            
        }
    }
}
