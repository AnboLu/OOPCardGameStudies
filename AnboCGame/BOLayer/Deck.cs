using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLayer
{
    public class Deck
    {
        private List<Card> deck = new List<Card>();

        public Deck()
        {
            MakeDeck();
        }

        private void MakeDeck()
        {
            foreach (int s in Enum.GetValues(typeof(Suit)))
            {
                foreach (int v in Enum.GetValues(typeof(FaceValue)))
                {
                    Card newCard = new Card((Suit)s, (FaceValue)v);

                    deck.Add(newCard);
                }
            }
        }

        public void Shuffle()
        {
            List<Card> newDeck = new List<Card>();
            Random rGen = new Random();

            while (deck.Count > 0)
            {
                int removeIndex = rGen.Next(0, deck.Count);
                Card cardToRemove = deck[removeIndex];
                deck.RemoveAt(removeIndex);
                newDeck.Add(cardToRemove);
            }

            deck = newDeck;
        }

        public Hand DealHand(int number)
        {
            if (deck.Count == 0)
            {
                throw new ConstraintException("There are no cards left in the deck.  Redeal.");
            }

            Hand hand = new Hand();

            int numCardsToDeal = number;

            if (deck.Count < numCardsToDeal)
            {
                numCardsToDeal = deck.Count;
            }

            for (int i = 0; i < numCardsToDeal; i++)
            {
                hand.AddCard(DrawOneCard());
            }

            return hand;
        }

        public Card DrawOneCard()
        {
            Card topCard;
            if (deck.Count > 0)
            {
                topCard = deck[0];
                deck.RemoveAt(0);

                return topCard;
            }
            else
            {
                throw new ArgumentException("There are no cards in the deck - deal again.");
            }
        }

        //extra
        public int cardsReamin()
        {
            return deck.Count;
        }

        public void removeExistCards(Hand theHandA,Hand theHandB)
        {
            for (int i = 0; i < 5; i++)
            {
                deck.Remove(theHandA[i]);
                deck.Remove(theHandB[i]);
            }


            
        }
    }
}
