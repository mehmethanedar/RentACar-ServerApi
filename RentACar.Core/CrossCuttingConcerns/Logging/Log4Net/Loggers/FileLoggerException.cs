using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FileLoggerException : LoggerServiceBase
    {
        public FileLoggerException() : base("JsonFileLoggerException")
        {
        }
    }
}
