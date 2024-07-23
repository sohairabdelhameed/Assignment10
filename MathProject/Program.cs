namespace MathProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Calling the methods without creating an instance of the class


            Console.WriteLine("Enter the first number: ");
            int a = ReadNumber();

            Console.WriteLine("Enter the second number: ");
            int b = ReadNumber();

            Console.WriteLine($"Add: {Maths.Add(a, b)}");
            Console.WriteLine($"Subtract: {Maths.Subtract(a, b)}");
            Console.WriteLine($"Multiply: {Maths.Multiply(a, b)}");
            Console.WriteLine($"Divide: {Maths.Divide(a, b)}");
        }

        private static int ReadNumber()
        {
            int number;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        
        }

    }
    
}
