using System;

using CsharpCode.Items;

namespace CsharpCode
{
    public class Player
    {
        public Race PlayerRace { get; set; }
        public string Gender { get; set; }
        public PlayerClass playerClass { get; set; }

        public int OneHandedWeapon { get; set; } = 0;
        public int TwoHandedWeapon { get; set; } = 0;
        public int Bows { get; set; } = 0;
        public int Magic { get; set; } = 0;
        public int PlayerHealthPoints { get; set; } = 10;
        public int PlayerManaPoints { get; set; } = 10;
        public int Level { get; set; } = 1;


        public Player(string gender, Race race, PlayerClass playerClass)
        {
            this.PlayerRace = race;
            this.Gender = gender;
            this.playerClass = playerClass;
            InitialisePlayerAttributes();
        }

        public void LevelUpAllStats()
        {
            Bows++;
            TwoHandedWeapon++;
            OneHandedWeapon++;
            Magic++;
            PlayerHealthPoints += 5;
            PlayerManaPoints += 5;
            Level++;

        }

        public bool IsAlive()
        {
            return (PlayerHealthPoints > 0);
        }

        private void InitialisePlayerAttributes()
        {
            switch (playerClass)
            {
                case PlayerClass.Warrior:
                    OneHandedWeapon += 1;
                    TwoHandedWeapon += 1;
                    Magic += 0;
                    Bows += 0;
                    PlayerHealthPoints += 10;
                    PlayerManaPoints += 10;
                    break;
                case PlayerClass.Hunter:
                    OneHandedWeapon += 0;
                    TwoHandedWeapon += 1;
                    Magic += 0;
                    Bows += 1;
                    PlayerHealthPoints += 10;
                    PlayerManaPoints += 10;
                    break;
                case PlayerClass.Mage:
                    OneHandedWeapon += 1;
                    TwoHandedWeapon += 0;
                    Magic += 1;
                    Bows += 0;
                    PlayerHealthPoints += 10;
                    PlayerManaPoints += 10;
                    break;
                case PlayerClass.Thief:
                    OneHandedWeapon += 1;
                    TwoHandedWeapon += 0;
                    Magic += 0;
                    Bows += 1;
                    PlayerHealthPoints += 10;
                    PlayerManaPoints += 10;
                    break;
                default:
                    throw new System.Exception("Player class does not Exist!");
            }
            switch (PlayerRace)
            {
                case Race.Human:
                    OneHandedWeapon += 1;
                    TwoHandedWeapon += 1;
                    Magic += 0;
                    Bows += 0;
                    PlayerHealthPoints += 10;
                    PlayerManaPoints += 10;
                    break;
                case Race.Orc:
                    OneHandedWeapon += 0;
                    TwoHandedWeapon += 1;
                    Magic += 0;
                    Bows += 1;
                    break;
                case Race.Elf:
                    OneHandedWeapon += 1;
                    TwoHandedWeapon += 0;
                    Magic += 0;
                    Bows += 1;
                    PlayerHealthPoints += 10;
                    PlayerManaPoints += 10;
                    break;

                case Race.Dwarf:
                    OneHandedWeapon += 1;
                    TwoHandedWeapon += 0;
                    Magic += 1;
                    Bows += 0;
                    PlayerHealthPoints += 10;
                    PlayerManaPoints += 10;
                    break;
                default:
                    throw new System.Exception("Player Race does not exist!");
            }
        }
        public void ListStats()
        {
            Console.WriteLine($"You are Level {Level}.");
            Console.WriteLine($"Your One handed weapon skill is {OneHandedWeapon}.");
            Console.WriteLine($"Your Two handed weapon skill is {TwoHandedWeapon}.");
            Console.WriteLine($"Your Bow weapon skill is {Bows}.");
            Console.WriteLine($"Your Magic skill is {Magic}.");
            Console.WriteLine($"Your Health is {PlayerHealthPoints}.");
            Console.WriteLine($"Your Mana is {PlayerManaPoints}.");
        }
        public void InitialisePlayerLevelUp()
        {
            ListStats();
            LevelUpAllStats();
        }

        public void Consume(Potion potion)
        {
            PlayerManaPoints += potion.HealthRestoreValue;
        }

    }
}

