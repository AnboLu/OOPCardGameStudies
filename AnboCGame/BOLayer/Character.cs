using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLayer
{
    public class Character
    {
        public Character()
        {
            Health = 20;
            Chance = 5;
            Attack = 0;
            Defence = 0;


        }

        public Character(int health, int chance, int attack, int defence)
        {
            Health = health;
            Chance = chance;
            Attack = attack;
            Defence = defence;
        }

        public int Health { get; private set; }
        public int Chance { get; private set; }
        public int Attack { get; private set; }
        public int Defence { get; private set; }

        public void addHealth(int i) { Health += i; }
        public void reduceHealth(int i) { Health -= i; }
        public void addChance(int i) { Chance += i; }
        public void reduceChance(int i) { Chance -= i; }
        public void setAttack(int i) { Attack = i; }
        public void setDefence(int i) { Defence = i; }
        public void overHeal(int i) { Health = i; }
        public void overSpeed() { Chance = 0; }
    }
}
