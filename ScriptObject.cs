using Missioneer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missioneer
{
    public class ScriptObject : SimObject
    {
        public ScriptObject() => classname = "ScriptObject";
        public ScriptObject(string name)
        {
            classname = "ScriptObject";
            this.name = name;
        }
        public ScriptObject(Dictionary<string, string> dynamicfieldDict) => dynamicFields = dynamicfieldDict;
        public override string Write()
        {
            StringBuilder Code = new StringBuilder();
            Code.AppendLine(IndentLevel.GetIndent() + "new ScriptObject(" + name + ") {");
            IndentLevel.indentLevel++;
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
