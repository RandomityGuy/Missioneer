using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missioneer.Utils
{
    public static class Str
    {
        public static string GetWord(this String str,int index)
        {
            string[] words = str.Split(' ');
            return words[index];
        }
    }
}
