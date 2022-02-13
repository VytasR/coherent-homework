using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingLib
{
    internal class Logger
    {
        public string FileName { get; }

        public Logger(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("File name can not be null or empty.");
            }
            FileName = fileName;
        }
    }
}
