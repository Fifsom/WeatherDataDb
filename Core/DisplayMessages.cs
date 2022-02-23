using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DisplayMessages
    {

        public static void ErrorMessages(int counter, HashSet<string> errorMessages)
        {
            Console.WriteLine("These had the following error message(s):");

            foreach (var item in errorMessages)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        public static void ValidRowsCount(int counter)
        {
            Console.WriteLine($"Total datarows added to database: {counter}");
        }

        public static void DuplicatesCount(int duplicatesCounter)
        {
            Console.WriteLine($"Number of duplicates not included: {duplicatesCounter}");
            Console.WriteLine();
        }

        public static void ExceptionsCount(int exceptionCount)
        {
            Console.WriteLine($"Number of invalid datarows not included: {exceptionCount}");
        }
    }
}
