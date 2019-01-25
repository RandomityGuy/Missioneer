using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missioneer.Utils
{
    public class IndentLevel
    {
        public static int indentLevel = 0;
        public static string GetIndent()
        {
            var indent = new StringBuilder();
            for (int i = 0; i < indentLevel; i++) indent.Append("   ");
            return indent.ToString();
        }
    }
}
