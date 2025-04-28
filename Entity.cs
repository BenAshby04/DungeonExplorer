using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Entity : IDamageable
    {
        public string Name { get;  set; }
        
        public int health { get; set; }
        public int maxHealth { get; set; }
        /// <summary>
        /// Entity Constructor
        /// </summary>
        /// <param name="name">Entity Name</param>
        /// <param name="hp">Entity Health</param>
        /// <param name="damage">Entity Damage capability</param>
        public Entity(string name, int hp, int damage)
        {
            Name = name;
            health = hp;
            maxHealth = hp;
        }
    }
}
