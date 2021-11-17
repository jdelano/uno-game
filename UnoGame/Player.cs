using System;
namespace UnoGame
{
    public class Player
    {
        private int number;
        private static int playerCount = 0;

        public Hand Hand { get; set; }

        public Player()
        {
            Hand = new Hand();
            number = ++playerCount;
        }

        public void Display()
        {
            Console.WriteLine($"Player {number}'s Hand:\n");
            Hand.Display();
        }
    }
}
