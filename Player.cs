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
        // public void AttackMonster(Zombie zombie, Sorcerer sorcerer, string monsterType)
        // {
        //     bool MonsterPresent = false;
        //     int monsterHP = 0;
        //     string monsterName;
        //     if (monsterType == "Zombie")
        //     {
        //         MonsterPresent = true;
        //         monsterHP = zombie.health;
        //         
        //     }
        //     else if (monsterType == "Sorcerer")
        //     {
        //         monsterHP = sorcerer.health;
        //         MonsterPresent = true;
        //     }
        //     else if (monsterType == "None")
        //     {
        //         // Do Nothing
        //     }
        //     
        //     if (monsterHP <= 0)
        //     {
        //         // Drop loot
        //         Console.WriteLine(monster.Name + " drops:");
        //         List<Item> loot = monster.dropLoot();
        //         foreach (Item item in loot)
        //         {
        //             Console.WriteLine(item.GetName());
        //             PickUpItem(item);
        //         }
        //     }
        // }
    }
}