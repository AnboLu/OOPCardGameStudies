using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOLayer;

namespace AnboCGame
{
    public partial class Form1 : Form
    {
        private Deck aDeck;
        private Hand handAI;
        private Hand handPL;

        //extra
        private Character charAI;
        private Character charPL;
        


        public Form1()
        {
            InitializeComponent();
            resetCharinfo();
            lblActions.Text = "";
            lblRules.Text =
                "Gain ATK by Spades" + Environment.NewLine +
                "Gain DEF by Diamonds" + Environment.NewLine +
                "Gain Health by Hearts" + Environment.NewLine +
                "Gain Draw Chance by Clubs" + Environment.NewLine +
                "Gain Extra power by special hands" + Environment.NewLine +
                "Side that start first get extra chances" + Environment.NewLine +
                "Side that start next get extra defence" + Environment.NewLine +
                Environment.NewLine + 
                "Easy:   Enemy health set to 20" + Environment.NewLine +
                "Normal: Enemy health set to 40" + Environment.NewLine +
                Environment.NewLine + 
                "Quick Duel: Both side health start with 1" + Environment.NewLine +
                "Death Duel: May take loager than you thought";
            lblTurn.Text = "CLICK NEW GAME TO START";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetUp();
            
                
        }


        private void SetUp()
        {
            try
            {
                aDeck = new Deck();
                aDeck.Shuffle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void ShowHand(Panel thePanel, Hand theHand)
        {
            thePanel.Controls.Clear();
            Card aCard;
            PictureBox aPic;

            for (int i = 0; i < theHand.Count; i++)
            {
                aCard = theHand[i];

                string path;

                if (aCard.BackCover == true)
                {
                    path = @"images\" + "cardback.gif";
                }
                else
                {
                    path = @"images\" + aCard.FaceValue.ToString() + aCard.Suit.ToString() + ".jpg";
                }
                    

                aPic = new PictureBox()
                {
                    Image = Image.FromFile(path),
                    Text = aCard.FaceValue.ToString(),
                    Width = 70,
                    Height = 100,
                    Left = 75 * i,
                    Tag = aCard
                };

                aPic.Click += PictureBox_Click;

                thePanel.Controls.Add(aPic);
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picClicked = (PictureBox)sender;

            int cardPos = Panel1.Controls.IndexOf(picClicked);
            if (cardPos != -1)
            {
                
            }
            else
            {
                if (((Card)picClicked.Tag).BackCover)
                {
                    charPL.addChance(1);
                    setCharinfo();
                }
                else {
                    charPL.reduceChance(1);
                    setCharinfo();
                }
                ((Card)picClicked.Tag).Flip();

                ShowHand(Panel2, handPL);
            }

        }

        private async void btnNewGame_Click(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            Panel2.Controls.Clear();

            if (rdbQuick.Checked == true)
            {
                charAI = new Character(1,10,0,0);
                
                charPL = new Character(1, 10, 0, 0);
            }
            else {
                charAI = new Character();
                if (rdbNormal.Checked)
                    charAI = new Character(40, 5, 0, 0);
                charPL = new Character();

            }
            
            lblActions.Text = string.Empty;
            setCharinfo();

            SetUp();

            string who = whoFirst();

            if (who == "AI")
            {
                charPL.setDefence(10);
                charAI.addChance(5);
                setCharinfo();

                roundAI();
            }
            else
            {
                charAI.setDefence(10);
                charPL.addChance(5);
                setCharinfo();

                lblTurn.Text = "YOUR TURN";
                checkReshuffle();
                try
                {
                    handPL = aDeck.DealHand(5);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    SetUp();
                    handPL = aDeck.DealHand(5);
                }

                handPL.flipAll();
                ShowHand(Panel2, handPL);
                await Task.Delay(2000);
                handPL.flipAll();
                ShowHand(Panel2, handPL);

                lblActions.Text += Environment.NewLine + "Your cards dealed.";
                await Task.Delay(2000);
            }
                
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (lblTurn.Text == "YOUR TURN")
            {
                if (charPL.Chance >= 0)
                {
                    handPL.RemoveFlipedCard();

                    while (handPL.Count < 5)
                    {
                        handPL.AddCard(aDeck.DrawOneCard());
                    }

                    ShowHand(Panel2, handPL);


                }
                else {
                    MessageBox.Show("Changes below zero.");
                }

            }
            else
            {
                MessageBox.Show("Not your turn.");
            }
                

            
        }

        private async void btnBattle_Click(object sender, EventArgs e)
        {
            if (lblTurn.Text == "YOUR TURN")
            {
                

                ShowHand(Panel2, handPL);
                List<int> tmp = calculate(handPL);




                charPL.setAttack(tmp[0]);
                if (charPL.Attack > charAI.Defence)
                {
                    charAI.reduceHealth(charPL.Attack - charAI.Defence);
                    lblActions.Text += Environment.NewLine + $"You Attack and hurt AI {charPL.Attack - charAI.Defence} hp";
                }
                else
                    lblActions.Text += Environment.NewLine + "You Attack but Ai guard it";
                await Task.Delay(2000);

                charPL.setDefence(tmp[1]);
                lblActions.Text += Environment.NewLine + $"You put on {tmp[1]} armor";
                await Task.Delay(2000);

                charPL.addHealth(tmp[2]);                
                if (charPL.Health>20)
                    charPL.overHeal(20);
                lblActions.Text += Environment.NewLine + $"You restore Your health to {charPL.Health}";
                await Task.Delay(2000);

                charPL.addChance(tmp[3]);
                lblActions.Text += Environment.NewLine + $"You gain {tmp[3]} chance to change cards";
                await Task.Delay(2000);

                setCharinfo();
                lblActions.Text += Environment.NewLine + $"{aDeck.cardsReamin()} Cards before shuffle";
                await Task.Delay(5000);





                roundAI();
            }
            else {
                MessageBox.Show("Not your turn.");
            }
            
            
        }
        

        private async void roundAI()
        {
            lblTurn.Text = "AI'S TURN";
            checkWinner();

            if (lblTurn.Text == "AI'S TURN")
            {
                lblActions.Text = "";
                await Task.Delay(2000);

                checkReshuffle();
                try
                {
                    handAI = aDeck.DealHand(5);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    SetUp();
                    handAI = aDeck.DealHand(5);
                }

                handAI.flipAll();
                ShowHand(Panel1, handAI);
                await Task.Delay(2000);
                handAI.flipAll();
                ShowHand(Panel1, handAI);


                lblActions.Text += Environment.NewLine+"Ai Deal Cards";
                await Task.Delay(2000);

                List<int> tmp=calculate(handAI);

                charAI.setAttack(tmp[0]);
                if (charAI.Attack > charPL.Defence)
                {
                    charPL.reduceHealth(charAI.Attack - charPL.Defence);
                    lblActions.Text += Environment.NewLine + $"Ai Attacks and hurt you {charAI.Attack - charPL.Defence} hp";
                }
                else
                    lblActions.Text += Environment.NewLine + "Ai Attacks but you guard it";
                await Task.Delay(2000);

                charAI.setDefence(tmp[1]);
                lblActions.Text += Environment.NewLine + $"Ai puts on {tmp[1]} armor";
                await Task.Delay(2000);

                charAI.addHealth(tmp[2]);
                if (rdbNormal.Checked == true)
                    if (charAI.Health > 40)
                        charAI.overHeal(40);
                if (charAI.Health>20)
                    charAI.overHeal(20);
                lblActions.Text += Environment.NewLine + $"Ai restore it's health to {charAI.Health}";
                await Task.Delay(2000);

                charAI.addChance(tmp[3]);
                charPL.reduceChance(tmp[3]);
                if (charPL.Chance < 0)
                    charPL.overSpeed();
                charAI.reduceChance(tmp[3]);
                lblActions.Text += Environment.NewLine + $"Ai steal your chances and decrease it to {charPL.Chance}";
                await Task.Delay(2000);

                setCharinfo();
                lblActions.Text += Environment.NewLine + $"{aDeck.cardsReamin()} Cards before Shuffle";
                await Task.Delay(5000);

                lblTurn.Text = "YOUR TURN";
                checkWinner();
                if(lblTurn.Text == "YOUR TURN")
                {
                    checkReshuffle();
                    try
                    {
                        handPL = aDeck.DealHand(5);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        SetUp();
                        handPL = aDeck.DealHand(5);
                    }

                    handPL.flipAll();
                    ShowHand(Panel2, handPL);
                    await Task.Delay(2000);
                    handPL.flipAll();
                    ShowHand(Panel2, handPL);

                    lblActions.Text += Environment.NewLine + "Your cards dealed.";
                    await Task.Delay(2000);
                }
                
            }

            

            
        }


        private string whoFirst()
        {
            Random rnd = new Random();
            int who = rnd.Next(1, 3);

            if (who == 1)
                return "AI";
            else
                return "PL";
        }

        private void setCharinfo() {
            lblHealthAI.Text = $"Health:{charAI.Health}";
            lblChangeAI.Text = $"Change:{charAI.Chance}";
            lblAtkAI.Text = $"ATK:{charAI.Attack}";
            lblDefAI.Text = $"DEF:{charAI.Defence}";
            lblHealthPL.Text = $"Health:{charPL.Health}";
            lblChangePL.Text = $"Change:{charPL.Chance}";
            lblAtkPL.Text = $"ATK:{charPL.Attack}";
            lblDefPL.Text = $"DEF:{charPL.Defence}";
        }
        private void resetCharinfo() {
            lblHealthAI.Text = "Health:???";
            lblChangeAI.Text = "Change:???";
            lblAtkAI.Text = "ATK:???";
            lblDefAI.Text = "DEF:???";
            lblHealthPL.Text = "Health:???";
            lblChangePL.Text = "Change:???";
            lblAtkPL.Text = "ATK:???";
            lblDefPL.Text = "DEF:???";
        }

        private void checkWinner()
        {
            if (charAI.Health <= 0)
            {
                lblTurn.Text = "YOU WIN";
                handAI.flipAll();
                handPL.flipAll();
                resetCharinfo();
            }

            if (charPL.Health <= 0)
            {
                lblTurn.Text = "YOU LOSE";
                handAI.flipAll();
                handPL.flipAll();
                resetCharinfo();
            }
                
        }


        private List<int> calculate(Hand theHand)
        {
            string specialhand = theHand.checkSpecialHand();
            List<Suit> includeSuits = theHand.checkSpecialSuit();
            List<int> suitCounts = theHand.checkSuitCounts();
            

            int heartsSpecial = 0;
            int diamondsSpecial = 0;
            int clubsSpecial = 0;
            int spadesSpecial = 0;

            if (includeSuits.Any())
            {
                foreach (Suit s in includeSuits)
                {
                    if (s.Equals(Suit.Clubs)) { clubsSpecial = 1; }
                    if (s.Equals(Suit.Diamonds)) { diamondsSpecial = 1; }
                    if (s.Equals(Suit.Hearts)) { heartsSpecial = 1; }
                    if (s.Equals(Suit.Spades)) { spadesSpecial = 1; }
                }

            }



            int heartsEffect = 1;
            int diamondsEffect = 1;
            int clubsEffect = 1;
            int spadesEffect = 1;

            int heartsExtra = 0;
            int diamondsExtra = 0;
            int clubsExtra = 0;
            int spadesExtra = 0;

            int finaleH = 1;
            int finaleS = 1;
            int finaleC = 1;
            int finaleD = 1;


            if (specialhand == "RoyalFlush") {
                finaleH = 100;
                finaleS = 100;
                finaleC = 100;
                finaleD = 100;
            }
            if (specialhand == "StraightFlush") {
                heartsEffect += heartsSpecial;
                diamondsEffect += diamondsSpecial;
                spadesEffect += spadesSpecial;
                clubsEffect += clubsSpecial;
                finaleH += heartsSpecial;
                finaleS += diamondsSpecial;
                finaleC += clubsSpecial;
                finaleD += spadesSpecial;
            }
            if (specialhand == "FourOfAKind") {
                heartsExtra = theHand.checkFourOfAKindValue();
                spadesExtra = theHand.checkFourOfAKindValue();
                clubsExtra = theHand.checkFourOfAKindValue();
                diamondsExtra = theHand.checkFourOfAKindValue();
            }
            if (specialhand == "FullHouse") {
                heartsExtra = heartsSpecial * 2;
                spadesExtra = spadesSpecial * 2;
                clubsExtra = clubsSpecial * 2;
                diamondsExtra = diamondsSpecial * 2;
            }
            if (specialhand == "Flush") {
                finaleH += heartsSpecial;
                finaleS += diamondsSpecial;
                finaleC += clubsSpecial;
                finaleD += spadesSpecial;
            }
            if (specialhand == "Straight") {
                heartsEffect += heartsSpecial;
                diamondsEffect += diamondsSpecial;
                spadesEffect += spadesSpecial;
                clubsEffect += clubsSpecial;
            }
            if (specialhand == "ThreeOfAKind") {
                heartsExtra = heartsSpecial;
                spadesExtra = spadesSpecial;
                clubsExtra = clubsSpecial;
                diamondsExtra = diamondsSpecial;
            }
            if (specialhand == "TwoPair") {
                heartsExtra = heartsSpecial;
                spadesExtra = spadesSpecial;
                clubsExtra = clubsSpecial;
                diamondsExtra = diamondsSpecial;
            }
            if (specialhand == "Pair") {
                heartsExtra = heartsSpecial;
                spadesExtra = spadesSpecial;
                clubsExtra = clubsSpecial;
                diamondsExtra = diamondsSpecial;
            }
            if (specialhand == "HighCard") { }


            int atk = (suitCounts[0] * spadesEffect + spadesExtra) * finaleS;
            int def = (suitCounts[3] * diamondsEffect + diamondsExtra) * finaleD;
            int heal = (suitCounts[1] * heartsEffect + heartsExtra) * finaleH;
            int chance = (suitCounts[2] * clubsEffect + clubsExtra) * finaleC;


            List<int> tmp = new List<int>();
            tmp.Add(atk);
            tmp.Add(def);
            tmp.Add(heal);
            tmp.Add(chance);
            return tmp;
        }



        public void checkReshuffle()
        {
            if (aDeck.cardsReamin() < 5)
            {
                lblActions.Text += Environment.NewLine + "Reshuffle Cards...";
                SetUp();
                aDeck.removeExistCards(handAI,handPL);
            }
        }



        #region rdb
        private void rdbEasy_CheckedChanged(object sender, EventArgs e)
        {
            rdbNormal.Checked = false;
        }

        private void rdbNormal_CheckedChanged(object sender, EventArgs e)
        {
            rdbEasy.Checked = false;
        }

        private void rdbQuick_CheckedChanged(object sender, EventArgs e)
        {
            rdbDeath.Checked = false;
        }

        private void rdbDeath_CheckedChanged(object sender, EventArgs e)
        {
            rdbQuick.Checked = false;
        }
        #endregion
    }
}
