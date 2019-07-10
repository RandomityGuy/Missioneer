using Missioneer.Utils;
using System.Collections.Generic;
using System.Text;

namespace Missioneer
{
    public class Path : SimGroup
    {
        public Path()
        {
            GroupItems = new List<SimObject>();
            classname = "Path";
        }
        public override string Write()
        {
            StringBuilder Code = new StringBuilder();
            Code.AppendLine(IndentLevel.GetIndent() + "new Path(" + objname + ") {");
            IndentLevel.indentLevel++;
            foreach (var item in GroupItems)
            {
                Code.AppendLine(item.Write());
            }
            IndentLevel.indentLevel--;
            Code.AppendLine(IndentLevel.GetIndent() + "};");
            return Code.ToString(); //End of chapter
        }
        public void Add(SimObject obj) => GroupItems.Add(obj);
    }
}
