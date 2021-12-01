using System;
using System.Collections.Generic;

namespace UnoGame
{
    public enum Direction
    {
        Left, Right
    }

    public class Game
    {
        private bool isRoundOver = false;
        private bool isGameOver = false;
        private int currentPlayerIndex = 0;
        private Direction gameDirection;
        private int numberOfPlayers;

        private Player CurrentPlayer
        {
            get
            {
                return Players[currentPlayerIndex];
            }
        }

        public List<Player> Players { get; set; }
        public DiscardPile DiscardPile { get; set; }
        public Deck Deck { get; set; }


        public Game()
        {
            Deck = new Deck();
            DiscardPile = new DiscardPile();
            Players = new List<Player>();
        }

        public void Run()
        {
            InitializeGame();
            do
            {
                InitializeRound();
                do
                {
                    ProcessInput();
                    RenderOutput();
                } while (!isRoundOver);
                Console.WriteLine($"Congratulations! Player {currentPlayerIndex} Wins!");
                Console.WriteLine("Press any key to try another round...");
                Console.ReadKey();
            } while (!isGameOver);
        }

        private void InitializeGame()
        {
            Console.Write("Enter the number of players: ");
            numberOfPlayers = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Players.Add(new Player());
            }
            isGameOver = false;
        }

        private void InitializeRound()
        {
            currentPlayerIndex = 0;
            isRoundOver = false;
            Deck.Shuffle();
            DealCards();
            DealCardToDiscardPile();
            gameDirection = Direction.Left;
            RenderOutput();

        }

        private void DealCardToDiscardPile()
        {
            DiscardPile.Cards.Add(Deck.DrawCard());
        }

        private void DealCards()
        {
            for (int cards = 0; cards < 7; cards++)
            {
                foreach (var player in Players)
                {
                    player.Hand.Cards.Add(Deck.DrawCard());
                }
            }
        }

        private void ProcessInput()
        {
            Console.Write("Which card would you like to play? ");
            string response = Console.ReadLine();
            if (response == "D")
            {
                Card card = Deck.DrawCard();
                CurrentPlayer.Hand.Cards.Add(card);
                Console.Write("\n\nYou drew the ");
                card.Display();
                Console.Write(" card. Press any key to continue...");
                Console.ReadKey();
                PlayCard(CurrentPlayer, card);
            }
            else
            {
                PlayCard(CurrentPlayer, CurrentPlayer.Hand.Cards[int.Parse(response)]);

            }
        }

        private bool CanPlayCard(Card card)
        {
            return card.Color == DiscardPile.TopCard.Color ||
                card.Number == DiscardPile.TopCard.Number ||
                card.Type == CardType.DrawFour ||
                card.Type == CardType.Wild;
        }

        private void PlayCard(Player currentPlayer, Card card)
        {
            if (CanPlayCard(card))
            {
                currentPlayer.Hand.Cards.Remove(card);
                DiscardPile.Cards.Add(card);
                if (currentPlayer.Hand.Cards.Count == 0)
                {
                    isRoundOver = true;
                }
                else
                {
                    switch (card.Type)
                    {
                        case CardType.Skip:
                            SkipNextPlayer();
                            break;
                        case CardType.Reverse:
                            ReversePlayer();
                            break;
                        case CardType.Wild:
                            card.UpdateColor();
                            SetNextPlayer();
                            break;
                        case CardType.DrawFour:
                            card.UpdateColor();
                            SetNextPlayer();
                            for (int i = 0; i < 4; i++)
                            {
                                CurrentPlayer.Hand.Cards.Add(Deck.DrawCard());
                            }
                            SetNextPlayer();
                            break;
                        case CardType.DrawTwo:
                            SetNextPlayer();
                            for (int i = 0; i < 2; i++)
                            {
                                CurrentPlayer.Hand.Cards.Add(Deck.DrawCard());
                            }
                            SetNextPlayer();
                            break;
                        default:
                            SetNextPlayer();
                            break;

                    }
                }
            }
            else
            {
                Console.WriteLine("Cannot play that card! Press any key to try again...");
                Console.ReadKey();
            }
        }

        private void SetNextPlayer()
        {
            if (gameDirection == Direction.Right)
            {
                currentPlayerIndex--;
                if (currentPlayerIndex < 0)
                {
                    currentPlayerIndex = Players.Count - 1;
                }
            }
            else
            {
                currentPlayerIndex++;
                if (currentPlayerIndex >= Players.Count)
                {
                    currentPlayerIndex = 0;
                }
            }
        }

        private void ReversePlayer()
        {
            gameDirection = (gameDirection == Direction.Right) ? Direction.Left : Direction.Right;
            SetNextPlayer();
        }

        private void SkipNextPlayer()
        {
            SetNextPlayer();
            SetNextPlayer();
        }

        private void RenderOutput()
        {
            Console.Clear();
            DiscardPile.Display();
            CurrentPlayer.Display();
        }

        

     
  
    }
}
