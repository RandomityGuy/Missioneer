using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Missioneer.Utils;

namespace Missioneer
{
    public static class MarkerPath
    {
        public static List<Marker> Linear(params string[] markers)
        {
            List<Marker> markerpath = new List<Marker>();
            int i;
            for (i=0;i < markers.Length;i++)
            {
                markerpath.Add(new Marker(markers[i].GetWord(3), i.ToString(), "Linear", new Vector(markers[i].GetWord(0) + " " + markers[i].GetWord(1) + " " + markers[i].GetWord(2)), AngAxis.Identity, Vector.One));
            }
            return markerpath;
        }
        public static List<Marker> Accelerate(params string[] markers)
        {
            List<Marker> markerpath = new List<Marker>();
            int i;
            for (i = 0; i < markers.Length; i++)
            {
                markerpath.Add(new Marker(markers[i].GetWord(3), i.ToString(), "Accelerate", new Vector(markers[i].GetWord(0) + " " + markers[i].GetWord(1) + " " + markers[i].GetWord(2)), AngAxis.Identity, Vector.One));
            }
            return markerpath;
        }
        public static List<Marker> Spline(params string[] markers)
        {
            List<Marker> markerpath = new List<Marker>();
            int i;
            for (i = 0; i < markers.Length; i++)
            {
                markerpath.Add(new Marker(markers[i].GetWord(3), i.ToString(), "Spline", new Vector(markers[i].GetWord(0) + " " + markers[i].GetWord(1) + " " + markers[i].GetWord(2)), AngAxis.Identity, Vector.One));
            }
            return markerpath;
        }
    }
}
