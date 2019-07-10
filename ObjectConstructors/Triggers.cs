using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missioneer.ObjectConstructors
{
        public class TPTrigger : Trigger
    {
        public Trigger Destination;
        public TPTrigger(Vector position, AngAxis rotation, Vector scale) : base(position, rotation, scale, "TeleportTrigger") => classname = "Trigger";

        public override string Write()
        {
            StringBuilder Code = new StringBuilder();
            Code.AppendLine(base.Write());
            if (!(Destination is null)) Code.AppendLine(Destination.Write());
            return Code.ToString();
        }
    }
    public class PMTrigger : Trigger
    {
        int attributeCount = 0;
        public PMTrigger(Vector position, AngAxis rotation, Vector scale) : base(position, rotation, scale, "MarblePhysModTrigger") => classname = "Trigger";
        public void AddAtrribute(string Attribute,string AttributeValue)
        {
            dynamicFields.Add("marbleAttribute" + attributeCount, Attribute);
            dynamicFields.Add("value" + attributeCount, AttributeValue);
            attributeCount++;
        }
    }
    public class Triggers
    {
        public static Trigger InBoundsTrigger(string Pos, string Rot, string Scale) => new Trigger(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "InBoundsTrigger");
        public static Trigger HelpTrigger(string Pos, string Rot, string Scale,string txt)
        {
            var temp = new Trigger(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "HelpTrigger");
            temp.dynamicFields.Add("text", txt);
            return temp;
        }
        public static TPTrigger TeleportTrigger(string Pos, string Rot, string Scale,bool isRelative, string destPos, string destName)
        {
            var temp = new TPTrigger(new Vector(Pos), new AngAxis(Rot), new Vector(Scale));
            switch (isRelative)
            {
                case false:                   
                    temp.dynamicFields.Add("delay", "2000");
                    temp.dynamicFields.Add("silent", "0");
                    temp.Destination = DestinationTrigger(destPos, destName);
                    temp.dynamicFields.Add("destination", destName);
                    break;
                case true:
                    temp.dynamicFields.Add("delay", "0");
                    temp.dynamicFields.Add("silent", "1");
                    temp.Destination = DestinationTrigger(destPos, destName);
                    temp.dynamicFields.Add("destination", destName);
                    temp.Datablock = "RelativeTPTrigger"; //hehe datablock changing hehe
                    break;                   
            }
            return temp;
        }
        public static Trigger DestinationTrigger(string Pos,string name)
        {
            var temp = new Trigger(new Vector(Pos), AngAxis.Identity, new Vector("1 1 1"), "DestinationTrigger")
            {
                objname = name
            };
            return temp;
        }
        public static Trigger LapsCheckpointTrigger(string Pos, string Rot, string Scale,string index)
        {
            var temp = new Trigger(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "LapsCheckpointTrigger");
            temp.dynamicFields.Add("checkpointNumber", index.ToString());
            return temp;
        }
        public static Trigger LapsCounterTrigger(string Pos, string Rot, string Scale, string index) => new Trigger(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "LapsCounterTrigger");
        public static PMTrigger PhysModTrigger(string Pos, string Rot, string Scale) => new PMTrigger(new Vector(Pos), new AngAxis(Rot), new Vector(Scale));
        public static Trigger GravityWellTrigger(string Pos, string gravityDir, string Scale)
        {
            var temp = new Trigger(new Vector(Pos), AngAxis.Identity, new Vector(Scale), "GravityWellTrigger");
            temp.dynamicFields.Add("axis", gravityDir);
            temp.dynamicFields.Add("customPoint", "");
            temp.dynamicFields.Add("invert", "0");
            temp.dynamicFields.Add("restoreGravity", "");
            temp.dynamicFields.Add("useRadius", "0");
            temp.dynamicFields.Add("radius", "0");
            return temp;
        }
    }
}
