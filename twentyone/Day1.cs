using System.Linq;

namespace TwentyOne 
{
    public class Day1
    {
        public static int part1(string[] input)
        {
            int counter = 0;

            int[] values = input.Where(c => c != "").Select(c => int.Parse(c)).ToArray();

            for (int i = 0; i < values.Length - 1; i++)
            {
                if (values[i] < values[i + 1])
                    counter++;
            }
            
            
            return counter;
        }
        
        public static int part2(string[] input)
        {
            int counter = 0;

            int[] values = input.Where(c => c != "").Select(c => int.Parse(c)).ToArray();

            for (int i = 1; i < values.Length - 2; i++)
            {
                int currentWindow = values[i - 1] + values[i] + values[i + 1];
                int nextWindow    = values[i] + values[i + 1] + values[i + 2];
                if (currentWindow < nextWindow)
                    counter++;
            }
            
            
            return counter;
        }
        
    }
}