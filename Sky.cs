using Missioneer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missioneer
{
    public class Sky : SceneObject
    {
        public const string Blender1 = "~/data/skies_pq/Blender1/blender1.dml";
        public const string Blender2 = "~/data/skies_pq/Blender2/blender2.dml";
        public const string Blender3 = "~/data/skies_pq/Blender3/blender3.dml";
        public const string Blender4 = "~/data/skies_pq/Blender4/blender4.dml";
        public const string Cloudy = "~/data/skies_pq/Cloudy/cloudy.dml";
        public const string Wave = "~/data/skies_pq/Blender1/wave.dml";
        public string Skybox
        {
            get
            {
                return MaterialList;
            }
            private set
            {
                MaterialList = value;
            }
        }
        public string MaterialList;
        public Sky(string skybox = Blender1)
        {
            Position = new Vector("336 136 0");
            Rotation = AngAxis.Identity;
            Scale = Vector.One;
            dynamicFields["visibleDistance"] = "500";
            dynamicFields["useSkyTextures"] = "1";
            dynamicFields["renderBottomTexture"] = "1";
            dynamicFields["skySolidColor"] = "0.6 0.6 0.6 1.0";
            dynamicFields["windVelocity"] = Vector.UnitX.ToString();
            dynamicFields["useSkyTextures"] = "1";
            dynamicFields["windEffectPrecipitation"] = "0";
            dynamicFields["noRenderBans"] = "1";
            Skybox = skybox;
        }
        public override string Write()
        {
            StringBuilder Code = new StringBuilder();
            Code.AppendLine(IndentLevel.GetIndent() + "new Sky(" + objname + ") {");
            IndentLevel.indentLevel++;
            Code.AppendLine(IndentLevel.GetIndent() + "position = \"" + Position.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent() + "rotation = \"" + Rotation.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent() + "scale = \"" + Scale.ToString() + "\";");
            Code.AppendLine(IndentLevel.GetIndent() + "materialList = \"" + Skybox + "\";");
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
