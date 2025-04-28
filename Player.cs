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
        public Inventory inv = new Inventory(new List<Item>());
        public int Strength;
        public int Damage;
        public Weapon EquipedWeapon;
        /// <summary>
        /// Player Constructor
        /// </summary>
        /// <param name="name">the name of the player</param>
        /// <param name="hp">the health of the player</param>
        public Player(string name, int hp, int strength) : base(name, hp, 0)
        {
            // Set the player's name and health / maxHealth
            Name = name;
            health = hp;
            maxHealth = health;
            Strength = strength;
            for (int i = 0; i < 3; i++) inv.AddItem(new Item(1, "Healing Potion", "A Bottle of Healing Potion"));
            EquipedWeapon = new Weapon(1, "Wooden Sword", "A wooden sword", 5);
            Damage = EquipedWeapon.getAttackPower();
            


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