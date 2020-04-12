using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLayer
{
    public class Card
    {
        public Card(Suit newSuit, FaceValue newValue)
        {
            Suit = newSuit;
            FaceValue = newValue;
        }


        public Suit Suit { get; }

        public FaceValue FaceValue { get; }


        //Extra

        public bool BackCover { get; private set; } = false;

        public void Flip()
        {
            if (BackCover == true)
                BackCover = false;
            else
                BackCover = true;
        }


    }
}
