namespace ThreadPlayground
{
    public class Creature
    {
        public Creature(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Hp { get; set; } = 100;

        public void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Name} бежит");
                Thread.Sleep(200);
            }
        }

        public void Jump()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Name} прыгает");
                Thread.Sleep(200);
            }
        }

        public void GetFallDamage(object? count)
        {
            int fallDamageCount = (int) (count ?? 0);
            Hp += fallDamageCount;
            Console.WriteLine($"{Name} упал с высоты и потерял {fallDamageCount} здоровья, общее здоровье теперь {Hp}");
        }

        public void GetHealingPoisons(object? parameters)
        {
            if (parameters != null)
            {
                var healingCountTyped = (int[]) parameters;

                for (int i = 0; i < healingCountTyped[0]; i++)
                {
                    Hp += healingCountTyped[1];
                    Console.WriteLine($"{Name} выпил зелье и прибавил {healingCountTyped[1]} здоровья, общее здоровье теперь {Hp}");
                }
            }
        }

        public void GetFightDamageBug(object? damageCount)
        {
            int damageCountTyped = (int) (damageCount ?? 0);
            for (int i = 0; i < 100; i++)
            {
                Hp -= damageCountTyped;
                if (Hp <= 0)
                {
                    break;
                }

                Console.WriteLine($"{Name} подрался с {Thread.CurrentThread.Name} и получил {damageCountTyped} урона, общее здоровье теперь {Hp}");
            }
        }

        public void GetFightDamage(object? damageCount)
        {
            object damageLocker = new();

            lock (damageLocker)
            {
                int damageCountTyped = (int) (damageCount ?? 0);
                for (int i = 0; i < 100; i++)
                {
                    Hp -= damageCountTyped;
                    if (Hp <= 0)
                    {
                        break;
                    }

                    Console.WriteLine($"{Name} подрался с {Thread.CurrentThread.Name} и получил {damageCountTyped} урона, общее здоровье теперь {Hp}");
                }
            }
        }

        public void GetUltimateDamageBug(object? monstersCount)
        {
            
            var count = (int) (monstersCount ?? 0);
            while (count > 0)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} противник входит в область поражения");

                Console.WriteLine($"В ОБЛАСТИ ПОРАЖЕНИЯ ПРОТИВНИКОВ: {count}");

                Console.WriteLine($"{Thread.CurrentThread.Name} получает критический урон");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} падает без сознания");

                count--;
            }
        }
        
        public void GetUltimateDamage(object? monstersCount)
        {
            var damageSemaphore = new Semaphore(4, 4);

            var count = (int) (monstersCount ?? 0);
            while (count > 0)
            {
                damageSemaphore.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} противник входит в область поражения");

                Console.WriteLine($"В ОБЛАСТИ ПОРАЖЕНИЯ ПРОТИВНИКОВ: {count}");

                Console.WriteLine($"{Thread.CurrentThread.Name} получает критический урон");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} падает без сознания");

                damageSemaphore.Release();

                count--;
            }
        }
    }
}