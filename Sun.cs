using Missioneer.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missioneer
{
    public class Sun : SceneObject
    {
        public Vector Direction;
        public string Color;
        public string Ambient;
        public Sun()
        {
            classname = "Sun";
            Direction = new Vector(0.5f, 0.5f, -0.5f);
            Color = "1.4 1.2 0.4 1";
            Ambient = "0.3 0.3 0.4 1";
        }
        public override string Write()
        {
            StringBuilder Code = new StringBuilder();
            Code.AppendLine(IndentLevel.GetIndent() + "new Sun(" + objname + ") {");
            IndentLevel.indentLevel++;
            Code.AppendLine(IndentLevel.GetIndent() + "direction = \"" + Direction.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent() + "color = \"" + Color.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent() + "ambient = \"" + Ambient.ToString() + "\";");
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
