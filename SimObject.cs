using System;
using System.Collections.Generic;
using System.Text;

namespace Missioneer
{
    public class SimObject
    {
        public string classname = "SimObject";
        public string name = "";
        public Dictionary<string, string> dynamicFields = new Dictionary<string, string>();
        public SimGroup Collection { get; internal set; }

        public virtual string Write()
         {
            return "NULL";
         }
       
    }
}
