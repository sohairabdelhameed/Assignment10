using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_Point
{
    internal class Point3D  : IComparable, ICloneable
    {


        #region Properties
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        #endregion

        #region Constructors
        // Default constructor
        public Point3D() : this(0, 0, 0) { }

        // Constructor with one parameter
        public Point3D(int x) : this(x, 0, 0) { }

        // Constructor with two parameters
        public Point3D(int x, int y) : this(x, y, 0) { }

        // Constructor with three parameters
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion


        #region Methods
        // Override the ToString function
        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }

        // Implement ICloneable interface
        public object Clone()
        {
            return new Point3D(X, Y, Z);
        }

        // Implement IComparable interface
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Point3D otherPoint = obj as Point3D;
            if (otherPoint != null)
            {
                int result = X.CompareTo(otherPoint.X);
                if (result == 0)
                {
                    result = Y.CompareTo(otherPoint.Y);
                }
                return result;
            }
            else
            {
                throw new ArgumentException("Object is not a Point3D");
            }
        }

        // Override Equals method for == operator check
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Point3D p = (Point3D)obj;
            return (X == p.X) && (Y == p.Y) && (Z == p.Z);
        }

        // Override GetHashCode method
        public override int GetHashCode()
        {
            return Tuple.Create(X, Y, Z).GetHashCode();
        }

        // Override == and != operators
        public static bool operator ==(Point3D p1, Point3D p2)
        {
            if (ReferenceEquals(p1, null))
            {
                return ReferenceEquals(p2, null);
            }
            return p1.Equals(p2);
        }

        public static bool operator !=(Point3D p1, Point3D p2)
        {
            return !(p1 == p2);
        }

        #endregion
    }

      
}
