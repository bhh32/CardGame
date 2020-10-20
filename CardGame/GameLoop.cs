using System;

namespace CardGame
{
    public class GameLoop
    {
        public static void Main(string[] args)
        {
            CardDeck deck = new CardDeck();
            Hand dealer = new Hand();
            Card[] hand = dealer.DrawHand(ref deck.deck);
            Card[] secHand = dealer.DrawHand(ref deck.deck);

            Console.WriteLine("First Hand");
            foreach(Card card in hand)
            {
                Console.WriteLine("Name: " + card.name);
                Console.WriteLine("Suite: " + card.suite);
                Console.WriteLine();
            }   

            Console.WriteLine("Second Hand");
            foreach(Card card in secHand)
            {
                Console.WriteLine("Name: " + card.name);
                Console.WriteLine("Suite: " + card.suite);
                Console.WriteLine();
            }                
        }
    }
}