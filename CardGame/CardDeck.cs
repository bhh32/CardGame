using System;

namespace CardGame
{
    public class CardDeck
    {
        private Card[] cards = new Card[52];
        public Card[] deck = new Card[52];
        public CardDeck()
        {
            InitializeDeck();
         //   DebugWriteDeck(cards);
            deck = ShuffleDeck();
         //   DebugWriteDeck(deck);
        }

        private void InitializeDeck()
        {
            // Start with the lowest value card and first suite.
            int currentValue = 2;
            int currentSuite = 1;

            // Loop through and initialize each card in the deck.
            for(int i = 0; i < cards.Length; ++i)
            {
                cards[i].value = currentValue;
                cards[i].beenDrawn = false;

                cards[i].suite = currentSuite switch
                {
                    1 => Suite.Diamonds,
                    2 => Suite.Hearts,
                    3 => Suite.Clubs,
                    4 => Suite.Spades,
                    _ => Suite.UNKNOWN
                };

                cards[i].name = currentValue switch
                {
                    1 => "One",
                    2 => "Two",
                    3 => "Three",
                    4 => "Four",
                    5 => "Five",
                    6 => "Six",
                    7 => "Seven",
                    8 => "Eight",
                    9 => "Nine",
                    10 => "Ten",
                    11 => "Jack",
                    12 => "Queen",
                    13 => "King",
                    14 => "Ace",
                    _ => "UNKNOWN"
                };

                currentValue++;

                if(currentValue > 14)
                {
                    currentValue = 2;
                    currentSuite++;
                }
            }
        }

        public Card[] ShuffleDeck()
        {
            // Create a temporary array w/ memory for 52 cards.
            Card[] shuffledCards = new Card[52];
            // Create a Random object.
            Random rand = new Random();
            // Create a variable to hold how many cards have been drawn.
            int cardsDrawn = 0;

            // Loop through each of the cards randomly and add them to the shuffled deck.
            while(cardsDrawn < shuffledCards.Length)
            {
                // Get a random int for the card to be drawn.
                int randDraw = rand.Next(0, cards.Length);

                // If the card hasn't been drawn before...
                if(!cards[randDraw].beenDrawn)
                {
                    // ... mark it drawn...
                    cards[randDraw].beenDrawn = true;
                    // ... add it to the shuffledCards deck...
                    shuffledCards[cardsDrawn] = cards[randDraw];
                    // ... and increase how many cards have been drawn.
                    cardsDrawn++;
                }
            }

            // Once all cards have been drawn set both beenDrawn flags to false.
            for(int i = 0; i < 52; ++i)
            {
                shuffledCards[i].beenDrawn = false;
                cards[i].beenDrawn = false;
            }

            // Return the shuffledCards deck.
            return shuffledCards;
        }

        private void DebugWriteDeck(Card[] deckToShow)
        {
            foreach(Card card in deckToShow)
            {
                Console.WriteLine(String.Format("\n\nCard Name: {0}\nCard Suite: {1}\nCard Value: {2}", card.name, card.suite, card.value));
            }
        }
    }
}