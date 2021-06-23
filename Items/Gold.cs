using System;
namespace CsharpCode.Items

{
    public class Gold : Item
    {
        public int gold { get; set; } = 0;

        public Gold(int Gold)
        {
            gold = Gold;
        }
        public void PrintGoldClaimed()
        {
            Console.WriteLine($"You got {gold} pieces of Gold.");
        }
    }
}



