using Missioneer.Utils;
using System;

namespace Missioneer
{
    public struct AngAxis : IEquatable<AngAxis>
    {
        public readonly float X;
        public readonly float Y;
        public readonly float Z;
        public readonly float angle;
        
        public bool Equals(AngAxis other)
        {
            if (X == other.X && Y == other.Y && Z == other.Z && angle == other.angle)
                return true;
            else return false;
        }

        public AngAxis(float x, float y, float z,float Angle)
        {
            X = x;
            Y = y;
            Z = z;
            angle = Angle;
        }
        public AngAxis(string xyz0)
        {
            X = Convert.ToSingle(xyz0.GetWord(0));
            Y = Convert.ToSingle(xyz0.GetWord(1));
            Z = Convert.ToSingle(xyz0.GetWord(2));
            angle = Convert.ToSingle(xyz0.GetWord(3));

        }
        public static AngAxis fromEuler(double heading, double attitude, double bank)
        {
            // Assuming the angles are in radians.
            double c1 = Math.Cos(heading / 2);
            double s1 = Math.Sin(heading / 2);
            double c2 = Math.Cos(attitude / 2);
            double s2 = Math.Sin(attitude / 2);
            double c3 = Math.Cos(bank / 2);
            double s3 = Math.Sin(bank / 2);
            double c1c2 = c1 * c2;
            double s1s2 = s1 * s2;
            var w = c1c2 * c3 - s1s2 * s3;
            var x = c1c2 * s3 + s1s2 * c3;
            var y = s1 * c2 * c3 + c1 * s2 * s3;
            var z = c1 * s2 * c3 - s1 * c2 * s3;
            var angle = 2 * Math.Acos(w);
            double norm = x * x + y * y + z * z;
            if (norm < 0.001)
            { // when all euler angles are zero angle =0 so
              // we can set axis to anything to avoid divide by zero
                x = 1;
                y = z = 0;
            }
            else
            {
                norm = Math.Sqrt(norm);
                x /= norm;
                y /= norm;
                z /= norm;
            }
            return new AngAxis((float)x, (float)y, (float)z, (float)angle);
        }        
        public override string ToString() => $"{X} {Y} {Z} {angle}";
        public static AngAxis Identity => new AngAxis(1, 0, 0, 0);
    }
}
