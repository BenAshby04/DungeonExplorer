using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Fight
    {
        public string MonsterName;
        public int MonsterHealth;
        public int MonsterDamage;
        public int MonsterMaxHealth;
        public Player player;
        public Sorcerer sorcerer;
        public Zombie zombie;
        public string MonsterType;
        private List<Item> loot = new List<Item>();

        /// <summary>
        /// Fight Constructor
        /// </summary>
        /// <param name="p">Player Object</param>
        /// <param name="s">Sorcerer Object</param>
        /// <param name="z">Zombie Object</param>
        /// <param name="monsterType">Monster Type</param>
        public Fight(Player p, Sorcerer s, Zombie z, string monsterType)
        {
            player = p;
            sorcerer = s;
            zombie = z;
            MonsterType = monsterType;
            if (monsterType == "Zombie")
            {
                // Set the monster's stats
                MonsterName = zombie.Name;
                MonsterHealth = zombie.health;
                MonsterMaxHealth = zombie.maxHealth;
                MonsterDamage = zombie.Damage;
                loot = z.dropLoot();
            }
            else if (monsterType == "Sorcerer")
            {
                // Set the monster's stats
                MonsterName = sorcerer.Name;
                MonsterHealth = sorcerer.health;
                MonsterMaxHealth = sorcerer.maxHealth;
                MonsterDamage = sorcerer.Damage;
                loot = s.dropLoot();
            }
        }
        /// <summary>
        /// Fight Menu
        /// </summary>
        /// <returns>Modified Player Object</returns>
        public Player FightMenu()
        {
            bool fightMenu = true;
            string menuInput = "";
            // Tell the player what monster they are fighting
            Console.WriteLine("You have encountered a " + MonsterName + "!");
            while (fightMenu)
            {
                // Display Fight menu
                Console.WriteLine("Fight Menu:");
                Console.WriteLine("Player Heath " + player.health + "/" + player.maxHealth);
                Console.WriteLine("Monster Heath " + MonsterHealth + "/" + MonsterMaxHealth);
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Use a health potion");
                Console.WriteLine("4. Run");
                Console.WriteLine("Commands: fight, view, use, run");
                Console.Write("> ");
                // Get input from the player    
                menuInput = Console.ReadLine().ToLower();

                if (menuInput == "fight")
                {
                    // Fight the monster
                    // Calculate Damage
                    int damage = player.Strength + player.Damage;
                    // Apply Damage
                    MonsterHealth -= damage;
                    // Inform the player of damage delt
                    Console.WriteLine("You have hit the " + MonsterName + " for " + damage + " damage!");
                    // Check if the monster's health has dropped below 0
                    if (MonsterHealth < 0) MonsterHealth = 0;
                    Test test = new Test();
                    test.checkMonsterDead(MonsterHealth);
                    // Informs the player of the monster's health
                    Console.WriteLine("The " + MonsterName + " has " + MonsterHealth + " health left!");
                    Console.WriteLine();
                    // Check if the monster is dead
                    if (MonsterHealth <= 0)
                    {
                        // Monster is dead
                        Console.WriteLine("The " + MonsterName + " has been defeated!");
                        Console.WriteLine("You have " + player.health + " health left!");
                        // Drop Loot
                        GiveItemsToPlayer();
                        // Exit the fight menu
                        fightMenu = false;
                    }
                    else
                    {
                        // Monster Attack Player
                        player = monsterAttack(player, MonsterType);
                        // Check if the Monster is a Sorcerer
                        if (MonsterType == "Sorcerer")
                        {
                            // Sorcerer casts a spell
                            Random rnd = new Random();
                            int chance = rnd.Next(1, 101);
                            // 25% chance to cast a spell
                            if (chance <= 25)
                            {
                                // Sorcerer casts a healing spell
                                sorcerer.CastHeal();
                                // Heal the Sorcerer
                                Console.WriteLine("The Sorcerer casts a healing spell!");
                                // Inform the player of the Sorcerer's health
                                Console.WriteLine("The Sorcerer has " + sorcerer.health + " health left!");
                                Console.WriteLine();
                            }
                        }
                    }

                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    

             
                }
                else if (menuInput == "view")
                {
                    // Display the inventory
                    player.inv.GetInventory();
                    Console.WriteLine();
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                else if (menuInput == "use")
                {
                    player = player.inv.UseHealthPotion(player);
                    monsterAttack(player,MonsterType);
                }
                else if (menuInput == "run")
                {
                    // Run away
                    Random rnd = new Random();
                    int chance = rnd.Next(1, 101);
                    // 50% chance to run away
                    if (chance <= 50)
                    {
                        Console.WriteLine("You run away!");
                        // Inform Player of health remaining
                        Console.WriteLine("You have " + player.health + " health left!");
                        Console.WriteLine();
                        fightMenu = false;
                    }
                    else
                    {
                        // Failed to run away
                        Console.WriteLine("You failed to run away! You are still hurt!");
                        // Player Takes Damage
                        player = monsterAttack(player, MonsterType);
                    }
                    
                }
                else
                {
                    // Invalid input
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
            }

            return player;
        }
        /// <summary>
        /// Monster Attack
        /// </summary>
        /// <param name="p">Player Object</param>
        /// <param name="monsterType">Monster Type</param>
        /// <returns>Returns Modified Player Object</returns>
        private Player monsterAttack(Player p, string monsterType)
        {
            // Takes Health from the player
            p.health -= MonsterDamage;
            
            Console.WriteLine("You have taken " + MonsterDamage + " damage!");
            // Checks if the player's health has dropped below 0
            if (p.health < 0) p.health = 0;
            // Checks if the player is dead
            Test test = new Test();
            test.checkPlayerDead(p);
            // Informs the player of their health
            Console.WriteLine("You have " + p.health + " health left!");
            // Returns Player object
            return p;
        }
        /// <summary>
        /// Adds items to the player's inventory
        /// </summary>
        private void GiveItemsToPlayer()
        {
            // Check if the monster has loot
            if (loot.Count > 0)
            {

                Console.WriteLine("You have found the following items:");
                // Loop through the loot and add it to the player's inventory
                foreach (var item in loot)
                {
                    Console.WriteLine(item.GetName() + ": " + item.GetDescription());
                    player.inv.AddItem(item);
                }
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            else
            {
                // If the monster has no loot
                Console.WriteLine("You have not found any items.");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
        }
    }
}