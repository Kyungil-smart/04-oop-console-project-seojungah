using System;
using System.Text;

namespace PokemonClone
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            GameManager gameManager = new GameManager();
            
            gameManager.Run();
        }
    }
}