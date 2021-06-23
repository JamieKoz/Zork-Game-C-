using System;
namespace CsharpCode.Items

{
    public class Potion : Item
    {
        public int HealthRestoreValue { get; }

        public Potion(int restoreValue)
        {
            HealthRestoreValue = restoreValue;

        }
    }
}



