using System;

namespace UnoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            Console.WriteLine(deck.Cards.Count);
            foreach (var card in deck.Cards)
            {
                card.Display();
            }
        }
    }
}
