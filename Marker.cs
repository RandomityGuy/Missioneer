using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Missioneer.Utils;
namespace Missioneer
{
    public class Marker : SceneObject
    {
        public Marker() => classname = "Marker";
        public string msToNext;
        public string seqNum;
        public string smoothingType;

        public Marker(string msToNext, string seqNum, string smoothingType, Vector Position, AngAxis Rotation, Vector Scale) : base(Position, Rotation, Scale)
        {
            this.msToNext = msToNext;
            this.seqNum = seqNum;
            this.smoothingType = smoothingType;
            classname = "Marker";
        }

        public override string Write()
        {
            StringBuilder Code = new StringBuilder();
            Code.AppendLine(IndentLevel.GetIndent() + "new Marker(" + objname + ") {");
            IndentLevel.indentLevel++;
            Code.AppendLine(IndentLevel.GetIndent()+"position = \"" + Position.ToString()+"\";");
            Code.AppendLine(IndentLevel.GetIndent()+"rotation = \"" + Rotation.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"scale = \"" + Scale.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"seqNum = \"" + seqNum + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"msToNext = \"" + msToNext + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"smoothingType = \"" + smoothingType + "\";");
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
