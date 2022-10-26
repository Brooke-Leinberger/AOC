namespace TwentyOne;

public class Day4
{
    public static int part1(string[] input)
    {
        int[] calls = input[0].Split(',').Select(int.Parse).ToArray();
        List<List<int[]>> boards = new List<List<int[]>>();

        int board = -1;
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == "")
            {
                boards.Add(new List<int[]>());
                board++;
                continue;
            }
            
            boards[board].Add(input[i].Split(' ').Where(c => c != "").Select(int.Parse).ToArray());
        }

        boards = boards.Where(c => c.Count != 0).ToList();

        int lastCalled;
        HashSet<int> called = new HashSet<int>();

        for (int i = 0; i < calls.Length; i++)
        {
            lastCalled = calls[i];
            called.Add(lastCalled);

            foreach (List<int[]> entry in boards)
            {
                if (WinCondition(entry.ToArray(), called))
                    return CalculateAnswer(entry.ToArray(), called, lastCalled);
            }
        }
        
        return 0;
    }

    private static int CalculateAnswer(int[][] board, HashSet<int> called, int lastCalled)
    {
        int sum = 0;
        foreach (int[] row in board)
        {
            sum += row.Where(c => !called.Contains(c)).Sum();
        }

        return sum * lastCalled;
    }

    private static bool WinCondition(int[][] board, HashSet<int> called)
    {
        //check rows
        for (int row = 0; row < board.Length; row++)
        {
            bool passed = true;
            for (int col = 0; col < board[row].Length; col++)
            {
                if (!called.Contains(board[row][col]))
                {
                    passed = false;
                    break;
                }
            }

            if (passed)
                return true;
        }
        
        //check cols
        for (int col = 0; col < board[0].Length; col++)
        {
            bool passed = true;
            for (int row = 0; row < board.Length; row++)
            {
                if (!called.Contains(board[row][col]))
                {
                    passed = false;
                    break;
                }
            }

            if (passed)
                return true;
        }

        return false;
    }
}