using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Missioneer.Utils;
namespace Missioneer.ObjectConstructors
{
    public static class PathMaker
    {
        private static double getDistance(Vector from,Vector to)
        {
            var dx = from.X > to.X ? from.X - to.X : to.X - from.X;
            var dy = from.Y > to.Y ? from.Y - to.Y : to.Y - from.Y;
            var dz = from.Z > to.Z ? from.Z - to.Z : to.Z - from.Z;
            return Math.Sqrt(Math.Pow(dx,2) + Math.Pow(dy, 2) + Math.Pow(dz, 2));
        }
        public static void makePath(this GameBase obj,string from,string to,string timetonext="5000")
        {
            var fromnode = new PathNode(new Vector(from), AngAxis.Identity, Vector.One, obj.GetHashCode().ToString() + "b", timetonext) { objname = obj.GetHashCode().ToString() + "a" };
            var tonode = new PathNode(new Vector(to), AngAxis.Identity, Vector.One, obj.GetHashCode().ToString() + "a", timetonext) { objname = obj.GetHashCode().ToString() + "b" };
            obj.Collection.Add(fromnode);
            obj.Collection.Collection.Add(tonode);
            obj.dynamicFields.Add("path", fromnode.objname);
        }
        public static void makePath(this GameBase obj, string from, string to, float speed=10)
        {
            var fromVector = new Vector(from);
            var toVector = new Vector(to);
            var timetonext = getDistance(fromVector, toVector) / speed;
            var fromnode = new PathNode(fromVector, AngAxis.Identity, Vector.One, obj.GetHashCode().ToString() + "b", timetonext.ToString()) { objname = obj.GetHashCode().ToString() + "a" };
            var tonode = new PathNode(toVector, AngAxis.Identity, Vector.One, obj.GetHashCode().ToString() + "a", timetonext.ToString()) { objname = obj.GetHashCode().ToString() + "b" };
            obj.Collection.Add(fromnode);
            obj.Collection.Collection.Add(tonode);
            obj.dynamicFields.Add("path", fromnode.objname);
        }
        public static void makePath(this GameBase obj,params string[] pathXYZ)
        {
            int i;
            for (i = 0; i < pathXYZ.Length; i++)
            {
                PathNode node;
                if (i == pathXYZ.Length - 1)
                {
                    node = new PathNode(new Vector(pathXYZ[i].GetWord(0) + " " + pathXYZ[i].GetWord(1) + " " + pathXYZ[i].GetWord(2)), AngAxis.Identity, Vector.One, pathXYZ[0].GetHashCode().ToString()) { objname = pathXYZ[i].GetHashCode().ToString() };
                }
                else
                    node = new PathNode(new Vector(pathXYZ[i].GetWord(0) + " " + pathXYZ[i].GetWord(1) + " " + pathXYZ[i].GetWord(2)), AngAxis.Identity, Vector.One, pathXYZ[i + 1].GetHashCode().ToString()) { objname = pathXYZ[i].GetHashCode().ToString() };
                obj.Collection.Add(node);                              
            }
            obj.dynamicFields.Add("path", pathXYZ[0].GetHashCode().ToString());
        }
        public static void setPath(this GameBase obj,PathNode path)
        {
            obj.dynamicFields["path"] = path.objname;
        }
        public static void makePath(this GameBase obj,float speed, params string[] pathXYZ)
        {
            int i;
            for (i = 0; i < pathXYZ.Length; i++)
            {
                PathNode node;
                if (i == pathXYZ.Length - 1)
                {
                    var Pos = new Vector(pathXYZ[i].GetWord(0) + " " + pathXYZ[i].GetWord(1) + " " + pathXYZ[i].GetWord(2));
                    var toNext = new Vector(pathXYZ[0].GetWord(0) + " " + pathXYZ[0].GetWord(1) + " " + pathXYZ[0].GetWord(2));
                    var timetonext = getDistance(Pos, toNext);
                    node = new PathNode(Pos, AngAxis.Identity, Vector.One, pathXYZ[0].GetHashCode().ToString(), timetonext.ToString()) { objname = pathXYZ[i].GetHashCode().ToString() };
                }
                else
                {
                    var Pos = new Vector(pathXYZ[i].GetWord(0) + " " + pathXYZ[i].GetWord(1) + " " + pathXYZ[i].GetWord(2));
                    var toNext = new Vector(pathXYZ[i+1].GetWord(0) + " " + pathXYZ[i+1].GetWord(1) + " " + pathXYZ[i+1].GetWord(2));
                    var timetonext = getDistance(Pos, toNext);
                    node = new PathNode(new Vector(pathXYZ[i].GetWord(0) + " " + pathXYZ[i].GetWord(1) + " " + pathXYZ[i].GetWord(2)), AngAxis.Identity, Vector.One, pathXYZ[i + 1].GetHashCode().ToString(),timetonext.ToString()) { objname = pathXYZ[i].GetHashCode().ToString() };
                }
                obj.Collection.Add(node);                
            }
            obj.dynamicFields.Add("path", pathXYZ[0].GetHashCode().ToString());
        }
    }
}
