using System;
using System.Collections.Generic;

namespace UnoGame
{
    public class Deck
    {
        private static Random randomGenerator = new Random();

        public List<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = new List<Card>();
            for (int color = 0; color < 4; color++)
            {
                for (int number = 0; number < 10; number++)
                {
                    Cards.Add(new Card(number.ToString(), (CardColor)color, CardType.Face));
                    if(number > 0)
                    {
                        Cards.Add(new Card(number.ToString(), (CardColor)color, CardType.Face));
                    }

                }

                for (int i = 0; i < 2; i++)
                {
                    Cards.Add(new Card("S", (CardColor)color, CardType.Skip));
                    Cards.Add(new Card("R", (CardColor)color, CardType.Reverse));
                    Cards.Add(new Card("D2", (CardColor)color, CardType.DrawTwo));
                }
            }
            for (int i = 0; i < 4; i++)
            {
                Cards.Add(new Card("W", CardColor.Black, CardType.Wild));
                Cards.Add(new Card("D4", CardColor.Black, CardType.DrawFour));

            }
        }

        public Card DrawCard()
        {
            Card drawCard = Cards[Cards.Count - 1];
            Cards.Remove(drawCard);
            return drawCard;
        }


        public void Shuffle()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                int j = randomGenerator.Next(0, Cards.Count);
                Card temp = Cards[j];
                Cards[j] = Cards[i];
                Cards[i] = temp;
            }
        }
    }
}
