namespace ass3.Classes;

public class Game
{
    public int GameCount {get; set;} // init variable; must be able to be retrieved and set

    public Game()
    {
        GameCount = 1; // Every game starts at round 1
    }

    public int IncreaseGame()
    {
        return GameCount++; // Every loop, the round number increases
    }

    public static int DetermineWinner(string p1Choice, string p2Choice) // All the possible combinations in RPS; return 0 if tie, 1 if p1 wins, 2 if p2 wins, -1 otherwise.
    {
        if (p1Choice == p2Choice)
        {
            return 0;
        }
        if (p1Choice == "rock")
        {
            if (p2Choice == "scissors")
            {
                return 1;
            }
            if (p2Choice == "paper")
            {
                return 2;
            }
        }
        if (p1Choice == "scissors")
        {
            if (p2Choice == "paper")
            {
                return 1;
            }
            if (p2Choice == "rock")
            {
                return 2;
            }
        }
        if (p1Choice == "paper")
        {
            if (p2Choice == "rock")
            {
                return 1;
            }
            if (p2Choice == "scissors")
            {
                return 2;
            }
        }
        return -1;
    }
    public static int OverallWinner(int p1Wins, int p2Wins) // All possible combinations for overallWinner, return 1 if p1 wins, 2 if p2 wins, 0 if tie.
    {
        if (p1Wins > p2Wins)
        {
            return 1;
        }
        if (p1Wins < p2Wins)
        {
            return 2;
        }
        return 0;
    }

}