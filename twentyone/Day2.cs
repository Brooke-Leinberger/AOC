namespace TwentyOne;

public class Day2
{
   public static int part1(string[] input)
   {
      Dictionary<string, int[]> dirLUT = new Dictionary<string, int[]>()
      {
         {"up",      new int[]{0, -1}},
         {"down",    new int[]{0,  1}},
         {"forward", new int[]{1,  1}},
         {"back",    new int[]{1, -1}},
      };

      int[] position = new []{0, 0}; //depth, horizontal
      int[] delta;
      string[] split;
      
      foreach (string entry in input)
      {
         if(entry == "")
            continue;

         split = entry.Split(' ');
         delta = dirLUT[split[0]];
         position[delta[0]] += delta[1] * int.Parse(split[1]);
      }
      
      Console.WriteLine($"Position: {position.ToString()}");
      
      return position[0] * position[1];
   }
   
   
   public static int part2(string[] input)
   {
      Dictionary<string, int[]> dirLUT = new Dictionary<string, int[]>()
      {
         {"up",      new int[]{2, -1}},
         {"down",    new int[]{2,  1}},
         {"forward", new int[]{1,  1}},
         {"back",    new int[]{1, -1}},
      };

      int[] position = new []{0, 0, 0}; //depth, horizontal, aim
      int[] delta;
      string[] split;
      
      foreach (string entry in input)
      {
         if(entry == "")
            continue;

         split = entry.Split(' ');
         delta = dirLUT[split[0]];
         position[delta[0]] += delta[1] * int.Parse(split[1]);

         if (delta[0] == 1)
            position[0] += delta[1] * int.Parse(split[1]) * position[2];
      }
      
      Console.WriteLine($"Position: {position.ToString()}");
      
      return position[0] * position[1];
   }
}