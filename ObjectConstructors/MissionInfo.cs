using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missioneer.ObjectConstructors
{
    public static class MissionInfo
    {
        public static ScriptObject Normal(string name = "A Custom Level",string artist = "Your name here",string desc = "Simply indescribable",string starthelptext = "No starthelptext",string platinumTime = "0",string ultimateTime = "0",string awesomeTime = "0",string parTime = "0")
        {
            return new ScriptObject("MissionInfo")
            {
                dynamicFields = new Dictionary<string, string>()
                {
                    {"name",name},
                    {"level","1"},
                    {"type","Custom"},
                    {"game","PQ"},
                    {"artist",artist},
                    {"desc",desc },
                    {"startHelpText",starthelptext},
                    {"platinumTime",platinumTime},
                    {"ultimateTime",ultimateTime},
                    {"awesomeTime",awesomeTime},
                    {"parTime",parTime}
                }
            };
        }
    }
}
