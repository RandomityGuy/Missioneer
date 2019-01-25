using System.Collections.Generic;
using System.Text;
using Missioneer.Utils;
namespace Missioneer
{
    public class Trigger : GameBase
    {
        public Trigger(string datablock) : base(datablock) => classname = "Trigger";
        public Trigger() : base() => classname = "Trigger";
        public Trigger(Vector position, AngAxis rotation, Vector scale, string datablock) : base(position, rotation, scale, datablock) => classname = "Trigger";
        public override string Write()
        {
            StringBuilder Code = new StringBuilder();
            Code.AppendLine(IndentLevel.GetIndent() + "new Trigger(" + name + ") {");
            IndentLevel.indentLevel++;
            Code.AppendLine(IndentLevel.GetIndent()+"position = \"" + Position.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent() + "rotation = \"" + Rotation.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent() + "scale = \"" + Scale.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent() + "datablock = \"" + Datablock + "\";");
            Code.AppendLine(IndentLevel.GetIndent() + "polyhedron = \"0 0 0 1 0 0 0 -1 0 0 0 1\";");
            if (dynamicFields.Count != 0)
                foreach (KeyValuePair<string, string> dynamicfield in dynamicFields) //dynamic field handling
            {
                Code.AppendLine(IndentLevel.GetIndent() + dynamicfield.Key + " = \"" + dynamicfield.Value + "\";");
            }
            IndentLevel.indentLevel--;
            Code.AppendLine(IndentLevel.GetIndent() + "};");
            return Code.ToString();
        }
    }
}
