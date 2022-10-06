namespace TaskPlayground
{
    public class Creature
    {
        public Creature(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Hp { get; set; } = 100;
        public int Experience { get; set; } = 0;
        
        public void Run(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{Name} бежит {i} метров, осталось {count-i}");
                Thread.Sleep(200);
            }
        }

        public void DoQuest(string questName)
        {
            Console.WriteLine($"Выполняю квест {questName}");
            Thread.Sleep(800);
            var experience = new Random().Next(100, 800);
            Experience += experience;
            Console.WriteLine($"Квест {questName} выполнен, получено {experience} опыта, всего опыта {Experience}");
        }

        public int RollDice()
        {
            return new Random().Next(1, 20);
        }
    }
}