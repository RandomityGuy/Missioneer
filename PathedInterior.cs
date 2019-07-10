using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Missioneer.Utils;
namespace Missioneer
{
    public class PathedInterior : GameBase
    {
        public string interiorResource;
        public int interiorIndex=0;
        public Vector basePosition = new Vector();
        public AngAxis baseRotation = new AngAxis();
        public Vector baseScale = new Vector();
        public PathedInterior() => classname = "PathedInterior";

        public PathedInterior(string interiorFile,int interiorIndex, Vector position, AngAxis rotation, Vector scale) : base(position,rotation,scale,"PathedDefault")
        {
            this.interiorIndex = interiorIndex;
            classname = "PathedInterior";
            this.interiorResource = interiorFile;
        }
        public override string Write()
        {
            StringBuilder Code = new StringBuilder();
            Code.AppendLine(IndentLevel.GetIndent() + "new PathedInterior(" + objname + ") {");
            IndentLevel.indentLevel++;
            Code.AppendLine(IndentLevel.GetIndent()+"position = \"" + Position.ToString()+"\";");
            Code.AppendLine(IndentLevel.GetIndent()+"rotation = \"" + Rotation.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"scale = \"" + Scale.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"datablock = \"PathedDefault\";");
            Code.AppendLine(IndentLevel.GetIndent()+"interiorResource = \"" + interiorResource + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"interiorIndex = \"" + interiorIndex + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"basePosition = \"" + Position.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"baseRotation = \"" + Rotation.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"baseScale = \"" + Scale.ToString() + "\";");
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
