using System.Dynamic;
using System.Security.Cryptography;

namespace ass3.Classes;

public class Player
{
    public int WinCount {get; set;}
    public string UserName {get; set;}
    public string UserChoice {get; set;}

    public Player(string userName) // Set the Player's name, and score to 0 upon object creation.
    {
        WinCount = 0;
        UserName = userName;
    }
    public void IncrementWin() // Increase Player's win count upon their victory.
    {
        WinCount++;
    }
}