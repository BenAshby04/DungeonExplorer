using System;

namespace DungeonExplorer
{
    public class Sorcerer : Monster
    {
        private int maxHP;
        /// <summary>
        /// Sorcerer Constructor
        /// </summary>
        /// <param name="monsterId">Monster ID</param>
        /// <param name="name">Sorcerer Name</param>
        /// <param name="hp">Sorcerer HP</param>
        /// <param name="damage">Sorcerer Damage</param>
        public Sorcerer(int monsterId, string name, int hp, int damage) : base(monsterId, name, hp, damage)
        {
            maxHP = hp;
        }

        public void CastHeal()
        {
            // Get half of the maxHP
            int halfHP = maxHP / 2;
            // Generate random number of HP
            Random rnd = new Random();
            int hpNext = rnd.Next(1, halfHP);
            // Check to see if that will take the Sorcerer over maxHP
            if (health + hpNext > maxHP)
            {
                // If it does, set health to maxHP
                health = maxHP;
            }
            else
            {
                // Otherwise, add the random number to the Sorcerer's health
                health += hpNext;
            }
        }
    }
}