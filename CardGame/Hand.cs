using System;

namespace CardGame
{
    public class Hand
    {
        private  Card[] cards = new Card[5];

        public Card[] DrawHand(ref Card[] deck)
        {
            int cardsInHand = 0;
            int cardIdx = 0;

            while (cardsInHand < cards.Length)
            {
                if(cardIdx >= deck.Length || cardIdx >= cards.Length)
                {
                    break;
                }

                if(!deck[cardIdx].beenDrawn)
                {
                    deck[cardIdx].beenDrawn = true;
                    cards[cardIdx] = deck[cardIdx];
                    cardsInHand++;
                }

                cardIdx++;               
            }
            cardIdx = 0;
            cardsInHand = 0;
            return cards;
        }
    }
}