using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Monster : Entity
    {
        public int MonsterID;
        public int Damage { get; set; }
        private List<Item> loot = new List<Item>();
        public int Health { get; set; }
        /// <summary>
        /// Monster Constructor
        /// </summary>
        /// <param name="monsterId">Monster ID</param>
        /// <param name="name">Monster Name</param>
        /// <param name="hp">Monster Health</param>
        /// <param name="damage">Monster Strength</param>
        public Monster(int monsterId,string name, int hp, int damage) : base(name, hp, damage)
        {
            MonsterID = monsterId;
            Name = name;
            health = hp;
            maxHealth = health;
            Damage = damage;
            generateLoot();
        }


        /// <summary>
        /// Generate Loot
        /// </summary>
        private void generateLoot()
        {
            Random rnd = new Random();
            int chance = rnd.Next(0, 2);
            if(chance == 1)
            {
                loot.Add(new Item(2,"Gold Coins","A heap of Gold Coins"));
            }

            rnd = new Random();
            int chance2 = rnd.Next(0, 11);
            if(chance2 >= 6)
            {
                loot.Add(new Item(1, "Healing Potion", "A Bottle of Healing Potion"));
            }
            
        }
        /// <summary>
        /// Gets Loot List
        /// </summary>
        /// <returns>Returns the loot list</returns>
        public List<Item> dropLoot()
        {
            return loot;
        }
        
        
    }
}
