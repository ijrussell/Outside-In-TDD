using System;

namespace BankKata
{
    public class DefaultConsole : IConsole
    {
        public void PrintLine(string data)
        {
            Console.WriteLine(data);
        }
    }
}