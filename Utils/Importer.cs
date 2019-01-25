using System;
/*using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Reflection;
namespace Missioneer.Utils
{
    public class Importer
    {
        public SimGroup Import(string fname)
        {
            var mission = File.ReadAllText(fname);
            //Regex https://regex101.com/r/9fYmsF/2
            #region Wastecode
            /*var SimObject = Regex.Matches(mission, @"new ([a-z\_A-Z0-9]+)\(([a-z\_A-Z0-9]*)\) {((\n .*+)+)");
    foreach (Match match in SimObject)
    {
        var Class = match.Groups[0].Value;
        var ClassName = match.Groups[1].Value;
        var FieldText = match.Groups[2].Value;
        if (ClassName == "SimGroup")
        {

        }
        var obj = Activator.CreateInstance(Type.GetType("Missioneer" + Class));
        var Fields = Regex.Matches(FieldText, "([a-z_A-Z0-9]+) = \"(.*)\";");
        foreach (Match FieldMatch in Fields)
        {
            var realObj = obj as SimObject;
            realObj.dynamicFields[FieldMatch.Groups[0].Value] = FieldMatch.Groups[1].Value;
        }
            #endregion
            var SimGroups = Regex.Matches(mission, @"new SimGroup\(([a-zA-Z0-9]+)\) {(\s+\S+)+", RegexOptions.Multiline);

        }
        public string matchSimgroups
    }
}
*/
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Missioneer.Utils
{
    public class Importer
    {
        public SimGroup Import(string filename)
        {
            var rawMission = File.ReadLines(filename).ToList();
            var MissionGroup = new SimGroup() { name = "MissionGroup" };
            return MissionGroup;

        }
    }
}
