using Missioneer.Utils;
using System.Collections.Generic;
using System.Text;

namespace Missioneer
{
    public class SimGroup : SimObject
    {
        public List<SimObject> GroupItems;
        public SimGroup()
        {
            GroupItems = new List<SimObject>();
            classname = "SimGroup";
        }
        public override string Write()
        {
            StringBuilder Code = new StringBuilder();
            Code.AppendLine(IndentLevel.GetIndent() + "new SimGroup(" + name + ") {");
            IndentLevel.indentLevel++;
            foreach (var item in GroupItems)
            {
                Code.AppendLine(item.Write());
            }
            IndentLevel.indentLevel--;
            Code.AppendLine(IndentLevel.GetIndent() + "};");
            return Code.ToString(); //End of chapter
        }
        public void Add(SimObject obj)
        {
            obj.Collection = this;
            GroupItems.Add(obj);
        }
    }
}
