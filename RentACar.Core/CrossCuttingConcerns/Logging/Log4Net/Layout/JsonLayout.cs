using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.CrossCuttingConcerns.Logging.Log4Net.Layout
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
            
        }

        //log eventi jsona çevriliyor
        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new SerializableLogEvent(loggingEvent);
            var json = JsonConvert.SerializeObject(logEvent,Formatting.Indented);
            writer.WriteLine(json);
        }
    }
}
