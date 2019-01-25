using System;
using System.Collections.Generic;

namespace Missioneer
{
    public class GameBase : SceneObject
    {
        public string Datablock;

        public GameBase(Vector position, AngAxis rotation, Vector scale, string datablock) : base(position,rotation,scale)
        {
            Datablock = datablock;
            classname = "GameBase";
        }

        public GameBase(string datablock)
        {
            Position = new Vector();
            Rotation = new AngAxis(1, 0, 0, 0);
            Scale = new Vector();
            Datablock = datablock;
            classname = "GameBase";
        }     
        public GameBase()
        {
            Position = new Vector();
            Rotation = new AngAxis(1, 0, 0, 0);
            Scale = new Vector();
            Datablock = "NULL";
            classname = "GameBase";
        }
    }
}
