using System;
using System.Collections.Generic;

using CsharpCode.Items;

namespace CsharpCode
{
    class Program
    {
        public static Player P;

        static void Main(string[] args)
        {   // entry point of the game 

            Console.WriteLine("Welcome to Jamie's Game! Press enter to start.");
            Console.ReadLine();

            // player is introduced
            P = PlayerFactory.Create();


            //readying up objects
            var snake = new Enemy("Snake", health: 15);

            // var ratHunterQuest = new Quest("Rat Hunter", "Kill 3 Rats", taskCounter: 3, P);

            var battle = new Battle(P, snake);

            List<Item> inventory = new List<Item>();

            Weapon longsword = new Weapon("Longsword", 2, WeaponType.TwoHanded);
            Weapon woodenStaff = new Weapon("Wooden Staff", 2, WeaponType.Staff);
            Weapon Crossbow = new Weapon("Crossbow", 2, WeaponType.Bow);
            Weapon hatchet = new Weapon("Hatchet", 2, WeaponType.OneHanded);
            Gold gold100 = new Gold(100);

            var healthPotion = new Potion(restoreValue: 10);
            var damagePotion = new Potion(restoreValue: -10);
            var randomQuest = QuestFactory.Generate(P);

            inventory.Add(new Junk());
            inventory.Add(hatchet);
            inventory.Add(longsword);
            inventory.Add(woodenStaff);
            inventory.Add(Crossbow);
            inventory.Add(new Junk());
            inventory.Add(healthPotion);
            inventory.Add(damagePotion);




            // game execution
            Console.Clear();
            P.ListStats();
            Console.WriteLine("You suddenly fall from the sky and land into a patch of grass. To your misfortune it looks as though you have disturbed a snakes nest. Prepare yourself for battle!");
            battle.StartBattle(); //battle with snake
            Console.WriteLine("You quickly create an inventory out of the snake's skin.");
            P.LevelUpAllStats();

            Controls(inventory, P, healthPotion, damagePotion);
            Console.ReadLine();
            Console.WriteLine("A strange man approaches you..");

            randomQuest.StartQuest();
            if (randomQuest.TaskCounter == 0)
            {
                inventory.Add(gold100);
                gold100.PrintGoldClaimed();
                P.LevelUpAllStats();
            }
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.ReadLine();

        }
        static void Controls(List<Item> inventory, Player P, Potion healthPotion, Potion damagePotion)
        {
            while (true)
            {
                Console.WriteLine("Your inventory may be accessed by typing 'bag'");
                Console.WriteLine("You can drink potions by typing 'drink healthpotion.'");
                Console.WriteLine("You may view your stats by typing 'stats'.");
                Console.WriteLine("You may view these controls at any time by typing 'controls'.");
                Console.WriteLine("Type 'exit' to cancel out of options.");

                string controls = Console.ReadLine().ToUpper();

                switch (controls)
                {
                    case "BAG":
                        Console.WriteLine("You have the following items in your inventory.");
                        foreach (Item item in inventory)
                        { Console.WriteLine(" -" + item.Name); }
                        break;
                    case "DRINK HEALTHPOTION":
                        P.Consume(healthPotion);
                        break;
                    case "DRINK DAMAGEPOTION":
                        P.Consume(damagePotion);
                        break;
                    case "STATS":
                        P.ListStats();
                        break;
                    case "EXIT":
                        break;
                    default:
                        Console.ReadLine();
                        break;
                }
                break;
            }

        }
    }
}

