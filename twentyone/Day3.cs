namespace TwentyOne;

public class Day3
{
    public static int part1(string[] input)
    {
        int[] bitCount = BitCount(input);

        int gamma = 0, epsilon = 0;
        for (int bit = 0; bit < bitCount.Length; bit++)
        {
            int delta = 1<<(bitCount.Length - bit - 1);

            if (bitCount[bit] > input.Length / 2)
                gamma += delta;
            else
                epsilon += delta;
        }
        
        
        return gamma * epsilon;
    }
    
    public static int part2(string[] input)
    {
        int bitCount = input[0].Length;

        string[] oxygen = input;
        string[] carbon = input;
        int index = 0;

        while (oxygen.Length > 1 && index < bitCount)
        {
            oxygen = oxygen.Where(c => 
                c != "" && (
                (c[index] == '1' && BitCounts(oxygen, index) * 2 >= oxygen.Length) ||
                (c[index] == '0' && BitCounts(oxygen, index) * 2 <  oxygen.Length)
                )).ToArray();
            index++;
        }

        index = 0;
        while (carbon.Length > 1 && index < bitCount)
        {
            carbon = carbon.Where(c => 
                c != "" && (
                (c[index] == '1' && BitCounts(carbon, index) * 2 <  carbon.Length) ||
                (c[index] == '0' && BitCounts(carbon, index) * 2 >= carbon.Length)
                )).ToArray();
            index++;
        }
        
        return Convert.ToInt32(carbon[0], 2) * Convert.ToInt32(oxygen[0], 2);
    }

    private static int[] BitCount(string[] bits)
    {
        int[] bitCount = new int[bits[0].Length];

        for (int i = 0; i < bitCount.Length; i++)
            bitCount[i] = 0;
        
        foreach (string entry in bits)
        {
            for (int bit = 0; bit < entry.Length; bit++)
            {
                if (entry[bit] == '1')
                    bitCount[bit]++;
            }
        }

        return bitCount;
    }

    private static int BitCounts(string[] bits, int index)
    {
        int count = 0;
        foreach (string entry in bits)
        {
            if(entry == "")
                continue;
            
            if (entry[index] == '1')
                count++;
        }

        return count;
    }
}