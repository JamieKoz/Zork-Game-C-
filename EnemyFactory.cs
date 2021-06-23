using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CsharpCode
{
    public class EnemyFactory
    {
        public static List<string> EnemyNames = new List<string>()
        {
            "Rat",
            "Snake",
            "Goblin",
            "Monkey",
            "Wild Dog",
            "Wild Bear",
            "Unicorn",
            "Highway man",
        };

        static Random random = new Random();

        public static Enemy Create()
        {
            int index = random.Next(EnemyNames.Count - 1);
            int EnemyHealth = random.Next(10, 20);
            string name = EnemyNames.ElementAt(index);

            return new Enemy(name, EnemyHealth);
        }
    }
}