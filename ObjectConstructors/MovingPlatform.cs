using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missioneer.ObjectConstructors
{
    public static class MovingPlatformMaker
    {
        public static SimGroup MovingPlatform(string from, string to, string Rot,string Scale,string interior,string index,string name,bool doesReturn = true,string time="5000",string smoothing="Linear")
        {
            var platform = new PathedInterior(interior, index,Vector.Zero, new AngAxis(Rot), new Vector(Scale))
            {
                name = name + "MP"
            };
            var fromMarker = new Marker(time, "0", smoothing, new Vector(from), AngAxis.Identity, Vector.One);
            var toMarker = new Marker(time, "1", smoothing, new Vector(to), AngAxis.Identity, Vector.One);
            Marker returnMarker = null;
            if (doesReturn) returnMarker = new Marker(time, "2", smoothing, new Vector(from), AngAxis.Identity, Vector.One);
            var Path = new Path();
            Path.Add(fromMarker);
            Path.Add(toMarker);
            if (doesReturn) Path.Add(returnMarker);
            var sg = new SimGroup()
            {
                name = name
            };
            sg.Add(Path);
            sg.Add(platform);
            return sg;
        }

        public static SimGroup MovingPlatform(string interior,string index,List<Marker> markers)
        {
            var platform = new PathedInterior(interior, index, Vector.Zero, AngAxis.Identity, Vector.One);
            var simgroup = new SimGroup();
            var path = new Path();
            foreach(var marker in markers)
            {
                path.Add(marker);
            }
            simgroup.Add(path);
            simgroup.Add(platform);
            return simgroup;
        }
    }
}
