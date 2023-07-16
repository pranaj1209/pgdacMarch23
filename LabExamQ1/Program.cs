namespace LabExamQ1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Data source
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            // Query creation
            var query = from num in numbers
                        where num % 2 == 0
                        select num;

            // Query execution
            foreach (int num in query)
            {
                Console.WriteLine(num);
            }
        }
    }
}