using System;
using System.Collections.Generic;

namespace UnoGame
{
    public class DiscardPile
    {
        public List<Card> Cards { get; set; }

        public Card TopCard
        {
            get
            {
                return Cards[Cards.Count - 1];
            }
        }

        public DiscardPile()
        {
            Cards = new List<Card>();
        }

        public void Display()
        {
            Console.WriteLine("The top card on the discard pile is: ");
            TopCard.Display();
        }
    }
}
