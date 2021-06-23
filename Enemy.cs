namespace CsharpCode
{
    public class Enemy
    {
        public string Name { get; }
        public int Health { get; private set; }

        public Enemy(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public bool IsAlive()
        {
            return (Health > 0);
        }

        public void ApplyDamage(int damage)
        {
            Health -= damage;
        }

    }
}