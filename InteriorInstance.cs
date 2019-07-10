using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Missioneer.Utils;
namespace Missioneer
{
    public class InteriorInstance : SceneObject
    {
        public string interiorFile;
        public bool showTerrainInside = false;
        public InteriorInstance() => classname = "InteriorInstance";

        public InteriorInstance(string interiorFile, Vector position, AngAxis rotation, Vector scale) : base(position,rotation,scale)
        {
            classname = "InteriorInstance";
            this.interiorFile = interiorFile;
        }
        public override string Write()
        {
            StringBuilder Code = new StringBuilder();
            Code.AppendLine(IndentLevel.GetIndent() + "new InteriorInstance(" + objname + ") {");
            IndentLevel.indentLevel++;
            Code.AppendLine(IndentLevel.GetIndent()+"position = \"" + Position.ToString()+"\";");
            Code.AppendLine(IndentLevel.GetIndent()+"rotation = \"" + Rotation.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"scale = \"" + Scale.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"interiorFile = \"" + interiorFile + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"showTerrainInside = \"0\";");
            if (dynamicFields.Count!=0)
            foreach(KeyValuePair<string,string> dynamicfield in dynamicFields) //dynamic field handling
            {
                Code.AppendLine(IndentLevel.GetIndent() + dynamicfield.Key + " = \"" + dynamicfield.Value + "\";");
            }
            IndentLevel.indentLevel--;
            Code.AppendLine(IndentLevel.GetIndent() + "};");
            return Code.ToString();
        }
    }
}
