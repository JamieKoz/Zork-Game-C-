using System;
using System.Collections.Generic;
using System.Linq;
namespace CsharpCode
{
    public static class QuestFactory
    {
        private static Random random = new Random();

        public static Quest Generate(Player p)
        {
            var taskCount = random.Next(1, 5);
            var randomEnemy = EnemyFactory.Create();
            var name = GenerateRandomQuestName(randomEnemy);
            var taskMessage = GetRandomTaskMessage(p, randomEnemy, taskCount);

            return new Quest(name, taskMessage, taskCount, p);
        }

        private static string GenerateRandomQuestName(Enemy enemy)
        {
            var suffixes = new List<string> {
                    "Hunter",
                    "Slayer",
                    "Catcher"
                };
            int suffixIndex = random.Next(suffixes.Count - 1);
            var suffix = suffixes.ElementAt(suffixIndex);
            return enemy.Name + " " + suffix;
        }

        private static string GetRandomTaskMessage(Player player, Enemy enemy, int taskCount)
        {
            List<string> taskScenarios = new List<string>()

                {
                $"Hi there! Would you kindly kill {taskCount} {enemy.Name}? They have been wreaking havoc in my paddock!",

                $"'Scuse me, {player.playerClass}. I need a helping hand.\nIt's just a matter of time before we're surrounded. Scout reports have come in and tell of about a dozen hunting parties.\nWe need you to deal with a few of them, curse those hideous {enemy.Name}. If you think you'll need any help, I'm willing to come along.\nThey'll be no match for you, those {enemy.Name}. Make sure they regret the day they ever set foot in our lives.\nI cannot thank you enough for your help, I'll make sure to reward you greatly once you return.\nNow hurry, {player.playerClass}, there's no time to waste.",

                $"Please, {player.PlayerRace}. Your assistance is required.\nVile {enemy.Name} have crept up in our lands. Reports of attacks are trickling in slowly, but we cannot afford to sit back idly.\nThis could get out of control very quickly. Hero, seek them out and deal with those vicious {enemy.Name}.\nI had hoped I could you join, but unfortunately I cannot. But I doubt you'd need my help anyway.\nI'm sure you're capable to deal with those {enemy.Name}. There's no need to kill all of them, just put the fear in them, {taskCount} should be enough.\nI'm afraid there's not much left I can reward you with, but I think I can still make it worth your troubles.\nI hope you return swiftly hero, we believe in you.",

                $"Pardon me, {player.PlayerRace}. Help out a person in need.\nThe battle is almost over, but we can't loosen up just yet. The enemy is retreating, but we cannot let them regroup. Go out and deal with all vulgar {enemy.Name}.\nI wish I could join you, but alas I cannot. Know that I've put all my faith in you, you will succeed.\nI know it. Tread carefully {player.PlayerRace}, only a fool would underestimate the {enemy.Name}.\nTry to kill all those who stand in your way, {taskCount} should be enough, we don't need their filth in our lands.\nIt pains me to say I won't be able to reward you with a lot, but I'll do my best to make it worth your while.\nBlessed journey {player.PlayerRace}, may you return swiftly and in one piece.",

                $"You there, {player.PlayerRace}. I'm in need of your assistance.\nMy generosity has been taken advantage of. The other day I took in travelers in need of shelter, they repaid me by robbing me.\nI called for the guards and they came in time, but unfortunately they were no match. Please, hero, retrieve my goods and get rid of those terrible monsters' pets.\nI'll be coming along with you, at least, as long as you don't mind. Tread carefully hero, only a fool would underestimate the {enemy.Name}.\nKilling them all won't be needed of course, {taskCount} should be plenty to teach them a lesson.\nUnfortunately there's not much I have to reward you with, but I think there's a few bits and pieces left.\nI hope you return swiftly {player.PlayerRace}, we believe in you.",

                $"Pardon me, {player.PlayerRace}. Please, lend me your hand.\nWe've begun our assault on the citadel, but we need a few elite fighters to flank the enemy, infiltrate their armies and disable those siege engines.\nThey've proven to be far too deadly.\nIt shouldn't be hard to disguise yourself as one of them in the chaos of battle, but you will be in real danger once you destroy those engines. But I know you can handle those wretched {enemy.Name}.\nIf you don't mind, I'd like to come along. It's your choice though. You are fully capable to handle those {enemy.Name}.\nTry to take down as many of them as possible, perhaps around {taskCount}, the less of a threat they pose the better.\nShould you succeed I will be able to repay you handsomely, it'll be worth your troubles.\nNow hurry, {player.PlayerRace}, there's no time to waste."

                };
            int taskIndex = random.Next(taskScenarios.Count - 1);
            return taskScenarios.ElementAt(taskIndex);

        }

    }
}
