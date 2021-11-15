using System;
namespace UnoGame
{
    public enum CardColor
    {
        Red, Yellow, Blue, Green, Black
    }

    public enum CardType
    {
        Face, Reverse, Skip, DrawTwo, DrawFour, Wild
    }

    public class Card
    {
        public string Number { get; set; }
        public CardColor Color { get; set; }
        public CardType Type { get; set; }


        public Card(string number, CardColor color, CardType type)
        {
            Number = number;
            Color = color;
            Type = type;
        }

        public Card() : this("0", CardColor.Blue, CardType.Face)
        {

        }

        public Card(string number) : this(number, CardColor.Blue, CardType.Face)
        {

        }

        public Card(string number, CardColor color) : this(number, color, CardType.Face)
        {

        }

        public void Display()
        {
            Console.WriteLine($"{Color} {Number}");
        }
    }
}
