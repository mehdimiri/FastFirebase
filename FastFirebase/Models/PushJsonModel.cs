using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFirebase.Models
{
    public class PushJsonModel
    {
        public string[] deviceTokens { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public object data { get; set; }
    }
}
