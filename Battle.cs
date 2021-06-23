using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CsharpCode
{
    public class Battle
    {
        public Player Player { get; }
        public Enemy Enemy { get; }
        public Battle(Player player, Enemy enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
        }

        public void StartBattle()
        {
            PrintBattleOptionsMenu();

            while (Enemy.IsAlive() && Player.IsAlive())
            {
                PlayersTurn();
                EnemyTurn();
            }

            DetermineOutcomeOfBattle();
        }

        private void PrintBattleOptionsMenu()
        {
            System.Console.WriteLine($"Your Health is at {Player.PlayerHealthPoints} Points and Mana is at {Player.PlayerManaPoints} Points.");
            System.Console.WriteLine("Enter the number for the type of attack you would like to perform: ");
            System.Console.WriteLine("1. One Handed");
            System.Console.WriteLine("2. Two Handed");
            System.Console.WriteLine("3. Magic Spell");
            System.Console.WriteLine("4. Bow Attack");
        }

        private void PlayersTurn()
        {
            int userSelectedAttackType = ParseUserAttackType();
            int skillLevel = DetermineSkillLevelByAttackType(userSelectedAttackType);
            int damage = DetermineDamage(skillLevel);
            Enemy.ApplyDamage(damage);
            Console.WriteLine($"You hit the {Enemy.Name} for {damage} damage!");
        }

        private int ParseUserAttackType()
        {
            while (true)
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine()); ;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid number. For example 1, 2, 3, 4");
                }
            }
        }

        private int DetermineSkillLevelByAttackType(int userAttackType)
        {
            switch (userAttackType)
            {
                case 1:
                    return Player.OneHandedWeapon;
                case 2:
                    return Player.TwoHandedWeapon;
                case 3:
                    return Player.Magic;
                case 4:
                    return Player.Bows;
                default:
                    throw new Exception("Invalid option selected.");
            }
        }

        private int DetermineDamage(int skillLevel, int maxDamage = 10)
        {
            Random random = new Random();
            int dmgRoll = random.Next(0, maxDamage);
            int totalDamage = dmgRoll + skillLevel;
            return totalDamage;
        }

        private void EnemyTurn()
        {
            if (!Enemy.IsAlive())
            {
                return;
            }
            int enemyDamage = DetermineDamage(skillLevel: 0, maxDamage: 5);
            Console.WriteLine($"The {Enemy.Name} strikes back for {enemyDamage} damage!");
            Player.PlayerHealthPoints = Player.PlayerHealthPoints - enemyDamage;
        }

        private void DetermineOutcomeOfBattle()
        {
            if (!Enemy.IsAlive())
            {
                Console.WriteLine($"You have defeated the {Enemy.Name}!");
                return;
            }
            Console.WriteLine("Oh Dear! You have died!");
        }
    }
}
