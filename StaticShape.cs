using System.Collections.Generic;
using System.Text;
using Missioneer.Utils;
namespace Missioneer
{
    public class StaticShape : GameBase
    {
        public StaticShape(string datablock) : base(datablock) => classname = "StaticShape";
        public StaticShape() :base() => classname = "StaticShape";
        public StaticShape(string datablock,Vector Position,AngAxis Rotation,Vector Scale) : base(Position,Rotation,Scale,datablock) => classname = "StaticShape";
        public override string Write()
        {
            StringBuilder Code = new StringBuilder();
            Code.AppendLine(IndentLevel.GetIndent() + "new StaticShape(" + name + ") {");
            IndentLevel.indentLevel++;
            Code.AppendLine(IndentLevel.GetIndent()+"position = \"" + Position.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"rotation = \"" + Rotation.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"scale = \"" + Scale.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"datablock = \"" + Datablock + "\";");
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
