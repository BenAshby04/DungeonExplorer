using System;

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
        
        public Fight(Player p, Sorcerer s, Zombie z, string monsterType)
        {
            player = p;
            sorcerer = s;
            zombie = z;
            MonsterType = monsterType;
            if (monsterType == "Zombie")
            {
                MonsterName = zombie.Name;
                MonsterHealth = zombie.health;
                MonsterMaxHealth = zombie.maxHealth;
                MonsterDamage = zombie.Damage;
            }
            else if (monsterType == "Sorcerer")
            {
                MonsterName = sorcerer.Name;
                MonsterHealth = sorcerer.health;
                MonsterMaxHealth = sorcerer.maxHealth;
                MonsterDamage = sorcerer.Damage;
            }
        }

        public Player FightMenu()
        {
            bool fightMenu = true;
            string menuInput = "";
            
            Console.WriteLine("You have encountered a " + MonsterName + "!");
            while (fightMenu)
            {
                Console.WriteLine("Fight Menu:");
                Console.WriteLine("Player Heath " + player + "/" + player.health);
                Console.WriteLine("Monster Heath " + MonsterHealth + "/" + MonsterMaxHealth);
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Use a health potion");
                Console.WriteLine("4. Run");
                Console.WriteLine("Commands: fight, view, use, run");
                Console.Write("> ");
                menuInput = Console.ReadLine().ToLower();

                if (menuInput == "fight")
                {
                    // Fight the monster
                    int damage = player.Strength + player.Damage;
                    MonsterHealth -= damage;
                    Console.WriteLine("You have hit the " + MonsterName + " for " + damage + " damage!");
                    Console.WriteLine("The " + MonsterName + " has " + MonsterHealth + " health left!");
                    Console.WriteLine();
                    if (MonsterHealth <= 0)
                    {
                        // Monster is dead
                        Console.WriteLine("The " + MonsterName + " has been defeated!");
                        fightMenu = false;
                    }
                    else
                    {
                        player = monsterAttack(player, MonsterType);
                        if (MonsterType == "Sorcerer")
                        {
                            Random rnd = new Random();
                            int chance = rnd.Next(1, 101);
                            if (chance <= 25)
                            {
                                sorcerer.CastHeal();
                                Console.WriteLine("The Sorcerer casts a healing spell!");
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
                    // View the inventory
                    Console.WriteLine("Inventory:");
                    Console.WriteLine(player.InventoryContents());
                    Console.WriteLine();
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                else if (menuInput == "use")
                {
                    // Use an item
                }
                else if (menuInput == "run")
                {
                    // Run away
                    Random rnd = new Random();
                    int chance = rnd.Next(1, 101);
                    if (chance <= 50)
                    {
                        Console.WriteLine("You run away!");
                        Console.WriteLine("You have " + player.health + " health left!");
                        Console.WriteLine();
                        fightMenu = false;
                    }
                    else
                    {
                        Console.WriteLine("You failed to run away! You are still hurt!");
                        player = monsterAttack(player, MonsterType);
                    }
                    
                }
            }

            return player;
        }

        private Player monsterAttack(Player p, string monsterType)
        {
            p.health -= MonsterDamage;
            Console.WriteLine("You have taken " + MonsterDamage + " damage!");
            Console.WriteLine("You have " + p.health + " health left!");
            return p;
        }
    }
}