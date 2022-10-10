using System.Diagnostics;

namespace TaskPlayground
{
    public class Creature
    {
        private object _runAndJumpLocker = new();

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
        
        public void RunBenchmark(string source)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
            }
            Console.WriteLine("Персонаж прибежал, используя " + source);
        }

        public void RunWithExperienceBug(int count, int experience)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{Name} бежит {i} метров, осталось {count-i}");
                Thread.Sleep(200);
            }

            Experience += experience;
            Console.WriteLine($"За  бег получено {experience} очков опыта, всего опыта {Experience}");
        }
        
        
        public void RunWithExperience(int count, int experience)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{Name} бежит {i} метров, осталось {count-i}");
                Thread.Sleep(200);
            }

            lock(_runAndJumpLocker)
            {
                Experience += experience;
                Console.WriteLine($"За  бег получено {experience} очков опыта, всего опыта {Experience}");
            }
        }
        public void Jump(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{Name} прыгает {i} раз, осталось {count-i}");
                Thread.Sleep(200);
            }
        }
        
        public void JumpWithExperienceBug(int count, int experience)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{Name} прыгает {i} раз, осталось {count-i}");
                Thread.Sleep(200);
            }
            Experience += experience;
            Console.WriteLine($"За  прыжки получено {experience} очков опыта, всего опыта {Experience}");
        }
        
        public void JumpWithExperience(int count, int experience)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{Name} прыгает {i} раз, осталось {count-i}");
                Thread.Sleep(200);
            }

            lock (_runAndJumpLocker)
            {
                Experience += experience;
                Console.WriteLine($"За  прыжки получено {experience} очков опыта, всего опыта {Experience}");
            }
        }

        public void DoQuest(string questName, int experience)
        {
            Console.WriteLine($"Выполняю квест {questName}");
            Thread.Sleep(800);
            Experience += experience;
            Console.WriteLine($"Квест {questName} выполнен, получено {experience} опыта, всего опыта {Experience}");
        }

        public int RollDice()
        {
            return new Random().Next(1, 20);
        }
    }
}