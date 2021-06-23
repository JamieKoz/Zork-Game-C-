using System;
using System.Collections.Generic;

namespace CsharpCode.Items
{
    public class Junk : Item
    {

        static List<string> junkItemNames = new List<string>()
        {
            "shoelaces",
            "goblin mail",
            "rusty nail",
        };

        static Random random = new Random();

        public Junk()
        {
            int index = random.Next(junkItemNames.Count);

            Name = junkItemNames[index];
        }
    }
}