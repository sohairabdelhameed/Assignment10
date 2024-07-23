namespace _3D_Point
{
    internal class Program
    {
        private static Point3D ReadPoint()
        {
            try
            {
                string[] coordinates = Console.ReadLine().Split(',');
                int x = int.Parse(coordinates[0].Trim());
                int y = int.Parse(coordinates[1].Trim());
                int z = int.Parse(coordinates[2].Trim());
                return new Point3D(x, y, z);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter valid coordinates.");
                return ReadPoint();
            }
        }


        static void Main(string[] args)
        {

            // Step 3: Read from user the coordinates for 2 points P1 and P2
            Console.WriteLine("Enter coordinates for point P1 (x, y, z): ");
            Point3D P1 = ReadPoint();

            Console.WriteLine("Enter coordinates for point P2 (x, y, z): ");
            Point3D P2 = ReadPoint();

            // Step 4: Try to use ==
            if (P1 == P2)
            {
                Console.WriteLine("P1 and P2 are equal.");
            }
            else
            {
                Console.WriteLine("P1 and P2 are not equal.");
            }

            // Step 5: Define an array of points and sort it
            Point3D[] points = new Point3D[]
            {
                new Point3D(3, 4, 5),
                new Point3D(1, 2, 3),
                new Point3D(6, 7, 8)
            };

            Array.Sort(points);

            Console.WriteLine("Sorted points:");
            foreach (var point in points)
            {
                Console.WriteLine(point.ToString());
            }

            // Clone a point
            Point3D P3 = (Point3D)P1.Clone();
            Console.WriteLine($"Cloned point P3: {P3.ToString()}");
        



        }
    }

    
}
