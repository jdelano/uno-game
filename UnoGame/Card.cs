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
        public string Number { get; private set; }
        public CardColor Color { get; private set; }
        public CardType Type { get; private set; }


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

        public void UpdateColor()
        {
            Console.Write("Please specify a new color: 0=Red, 1=Yellow, 2=Blue, 3=Green");
            int response = int.Parse(Console.ReadLine());
            Color = (CardColor)response;
        }

    }
}
