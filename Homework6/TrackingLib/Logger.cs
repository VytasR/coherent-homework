using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrackingLib
{
    internal class Logger
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
            var firstEntry = true;

            foreach (var propertyInfo in obj.GetType().GetProperties())
            {
                var attribute = (TrackingPropertyAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(TrackingPropertyAttribute));
                if (attribute != null)
                {
                    jsonBuilder.Append(firstEntry ? String.Empty : ",");
                    jsonBuilder.Append($"\"{(attribute.PropertyName != null ? attribute.PropertyName : propertyInfo.Name)}\":");
                    jsonBuilder.Append(JsonSerializer.Serialize(propertyInfo.GetValue(obj)));
                    firstEntry = false;
                }
            }

            foreach (var fieldInfo in obj.GetType().GetFields())
            {
                var attribute = (TrackingPropertyAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(TrackingPropertyAttribute));
                if (attribute != null)
                {
                    jsonBuilder.Append(firstEntry ? String.Empty : ",");
                    jsonBuilder.Append($"\"{(attribute.PropertyName != null ? attribute.PropertyName : fieldInfo.Name)}\":");
                    jsonBuilder.Append(JsonSerializer.Serialize(fieldInfo.GetValue(obj)));
                    firstEntry = false;
                }
            }

            jsonBuilder.Append("}");
            Console.WriteLine(jsonBuilder.ToString());
            File.WriteAllText(FileName, jsonBuilder.ToString());
        }
    }
}
