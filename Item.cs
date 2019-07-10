using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Missioneer.Utils;
namespace Missioneer
{
    public class Item : GameBase
    {
        public bool rotate = true;
        public bool @static = true;
        public Item(string datablock) : base(datablock) => classname = "Item";
        public Item() : base() => classname = "Item";
        public Item(Vector Position, AngAxis Rotation, Vector Scale, string datablock) : base(Position, Rotation, Scale, datablock) => classname = "Item";
        public override string Write()
        {
            StringBuilder Code = new StringBuilder();
            Code.AppendLine(IndentLevel.GetIndent() + "new Item(" + objname + ") {");
            IndentLevel.indentLevel++;
            Code.AppendLine(IndentLevel.GetIndent()+"position = \"" + Position.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"rotation = \"" + Rotation.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"scale = \"" + Scale.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"datablock = \"" + Datablock+ "\";");
            Code.AppendLine(IndentLevel.GetIndent()+"rotate = \"" + Convert.ToInt32(rotate)+"\";");
            Code.AppendLine(IndentLevel.GetIndent()+"static = \"1\";");
            if (dynamicFields.Count!=0)
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
