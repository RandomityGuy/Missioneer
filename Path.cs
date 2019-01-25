using Missioneer.Utils;
using System.Collections.Generic;
using System.Text;

namespace Missioneer
{
    public class Path : SimObject
    {
        public List<SimObject> PathItems;
        public Path()
        {
            PathItems = new List<SimObject>();
            classname = "Path";
        }
        public override string Write()
        {
            StringBuilder Code = new StringBuilder();
            Code.AppendLine(IndentLevel.GetIndent() + "new Path(" + name + ") {");
            IndentLevel.indentLevel++;
            foreach (var item in PathItems)
            {
                Code.AppendLine(item.Write());
            }
            IndentLevel.indentLevel--;
            Code.AppendLine(IndentLevel.GetIndent() + "};");
            return Code.ToString(); //End of chapter
        }
        public void Add(SimObject obj) => PathItems.Add(obj);
    }
}
