using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missioneer.ObjectConstructors
{
    public static class Mission
    {
        public static SimGroup MissionGroupNormal(string name = "A Custom Level", string artist = "Your name here", string desc = "Simply indescribable", string starthelptext = "No starthelptext", string platinumTime = "0", string ultimateTime = "0", string awesomeTime = "0", string parTime = "0")
        {
            var missiongroupsg = new SimGroup();
            missiongroupsg.Add(MissionInfo.Normal(name, artist, desc, starthelptext, platinumTime, ultimateTime, awesomeTime, parTime));
            missiongroupsg.Add(new Sky());
            missiongroupsg.Add(new Sun());
            return missiongroupsg;
        }
    }
}
