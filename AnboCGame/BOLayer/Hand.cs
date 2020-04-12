using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLayer
{
    public class Hand
    {
        private List<Card> cards = new List<Card>();
        


        public int Count
        {
            get
            {
                return cards.Count();
            }
        }


        public Card this[int index]
        {
            get
            {
                return cards[index];
            }
        }

        public void AddCard(Card newCard)
        {
            if (ContainsCard(newCard))
            {
                throw new ConstraintException(newCard.FaceValue.ToString() + " of " +
                    newCard.Suit.ToString() + " already exists in the Hands");
            }

            cards.Add(newCard);
        }


        private bool ContainsCard(Card cardToCheck)
        {
            return cards.Where(card => card.FaceValue == cardToCheck.FaceValue && card.Suit == cardToCheck.Suit).Count() != 0;
        }


        public void RemoveCard(Card theCard)
        {
            if (!cards.Contains(theCard))
            {
                throw new ConstraintException(theCard.FaceValue.ToString() + " of " +
                    theCard.Suit.ToString() + " not exists in the Hands");
            }

            cards.Remove(theCard);

        }

        public void RemoveCard(int index)
        {
            if (index < 0 || index > cards.Count - 1)
            {
                throw new DataException("A card does not exist in the index position");
            }

            cards.RemoveAt(index);
        }



        public void RemoveCard(Suit theSuit, FaceValue theFaceValue)
        {
            Card card = cards.Where(c => c.FaceValue == theFaceValue && c.Suit == theSuit).FirstOrDefault();

            if (card == null)
            {
                throw new ConstraintException(theFaceValue.ToString() + " of " +
                    theSuit.ToString() + " not exists in the Hands");

            }


            cards.Remove(card);
        }

        //extra

        List<Suit> includeSuits = new List<Suit>();

        public void RemoveFlipedCard()
        {
            
            List<int> removeOrder = new List<int>();
            for (int i = 0; i < cards.Count(); i++)
            {
                if (cards[i].BackCover == true)
                {

                    cards[i].Flip();
                    removeOrder.Add(i);
                }
            }
            int removeCount = 0;
            foreach (int i in removeOrder)
            {
                cards.Remove(cards[i-removeCount]);
                removeCount += 1;

            }
        }

        public string checkSpecialHand()
        {
            

            if (isRoyalFlush())
                return "RoyalFlush";
            if (isStraightFlush())
                return "StraightFlush";
            if (isFourOfAKind())
                return "FourOfAKind";
            if (isFullHouse())
                return "FullHouse";
            if (isFlush())
                return "Flush";
            if (isStraight())
                return "Straight";
            if (isThreeOfAKind())
                return "ThreeOfAKind";
            if (isTwoPair())
                return "TwoPair";
            if (isPair())
                return "Pair";
            return "HighCard";

        }

        public List<Suit> checkSpecialSuit()
        {
            includeSuits = new List<Suit>();

            if (!isRoyalFlush())
                if (!isStraightFlush())
                    if (!isFourOfAKind())
                        if (!isFullHouse())
                            if (!isFlush())
                                if (!isStraight())
                                    if (!isThreeOfAKind())
                                        if (!isTwoPair())
                                            if (!isPair())
                                                return new List<Suit>();
            return includeSuits;
        }


        public List<int> checkSuitCounts()
        {

            int s = 0;
            int h = 0;
            int c = 0;
            int d = 0;

            foreach (Card card in cards)
            {
                if (card.Suit == Suit.Clubs) { c += 1; }
                if (card.Suit == Suit.Diamonds) { d +=1; }
                if (card.Suit == Suit.Hearts) { h += 1; }
                if (card.Suit == Suit.Spades) { s += 1; }
            }
            List<int> tmp=new List<int>();
            tmp.Add(s);
            tmp.Add(h);
            tmp.Add(c);
            tmp.Add(d);
            return tmp;
        }

        public int checkFourOfAKindValue()
        {
            int tmp=0;
            int result=0;
            foreach (Card c in cards)
            {
                if (cards.Where(card => card.FaceValue == c.FaceValue).Count() == 4)
                {
                     tmp=Convert.ToInt32(c.FaceValue);
                }

            }

            if (tmp == 0 || tmp == 12)
                result = 4;
            else if (tmp > 1 && tmp < 5)
                result = 1;
            else if (tmp > 4 && tmp < 9)
                result = 2;
            else if (tmp > 8 && tmp < 13)
                result = 3;

            return result;

        }


        public void flipAll()
        {
            foreach (Card c in cards)
            {
                c.Flip();

            }

        }

        #region hideFunctions

        private bool isRoyalFlush()
        {
            if (!isStraightFlush())
                return false;

            return (cards.Where(card => card.FaceValue == FaceValue.Ace).Count() != 0) && (cards.Where(card => card.FaceValue == FaceValue.Ten).Count() != 0);
        }

        private bool isStraightFlush()
        {
            return isStraight() && isFlush();
        }

        private bool isFourOfAKind()
        {
            foreach (Card c in cards)
            {
                if (cards.Where(card => card.FaceValue == c.FaceValue).Count() == 4)
                {
                    includeSuits.Add(Suit.Clubs);
                    includeSuits.Add(Suit.Diamonds);
                    includeSuits.Add(Suit.Hearts);
                    includeSuits.Add(Suit.Spades);
                    return true;
                }
                    
            }

            return false;
        }

        private bool isFullHouse()
        {
            return isThreeOfAKind() && isPair();
        }

        private bool isFlush()
        {
            if (cards[0].Suit == cards[1].Suit && cards[0].Suit == cards[2].Suit && cards[0].Suit == cards[3].Suit && cards[0].Suit == cards[4].Suit)
            {
                includeSuits.Add(cards[0].Suit);
                return true;
            }
            return false;
        }

        private bool isStraight()
        {
            foreach (Card c in cards)
            {
                if (cards.Where(card => card.FaceValue == c.FaceValue).Count() != 1)
                    return false;
            }

            List<Card> orderedCards = cards.OrderBy(c=>c.FaceValue).ToList();

            if ((orderedCards[4].FaceValue - orderedCards[0].FaceValue == 4) || ((orderedCards[0].FaceValue.ToString() == "Ace") && (orderedCards[1].FaceValue.ToString() == "Ten")))
            {
                foreach (Card c in cards)
                    includeSuits.Add(c.Suit);
                return true;
            }
            return false;
        }

        private bool isThreeOfAKind()
        {
            bool tmp = false;
            foreach (Card c in cards)
            {
                if (cards.Where(card => card.FaceValue == c.FaceValue).Count() == 3)
                {
                    includeSuits.Add(c.Suit);
                    tmp = true;
                }
            }

            return tmp;
        }

        private bool isTwoPair()
        {
            int count = 0;
            
            foreach (Card c in cards)
            {
                if (cards.Where(card => card.FaceValue == c.FaceValue).Count() == 2)
                    count += 1;
                includeSuits.Add(c.Suit);
            }

            if (count != 4)
            {
                includeSuits = new List<Suit>();
                return false;
            }

            return true;
                
        }

        private bool isPair()
        {
            bool tmp = false;

            foreach (Card c in cards)
            {
                if (cards.Where(card => card.FaceValue == c.FaceValue).Count() == 2)
                {
                    includeSuits.Add(c.Suit);

                    tmp = true;
                }
                    
            }

            return tmp;
        }




        #endregion


    }
    }
