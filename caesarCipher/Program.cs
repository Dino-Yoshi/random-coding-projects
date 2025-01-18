// See https://aka.ms/new-console-template for more information

using System.Net.Security;
using ass4.Classes;


// Looping Menu 
string st = "";
while (st != "q")
{
    Console.WriteLine("Welcome to Caesar's Cipher Program.");
    Console.WriteLine("Please make a selection from the following: ");
    Console.WriteLine("Encrypt (e)");
    Console.WriteLine("Quit (q)");
    st = Console.ReadLine().ToLower();
    if (st == "e")
    {
        Console.WriteLine("Provide a string to encrypt: ");
        string toModify = Console.ReadLine();
        Console.WriteLine("Provide the # of Shifts: ");
        int numShift = Convert.ToInt32(Console.ReadLine());
        var encrypt = new Encryption(toModify, numShift);
        Console.WriteLine($"Your encrypted word is {encrypt.Encrypt()}.");
        var decrypt = new Decryption(numShift, encrypt.Modified);
        Console.WriteLine($"Your decrypted word is {decrypt.Decrypt()}.");
    }
    if (st == "q")
    {
        Console.WriteLine("Closing Program.");
    }
    else
    {
        Console.WriteLine("Invalid Selection.");
    }
}
