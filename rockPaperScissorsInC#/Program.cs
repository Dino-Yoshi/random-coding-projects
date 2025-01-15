// See https://aka.ms/new-console-template for more information


using System.ComponentModel;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using ass3.Classes;

string st = "";
while (st != "q") // Looping Menu
{
    Console.WriteLine("Welcome to RPS"); // Introduce User to Program, and list options
    Console.WriteLine("Make a selection:");
    Console.WriteLine("Play against another Person! (p)");
    Console.WriteLine("Play against a Computer. (c)");
    Console.WriteLine("Close... (q)");
    string[] choices = ["p", "c", "q"]; // Array of valid options
    st = Console.ReadLine().ToLower(); // Get input from user, lowering it if necessary
    if (st == "p") // If P is chosen:
    {
        Console.WriteLine("Provide a name for Player 1."); // Prompt for User 1 Name
        string userNameP1 = Console.ReadLine();
        Console.WriteLine("Provide a name for Player 2."); // Prompt for User 2 Name
        string userNameP2 = Console.ReadLine();
        Console.WriteLine("How many games to play?"); // Prompt for Number of Games
        int maxPlays = Convert.ToInt32(Console.ReadLine()); 
        var p1 = new Player(userNameP1); // New Player Object for Player 1
        var p2 = new Player(userNameP2); // New Player Object for Player 2
        var Game = new Game(); // New Game Object
        for (int counter = 1; counter < maxPlays+1; counter++) // Loop for number of games
        {
            Console.WriteLine($"{p1.UserName}! Choose Rock, Paper or Scissors!"); // Prompt for Player 1's move
            p1.UserChoice = Console.ReadLine().ToLower();
            Console.WriteLine($"{p2.UserName}! Choose Rock, Paper or Scissors!"); // Prompt for PLayer 2's move
            p2.UserChoice = Console.ReadLine().ToLower();
            int win = Game.DetermineWinner(p1.UserChoice, p2.UserChoice); // Use Game Method to determine winner of the round
            if (win == 0) // based on a returned value, determine if outcome is a tie, player 1's win, or player 2's win.
            {
                Console.WriteLine("It's a Tie.");
            }
            if (win == 1)
            {
                Console.WriteLine($"{p1.UserName} wins round {counter}!");
                p1.IncrementWin(); // Increase the number of wins that Player 1 has
            }
            if (win == 2)
            {
                Console.WriteLine($"{p2.UserName} wins round {counter}!");
                p2.IncrementWin(); // Increase the number of wins that Player 2 has
            }
            if (win == -1)
            {
                Console.WriteLine("Invalid Choice was selected. No points earned.");
            }
        }
        int trueWin = Game.OverallWinner(p1.WinCount, p2.WinCount); // Determine the Winner of the Game based on their win totals
        if (trueWin == 0)
        {
            Console.WriteLine($"{p1.UserName} accumulated {p1.WinCount} wins and {p2.UserName} accumulated {p2.WinCount} wins. ITS A DRAW!");
        }
        if (trueWin == 1)
        {
            Console.WriteLine($"{p1.UserName} accumulated {p1.WinCount} wins and {p2.UserName} accumulated {p2.WinCount} wins. {p1.UserName} WINS!");
        }
        if (trueWin == 2)
        {
            Console.WriteLine($"{p1.UserName} accumulated {p1.WinCount} wins and {p2.UserName} accumulated {p2.WinCount} wins. {p2.UserName} WINS!");
        }
    }
    if (st == "c") // If C is chosen:
    {
        string[] moves = {"rock", "paper", "scissors"}; // Initialize the choices for the computer
        Console.WriteLine("Provide a name for Player 1."); // Prompt User 1 for Name
        string userNameP1 = Console.ReadLine();
        Console.WriteLine("How many games to play?"); // Prompt for number of games to play
        int maxPlays = Convert.ToInt32(Console.ReadLine()); 
        var p1 = new Player(userNameP1); // New Player Object for Player 1
        var p2 = new Player("Computer"); // New Player Object for Computer
        var Game = new Game(); // New Game Object
        for (int counter = 1; counter < maxPlays+1; counter++) // Initialize a for loop iterating by maxPlays
        {
            Console.WriteLine($"{p1.UserName}! Choose Rock, Paper or Scissors!"); // Prompt Player 1 for choice
            p1.UserChoice = Console.ReadLine().ToLower();
            Random rnd = new Random(); // Using Random Class
            int index = rnd.Next(0, moves.Length); // Randomly select a number from the valid index values of "moves"
            p2.UserChoice = moves[index];
            int win = Game.DetermineWinner(p1.UserChoice, p2.UserChoice); // Determine a winner based on the choices made
            if (win == 0)
            {
                Console.WriteLine($"Computer chose: {p2.UserChoice}"); // Tell Player what the computer chose
                Console.WriteLine("It's a Tie.");
            }
            if (win == 1)
            {
                Console.WriteLine($"Computer chose: {p2.UserChoice}"); // Tell Player what the computer chose
                Console.WriteLine($"{p1.UserName} wins round {counter}!");
                p1.IncrementWin(); // Increment the Player's win count
            }
            if (win == 2)
            {
                Console.WriteLine($"Computer chose: {p2.UserChoice}"); // Tell Player what the computer chose
                Console.WriteLine($"{p2.UserName} wins round {counter}!");
                p2.IncrementWin(); // Increment the Computer's win count
            }
            if (win == -1)
            {
                Console.WriteLine("Invalid Choice was selected. No points earned.");
            }
        }
        int trueWin = Game.OverallWinner(p1.WinCount, p2.WinCount); // Determine the overall winner based on win counts
        if (trueWin == 0)
        {
            Console.WriteLine($"{p1.UserName} accumulated {p1.WinCount} wins and {p2.UserName} accumulated {p2.WinCount} wins. ITS A DRAW!");
        }
        if (trueWin == 1)
        {
            Console.WriteLine($"{p1.UserName} accumulated {p1.WinCount} wins and {p2.UserName} accumulated {p2.WinCount} wins. {p1.UserName} WINS!");
        }
        if (trueWin == 2)
        {
            Console.WriteLine($"{p1.UserName} accumulated {p1.WinCount} wins and {p2.UserName} accumulated {p2.WinCount} wins. {p2.UserName} WINS!");
        }
    }
    if (st == "q") // If q is chosen:
    {
        Console.WriteLine("Closing..."); // Close the Program.
    }
    else
    {
        Console.WriteLine("Invalid Selection.");
    }
}