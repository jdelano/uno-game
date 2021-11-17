using System;
using System.Collections.Generic;

namespace UnoGame
{
    public class Hand
    {
        public List<Card> Cards { get; private set; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        public void Display()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                Console.Write($"{i}: ");
                Cards[i].Display();
            }
            Console.WriteLine("D: Draw a card from the deck.");
        }
    }
}
