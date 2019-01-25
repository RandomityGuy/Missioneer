using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missioneer.ObjectConstructors
{
    public class StaticShapes
    {
        public static StaticShape StartPad(string position, string rotation, string scale) => new StaticShape("StartPad_PQ", new Vector(position), new AngAxis(rotation), new Vector(scale));
        public static StaticShape EndPad(string position, string rotation, string scale) => new StaticShape("EndPad_PQ", new Vector(position), new AngAxis(rotation), new Vector(scale));
        public static StaticShape Ductfan(string position, string rotation, string scale) => new StaticShape("DuctFan_PQ", new Vector(position), new AngAxis(rotation), new Vector(scale));
        public static StaticShape Tornado(string position, string rotation, string scale) => new StaticShape("Tornado_PQ", new Vector(position), new AngAxis(rotation), new Vector(scale));
        public static StaticShape TrapDoor(string position, string rotation, string scale) => new StaticShape("TrapDoor_PQ", new Vector(position), new AngAxis(rotation), new Vector(scale));
        public static StaticShape Mine(string position, string rotation, string scale) => new StaticShape("LandMine_PQ", new Vector(position), new AngAxis(rotation), new Vector(scale));
        public static StaticShape FadePlatform(string position, string rotation, string scale)
        {
            StaticShape ret = new StaticShape("FadePlatform", new Vector(position), new AngAxis(rotation), new Vector(scale));
            ret.dynamicFields.Add("fadeStyle", "Fade");
            ret.dynamicFields.Add("functionality", "trapdoor");
            ret.dynamicFields.Add("Permanent", "0");
            return ret;
        }
        public static StaticShape Help(string position, string rotation, string scale, string helptext)
        {
            StaticShape ret = new StaticShape("HelpBubble", new Vector(position), new AngAxis(rotation), new Vector(scale));
            ret.dynamicFields.Add("text", helptext);
            ret.dynamicFields.Add("triggerRadius", "3");
            ret.dynamicFields.Add("persistTime", "2000");
            ret.dynamicFields.Add("displayOnce", "0");
            return ret;
        }
    }
}
