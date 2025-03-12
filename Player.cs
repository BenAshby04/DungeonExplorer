using System;
using System.Collections.Generic;

namespace DungeonExplorer
{

    /// <summary>
    /// Player class that inherits from Entity
    /// </summary>
    public class Player : Entity
    {
      
        private List<Item> inventory = new List<Item>();

        /// <summary>
        /// Player Constructor
        /// </summary>
        /// <param name="name">the name of the player</param>
        /// <param name="health">the health of the player</param>
        public Player(string name, int health) 
        {
            // Set the player's name and health / maxHealth
            Name = name;
            Health = health;
            maxHealth = health;
        }
        // Inventory Setter
        public void PickUpItem(Item item)
        {
            // Add the item to the player's inventory
            inventory.Add(item);
        }
        /// <summary>
        /// Inventory Getter
        /// </summary>
        /// <returns>Output of the current inventory</returns>
        public string InventoryContents()
        {
            // Return the contents of the player's inventory
            string output = "";
            foreach (var item in inventory)
            {
                output = output + item.GetName() + ", ";
            }
            return output;
        }
        public void AttackMonster(Monster monster)
        {
            // Attack the monster
            // Makes the monster die straight away in this iteration will be chaged later down the line
            monster.Health = 0;
            // Output the attack
            System.Console.WriteLine(Name + " attacks " + monster.Name + " and kills it.");
            
            if (monster.Health == 0)
            {
                // Drop loot
                Console.WriteLine(monster.Name + " drops:");
                List<Item> loot = monster.dropLoot();
                foreach (Item item in loot)
                {
                    Console.WriteLine(item.GetName());
                    PickUpItem(item);
                }
            }
        }
    }
}