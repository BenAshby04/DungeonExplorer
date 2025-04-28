using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Inventory
    {
        private List<Item> inventory = new List<Item>();
        
        public Inventory(List<Item> startingInventory)
        {
            inventory = startingInventory;
        }

        public void GetInventory()
        {
            List<string> stringInventory = new List<string>();
            int healthPotionCounter = 0;
            var itemQuery = from item in inventory
                select item;

            foreach (var item in itemQuery)
            {
                if (item.GetName() == "Health Potion")
                {
                    healthPotionCounter++;
                }
                else
                {   
                    stringInventory.Add(item.GetName());
                }
            }

            if (healthPotionCounter <= 0 && stringInventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty");
            }
            else
            {
                Console.WriteLine("Inventory:");
                if (healthPotionCounter > 0) Console.WriteLine(healthPotionCounter + " Health Potions");
                foreach (var item in stringInventory)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            inventory.Remove(item);
        }

        public int FindHealthPotions()
        {
            int count = 0;
            var itemQuery = from item in inventory
                            where item.GetName() == "Health Potion"
                                select item.GetName();
            foreach (string name in itemQuery)
            {
                count++;
            }

            return count;
        }

        public void RemoveHealthPotion()
        {
            int count = FindHealthPotions();
            if (count > 0)
            {
                foreach (Item item in inventory)
                {
                    if (item.GetName() == "Health Potion")
                    {
                        inventory.Remove(item);
                        break;
                    }
                }
            }
            else Console.WriteLine("You have no health potions in your inventory !");
            
        }
    }
}