namespace TaskPlayground
{
    internal class Program
    {
        static void Main()
        {
            var player = new Creature("Name");
            
            
            var simpleRunTask = new Task(() => player.Run(10));
            simpleRunTask.Start();
            
            var simpleOneStringRunTask = Task.Run(() => player.Run(10));
            
            var simpleFactoryRunTask = Task.Factory.StartNew(() => player.Run(10));

            var questTask1 = Task.Factory.StartNew(() => player.DoQuest("Пройти уровень", 10));
            var questTask2 = Task.Factory.StartNew(() => player.DoQuest("Победить босса", 20));
            var questTask3 = Task.Factory.StartNew(() => player.DoQuest("Спасти принцессу", 30));
            var questTask4 = Task.Factory.StartNew(() => player.DoQuest("Забрать сокровища", 40));
            questTask1.Wait();
            questTask2.Wait();
            questTask3.Wait();
            questTask4.Wait();
            
            var questTaskSync1 = new Task(() => player.DoQuest("Пройти уровень", 10));
            var questTaskSync2 = new Task(() => player.DoQuest("Победить босса", 20));
            var questTaskSync3 = new Task(() => player.DoQuest("Спасти принцессу", 30));
            var questTaskSync4 = new Task(() => player.DoQuest("Забрать сокровища", 40));
            questTaskSync1.RunSynchronously();
            questTaskSync2.RunSynchronously();
            questTaskSync3.RunSynchronously();
            questTaskSync4.RunSynchronously();
            
            Console.WriteLine("Уроверь пройден!");
            
            
            var prepareToBossTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Подготовка к боссу");
                var armorTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Кузнец куёт броню");
                    Thread.Sleep(800);
                    Console.WriteLine("Броня готова");
                });
                
                var poisonTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Алхимик делает зелья");
                    Thread.Sleep(800);
                    Console.WriteLine("Зелья готовы");
                });
                
                var spellTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Волшебник делает свитки");
                    Thread.Sleep(800);
                    Console.WriteLine("Свитки готовы");
                });
            });

            prepareToBossTask.Wait();
            
            Console.WriteLine("К боссу готовы!");

            var boss = new Creature("Boss");
            
            Task<bool> bossFight = new Task<bool>(() =>
            {
                Console.WriteLine("Бой с боссом начался!");
                
                CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                CancellationToken token = cancelTokenSource.Token;
                
                var isVictory = false;
                
                var fightTask = Task.Factory.StartNew(() =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        if (player.RollDice() > boss.RollDice())
                        {
                            boss.Hp -= 10;
                            Console.WriteLine($"{player.Name} нанёс боссу {boss.Name} удар, у игрока осталось {player.Hp} здоровья!");
                        }
                        else
                        {
                            player.Hp -= 10;
                            Console.WriteLine($"{boss.Name} нанёс игроку {player.Name} удар, у босса осталось {player.Hp} здоровья!");
                        }
                        Thread.Sleep(100);
                    }
                });

                var victoryServiceTask = Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        if (player.Hp <= 0 && boss.Hp > 0)
                        {
                            isVictory = true;
                            break;
                        }

                        if (boss.Hp <= 0 && player.Hp > 0)
                        {
                            break;
                        }
                    }
                    cancelTokenSource.Cancel();
                });

                victoryServiceTask.Wait();

                return isVictory;
            });
            
            bossFight.Start();
            var result = bossFight.Result;
            if (result)
            {
                Console.WriteLine($"{player.Name} ПОБЕДИЛ ВСЕХ!");
            }
            else
            {
                Console.WriteLine($"{player.Name} победил чуть чуть");
            }

            Console.ReadKey();
        }
    }
}