using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCDC_Sandbox
{
    class ContentPropertyMapper : IContentPropertyMapper
    {
        //for example
        private string[] mockProperties = new string[5];

        public ContentPropertyMapper()
        {
            //for example
            mockProperties[0] = "DocumentName||Document One||DocumentClass||Agenda||MeetingDate||1/1/2019";
            mockProperties[1] = "DocumentName||Document Two||DocumentClass||Agenda||MeetingDate||2/1/2019";
            mockProperties[2] = "DocumentName||Document Three||DocumentClass||Notes||MeetingDate||10/1/1999";
            mockProperties[3] = "DocumentName||Document Four||DocumentClass||Notes||MeetingDate||";  //missing last value must be handled
            mockProperties[4] = "DocumentName||Document Five||DocumentClass||Notes||MeetingDate||10/1/1999";

            var resultsToInspect = MapProperties(mockProperties);
        }

        public Dictionary<string, string> MapProperties(string properties)
        {
            Dictionary<string, string> kvps = new Dictionary<string, string>();

            var props = properties.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            string key = "";
            string value = "";

            for (int i = 0; i < props.Length; i++)
            {
                if (i%2 == 0 )  //i is even
                {
                    key = props[i];
                }
                else
                {
                    value = props[i];
                    kvps.Add(key, value);
                    key = "";
                    value = "";
                }
            }

            return kvps;
        }

        public Dictionary<string, string>[] MapProperties(string[] properties)
        {
            List<Dictionary<string, string>> mappedProperties = new List<Dictionary<string, string>>();

            foreach (var item in properties)
            {
                mappedProperties.Add(MapProperties(item));
            }

            return mappedProperties.ToArray();
        }
    }
}
