using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missioneer
{
    public class PathNode : StaticShape
    {
        public string targetnode
        {
            get
            {
                return dynamicFields["nextNode"];
            }
            set
            {
                if (dynamicFields.ContainsKey("nextNode"))
                {
                    dynamicFields["nextNode"] = value;
                }
                else dynamicFields.Add("nextNode", value);
            }
        }
        public string timetonext
        {
            get
            {
                return dynamicFields["timeToNext"];
            }
            set
            {
                if (dynamicFields.ContainsKey("timeToNext"))
                {
                    dynamicFields["timeToNext"] = value;
                }
                else dynamicFields.Add("timeToNext", value);
            }
        }
        public PathNode(Vector position,AngAxis rotation,Vector scale,string targetnode,string timetonext = "5000") : base("PathNode",position,rotation,scale)
        {
            this.targetnode = targetnode;
            this.timetonext = timetonext;
        }
    }
}
