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
        private List<Item> loot;
        public int Health { get; set; }
        public Monster(int monsterId,string name, int hp, int damage) : base(name, hp, damage)
        {
            MonsterID = monsterId;
            Name = name;
            health = hp;
            maxHealth = health;
            Damage = damage;
            generateLoot();
        }

        

        private void generateLoot()
        {
            Random rnd = new Random();
            int chance = rnd.Next(0, 2);
            if(chance == 1)
            {
                loot.Add(new Item(2,"Gold Coins","A heap of Gold Coins"));
            }

            rnd = new Random();
            int chance2 = rnd.Next(0, 2);
            if(chance2 >= 6)
            {
                loot.Add(new Item(1, "Healing Potion", "A Bottle of Healing Potion"));
            }
            
        }
        public List<Item> dropLoot()
        {
            return loot;
        }
        /// <summary>
        /// Monster performs an attack on the player
        /// </summary>
        /// <param name="player">Current Player</param>
        /// <returns>Player after attack</returns>
        public Player Attack(Player player)
        {
            player.health -= Damage;
            Console.WriteLine(Name + " attacks " + player.Name + " for " + Damage + " damage");
            return player;
        }

        
    }
}
