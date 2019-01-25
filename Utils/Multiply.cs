using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Missioneer.Utils
{
    public static class Multiply
    {
        public static void Multiple(this SceneObject sceneObject,Vector from, Vector to, Vector Offset)
        {

            float x, y, z;
            for (x=from.X;x<to.X;x+=Offset.X)
            {
                for (y = from.Y; y < to.Y; y+=Offset.Y)
                {
                    for (z = from.Z; z < to.Z; z+=Offset.Z)
                    {
                        var clone = ObjectExtensions.Copy(sceneObject);
                        clone.Position = new Vector(x, y, z);
                        sceneObject.Collection.Add(clone);
                    }
                }
            }
        }
        public static void Multiple(this SceneObject sceneObject, Vector from, Vector to)
        {

            float x, y, z;                     
            for (x = from.X; x < to.X; x++)
            {
                for (y = from.Y; y < to.Y; y++)
                {
                    for (z = from.Z; z < to.Z; z++)
                    {
                        var clone = ObjectExtensions.Copy(sceneObject);
                        clone.Position = new Vector(x, y, z);
                        sceneObject.Collection.Add(clone);
                    }
                }
            }
            
        }

    }
}
