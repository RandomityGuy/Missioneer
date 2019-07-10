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
        enum ImportStatus
        {
            Class,
            Children,
            Properties,
            BracesStart,
            BracesEnd
        }


        public SimGroup Import(string filename)
        {
            var rawMission = File.ReadLines(filename).ToList();

            SimObject curobj = null;
            var status = new ImportStatus();

            int curpos = 0;

            int bracestartindex = 0;
            int braceendindex = 0;

            int braceskip = 0;

            for (var i = 0; i < rawMission.Count;i++)
            {
                var a = rawMission[i];
                rawMission[i] = a.Trim();
                if (rawMission[i].Contains("//"))
                {
                    rawMission[i] = rawMission[i].Split(new string[] { "//" }, StringSplitOptions.None)[0];
                }
            }

            status = ImportStatus.Class;

            foreach (var line in rawMission)
            {
                string l = line;

                if (l.Contains("new") && status == ImportStatus.Class)
                {                    
                    var raw = l.Split(' ')[1];
                    var objclass = raw.Substring(0, raw.IndexOf('('));
                    var name = raw.Substring(raw.IndexOf('(')+1, raw.IndexOf(')') - raw.IndexOf('(') - 1);
                    switch (objclass)
                        {
                            case "SimGroup":
                                curobj = new SimGroup() { objname = name };
                                break;

                            case "ScriptObject":
                                curobj = new ScriptObject(name);
                                break;

                            case "Sky":
                                curobj = new Sky() { objname = name };
                                break;

                            case "Sun":
                                curobj = new Sun() { objname = name };
                                break;

                            case "Item":
                                curobj = new Item() { objname = name };
                                break;

                            case "InteriorInstance":
                                curobj = new InteriorInstance() { objname = name };
                                break;

                            case "Path":
                                curobj = new Path() { objname = name };
                                break;

                            case "Marker":
                                curobj = new Marker() { objname = name };
                                break;

                            case "PathedInterior":
                                curobj = new PathedInterior() { objname = name };
                                break;

                            case "Trigger":
                                curobj = new Trigger() { objname = name };
                                break;

                            case "StaticShape":
                                curobj = new StaticShape() { objname = name };
                                break;

                            default:
                                curobj = new SimObject() { objname = name };
                                break;
                        }
                    status = ImportStatus.BracesStart;
                }  
                
                if (status == ImportStatus.BracesStart)
                {
                    if (l.Contains("{"))
                    {
                        bracestartindex = curpos;
                        status = ImportStatus.BracesEnd;
                    }
                }
                if (status == ImportStatus.BracesEnd)
                {
                    if (l.Contains("{"))
                    {
                        braceskip++;
                    }

                    if (l.Contains("};"))
                    {
                        if (braceskip == 1)
                        {
                            braceendindex = curpos;
                            status = ImportStatus.Children;
                            var childlines = rawMission.GetRange(bracestartindex + 1, braceendindex - bracestartindex - 1);
                            Import(childlines, ref curobj);
                        }
                        braceskip--;
                    }
                }
                curpos++;
            }

            return curobj as SimGroup;

        }

        void Import(List<string> lines, ref SimObject parent)
        {
            SimObject curobj = null;
            var status = new ImportStatus();
            status = ImportStatus.Properties;

            int bracestartindex = 0;
            int braceendindex = 0;
            int curpos = 0;

            int braceskip = 0;

            foreach (var line in lines)
            {
                string l = line;

                if (l.Contains("new") && status == ImportStatus.Properties)
                {
                    var raw = l.Split(' ')[1];
                    var objclass = raw.Substring(0, raw.IndexOf('('));
                    var name = raw.Substring(raw.IndexOf('(') + 1, raw.IndexOf(')') - raw.IndexOf('(') - 1);
                    switch (objclass)
                    {
                        case "SimGroup":
                            curobj = new SimGroup() { objname = name };
                            break;

                        case "ScriptObject":
                            curobj = new ScriptObject(name);
                            break;

                        case "Sky":
                            curobj = new Sky() { objname = name };
                            break;

                        case "Sun":
                            curobj = new Sun() { objname = name };
                            break;

                        case "Item":
                            curobj = new Item() { objname = name };
                            break;

                        case "InteriorInstance":
                            curobj = new InteriorInstance() { objname = name };
                            break;

                        case "Path":
                            curobj = new Path() { objname = name };
                            break;

                        case "Marker":
                            curobj = new Marker() { objname = name };
                            break;

                        case "PathedInterior":
                            curobj = new PathedInterior() { objname = name };
                            break;

                        case "Trigger":
                            curobj = new Trigger() { objname = name };
                            break;

                        case "StaticShape":
                            curobj = new StaticShape() { objname = name };
                            break;

                        default:
                            curobj = new SimObject() { objname = name };
                            break;
                    }
                    status = ImportStatus.BracesStart;
                    (parent as SimGroup).Add(curobj);
                }

                if (status == ImportStatus.BracesStart)
                {
                    if (l.Contains("{"))
                    {
                        bracestartindex = curpos;
                        status = ImportStatus.BracesEnd;
                    }
                }
                if (status == ImportStatus.BracesEnd)
                {
                    if (l.Contains("{"))
                    {
                        braceskip++;
                    }

                    if (l.Contains("};"))
                    {
                        if (braceskip == 1)
                        {
                            braceendindex = curpos;
                            status = ImportStatus.Children;
                            var childlines = lines.GetRange(bracestartindex + 1, braceendindex - bracestartindex - 1);
                            Import(childlines, ref curobj);
                            status = ImportStatus.Properties;
                        }
                        braceskip--;
                    }
                }

                if (l.Contains("=") && status == ImportStatus.Properties)
                {
                    var property = l.Substring(0, l.IndexOf("=")).Trim();
                    var value = l.Substring(l.IndexOf("=")+1, l.IndexOf(";") - l.IndexOf("=") - 1).Trim();
                    value = value.Trim('"');
                    parent[property] = value;
                }
                curpos++;
            }

        }
    }
}
