using System;

namespace DungeonExplorer
{
    public class Sorcerer : Monster
    {
        private int maxHP;

        public Sorcerer(int monsterId, string name, int hp, int damage) : base(monsterId, name, hp, damage)
        {
            maxHP = hp;
        }

        public void CastHeal()
        {
            int halfHP = maxHP / 2;
            Random rnd = new Random();
            int hpNext = rnd.Next(1, halfHP);
            health += hpNext;
        }
    }
}