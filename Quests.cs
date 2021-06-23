using System;

using System.Text;

namespace CsharpCode
{
    public class Quest
    {
        public string Name { get; set; }
        public string Task { get; set; }
        public int TaskCounter { get; set; } = 0;
        public Player P { get; }
        public Enemy randEnemy;

        public Quest(string name, string task, int taskCounter, Player player)
        {
            Name = name;
            Task = task;
            TaskCounter = taskCounter;
            P = player;
        }

        public void PrintIntroduction()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendJoin(Environment.NewLine,
            "Greetings traveller! I saw you come from the sky just now!",
            "How strange! What is more strange are these rats in my home...",
            $"you wouldn't happen to be a {P.playerClass} would you?",
            "If you kill these rats I'll generously reward you!");

            Console.WriteLine(sb);
        }

        public void StartQuestBattles()
        {

            while (TaskCounter > 0)
            {
                var enemyRat = new Enemy("Rat", health: 15);
                var battle = new Battle(P, enemyRat);

                battle.StartBattle();
                TaskCounter--;
            }
        }
        public void Complete()
        {
            if (TaskCounter == 0)
            {
                Console.WriteLine("Wow! I can't believe you killed all those rats on your own!\nPlease take this gold as a token of my appreciation.");
            }
        }
        public void StartQuest()
        {
            PrintIntroduction();
            AcceptOrDeclineQuest();
        }
        public void AcceptOrDeclineQuest()
        {
            Console.WriteLine("Do you want to accept start this quest? Y/N");
            string readKey = Console.ReadLine().ToUpperInvariant();
            if (readKey == "Y" || readKey == "YES")
            {
                StartQuestBattles();
                Complete();
            }
            else
            {
                Console.WriteLine("You turn them down and continue about your day.");
                Console.ReadLine();
            }
        }
    }
}