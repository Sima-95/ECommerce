using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ECommerce.Helpers
{
    public class FilterHelper
    {
        public static string filterJsonToString(string filter)
        {
            if (filter == null || filter == "[]")
                return "1 = 1";
            JArray jo = JArray.Parse(filter);
            var filters = from f in jo
                select (string)f["attribute"] + " " + (((string)f["operation"]).Equals("like") ? ".Contains" : ((string)f["operation"]).Equals("start_with") ? ".StartsWith" : ((string)f["operation"]).Equals("end_with") ? ".EndsWith" : (string)f["operation"]) + " " +  (f["value"].Type == JTokenType.Integer || f["value"].Type == JTokenType.Float || (string)f["value"] == "null" ? (string)f["value"] : " (" + " \"" + (string)f["value"] + "\")");
            return String.Join(" and ", filters);
        }
    }
}
