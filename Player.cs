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
    }
}