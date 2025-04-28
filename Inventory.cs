using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Inventory
    {
        private List<Item> inventory = new List<Item>();
        /// <summary>
        /// Inventory Constructor
        /// </summary>
        /// <param name="startingInventory"></param>
        public Inventory(List<Item> startingInventory)
        {
            inventory = startingInventory;
        }
        /// <summary>
        /// GetInventory: returns the contents of the inventory
        /// </summary>
        public void GetInventory()
        {
            // Create a List of strings object to contain the names of the items in the inventory
            List<string> stringInventory = new List<string>();
            // Create a counter for the amount of health potions in the inventory
            int healthPotionCounter = 0;
            // Create a LINQ query to get the items in the inventory
            var itemQuery = from item in inventory
                select item;

            // Loop through the items in the inventory query
            foreach (var item in itemQuery)
            {
                // Check if the item is a health potion
                if (item.GetName() == "Healing Potion")
                {
                    // If it is, increment the health potion counter
                    healthPotionCounter++;
                }
                else
                {
                    // If it is not, add the item to the string inventory
                    stringInventory.Add(item.GetName());
                }
            }
            // Check if the health potion counter is less than or equal to 0 and the string inventory is empty
            if (healthPotionCounter <= 0 && stringInventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty");
            }
            else
            {
                // If the health potion counter is greater than 0, print the number of health potions
                Console.WriteLine("Inventory:");
                if (healthPotionCounter > 0) Console.WriteLine(healthPotionCounter + " Health Potions");
                foreach (var item in stringInventory)
                {
                    // Print the items in the inventory
                    Console.WriteLine(item);
                }
            }
        }

        /// <summary>
        /// AddItem: adds an item to the inventory
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        /// <summary>
        /// RemoveItem: removes an item from the inventory
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(Item item)
        {
            inventory.Remove(item);
        }
        /// <summary>
        /// FindHealthPotions: finds the number of health potions in the inventory
        /// </summary>
        /// <returns></returns>
        private int FindHealthPotions()
        {
            // Create a LINQ query to find the amount of health potions in the inventory
            int count = 0;
            var itemQuery = from item in inventory
                            where item.GetName() == "Healing Potion"
                            select item.GetName();
            foreach (string name in itemQuery)
            {
                // Increase count
                count++;
            }
            // Return the count of health potions
            return count;
        }
        /// <summary>
        /// RemoveHealthPotion: removes a health potion from the inventory
        /// </summary>
        private void RemoveHealthPotion()
        {
            // Get the amount of health potions in the inventory
            int count = FindHealthPotions();
            if (count > 0)
            {
                // Find the first health potion in the inventory
                foreach (Item item in inventory)
                {
                    if (item.GetName() == "Healing Potion")
                    {
                        // Remove one health potion from the inventory
                        inventory.Remove(item);
                        break;
                    }
                }
            }
            // If there are no health potions in the inventory, inform the player
            else Console.WriteLine("You have no health potions in your inventory !");
            
        }
        /// <summary>
        ///   UseHealthPotion: uses a health potion from the inventory
        /// </summary>
        /// <param name="player">Player Object</param>
        /// <returns>Modified Player Object</returns>
        public Player UseHealthPotion(Player player)
        {
            // Get the amount of health potions in the inventory
            int count = FindHealthPotions();
            // Check if the player has any health potions
            // If not, inform the player
            if (count <= 0) Console.WriteLine("You have no health potions in your inventory!");
            else
            {
                // If the player has health potions, check to see if they are already at max health
                if (player.health >= player.maxHealth)
                {
                    // If they are, inform the player
                    Console.WriteLine("You are already at full health!");
                }
                else if (player.health + 10 > player.maxHealth)
                {
                    // Check to see if the potion will put the player over max health
                    // If it does, set the player's health to max health
                    player.health = player.maxHealth;
                    Console.WriteLine("You used a health potion and restored your health to " + player.maxHealth);
                    RemoveHealthPotion();
                }
                else
                {
                    // Otherwise increase the players health by 10
                    player.health += 10;
                    Console.WriteLine("You used a health potion and restored your health to " + player.health);
                    RemoveHealthPotion();
                }
                
            }
            // Return the modified player object
            return player;
        }
    }
}