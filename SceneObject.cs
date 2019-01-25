using System;
using System.Collections.Generic;

namespace Missioneer
{
    public class SceneObject : SimObject
    {
        public Vector Position;
        public AngAxis Rotation;
        public Vector Scale;

        public SceneObject(Vector position, AngAxis rotation, Vector scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
            classname = "SceneObject";
        }

        public SceneObject()
        {
            Position = new Vector();
            Rotation = new AngAxis(1, 0, 0, 0);
            Scale = new Vector(1,1,1);
            classname = "SceneObject";
        }
    }
}
