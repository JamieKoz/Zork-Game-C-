using System;

namespace CsharpCode
{
    public class PlayerFactory
    {
        static PlayerClass GetClass()
        {
            while (true)
            {
                Console.WriteLine("Please choose a class as below: ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Warrior");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" Hunter");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" Mage");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Thief");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Warriors are skilled with one handed and two handed weapons.");
                Console.WriteLine("Hunters are skilled with a bow and two handed weapons.");
                Console.WriteLine("Mages are skilled with magic and one handed weapons.");
                Console.WriteLine("Thieves are skilled with one handed weapons and bows.");

                string playerClass = Console.ReadLine().ToUpper();

                switch (playerClass)
                {
                    case "WARRIOR":
                        return PlayerClass.Warrior;
                    case "HUNTER":
                        return PlayerClass.Hunter;
                    case "MAGE":
                        return PlayerClass.Mage;
                    case "THIEF":
                        return PlayerClass.Thief;
                    default:
                        Console.WriteLine("Please type a correct class stated");
                        break;
                }
            }
        }
        static Race GetRace()
        {
            while (true)
            {
                Console.WriteLine("Please choose a race below: ");
                Console.WriteLine("Human, Orc, Elf, Dwarf");
                Console.WriteLine("Humans are skilled with one and two handed weapons.");
                Console.WriteLine("Orcs are skilled with a bow and two handed weapons.");
                Console.WriteLine("Elves are skilled with magic and one handed weapons.");
                Console.WriteLine("Dwarves are skilled with one handed weapons and bows.");

                string race = Console.ReadLine().ToUpper();

                switch (race)
                {
                    case "HUMAN":
                        return Race.Human;
                    case "ORC":
                        return Race.Orc;
                    case "ELF":
                        return Race.Elf;
                    case "DWARF":
                        return Race.Dwarf;
                    default:
                        Console.WriteLine("Please type a correct race stated");
                        break;
                }
            }
        }
        static string GetGender()
        {
            // character creation
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please choose a gender as below:");
                Console.WriteLine("Male / Female");

                string gender = Console.ReadLine().ToUpper();

                if (gender == "MALE" || gender == "FEMALE")
                {
                    return gender;
                }
                else
                {
                    Console.WriteLine("Please select a gender stated above");
                }
            }
        }
        public static Player Create()
        {
            var gender = GetGender();
            var race = GetRace();
            var playerclass = GetClass();

            return new Player(gender, race, playerclass);
        }
    }
}
