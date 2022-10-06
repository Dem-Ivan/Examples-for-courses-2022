using System.Diagnostics.CodeAnalysis;
using TaskPlayground;
using Xunit.Abstractions;

namespace TaskTests;

[SuppressMessage("ReSharper", "Xunit.XunitTestWithConsoleOutput")]
public class TaskTests
{
    private Creature _player;
    
    public TaskTests(ITestOutputHelper output)
    {
        var converter = new Converter(output);
        Console.SetOut(converter);
        
        _player = new Creature("Name");
    }
    
    [Fact]
    public void Test1Tasks()
    {
        var simpleRunTask = new Task(() => _player.Run(10));
        simpleRunTask.Start();
            
        var simpleOneStringRunTask = Task.Run(() => _player.Run(10));
            
        var simpleFactoryRunTask = Task.Factory.StartNew(() => _player.Run(10));
    }
    
    [Fact]
    public void Test2TasksWait()
    {
        var questTask1 = Task.Factory.StartNew(() => _player.DoQuest("Пройти уровень"));
        var questTask2 = Task.Factory.StartNew(() => _player.DoQuest("Победить босса"));
        var questTask3 = Task.Factory.StartNew(() => _player.DoQuest("Спасти принцессу"));
        var questTask4 = Task.Factory.StartNew(() => _player.DoQuest("Забрать сокровища"));
        questTask1.Wait();
        questTask2.Wait();
        questTask3.Wait();
        questTask4.Wait();
        
        Console.WriteLine("Уроверь пройден!");
    }
    
    [Fact]
    public void Test3RunSynchronously()
    {
        var questTaskSync1 = new Task(() => _player.DoQuest("Пройти уровень"));
        var questTaskSync2 = new Task(() => _player.DoQuest("Победить босса"));
        var questTaskSync3 = new Task(() => _player.DoQuest("Спасти принцессу"));
        var questTaskSync4 = new Task(() => _player.DoQuest("Забрать сокровища"));
        questTaskSync1.RunSynchronously();
        questTaskSync2.RunSynchronously();
        questTaskSync3.RunSynchronously();
        questTaskSync4.RunSynchronously();
        
        Console.WriteLine("Уроверь пройден!");
    }
    
    [Fact]
    public void Test3NestedTasks()
    {
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
    }

    [Fact]
    public void Test3ReturnedValueTasks()
    {
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
                        if (_player.RollDice() > boss.RollDice())
                        {
                            boss.Hp -= 10;
                            Console.WriteLine($"{_player.Name} нанёс боссу {boss.Name} удар, у игрока осталось {_player.Hp} здоровья!");
                        }
                        else
                        {
                            _player.Hp -= 10;
                            Console.WriteLine($"{boss.Name} нанёс игроку {_player.Name} удар, у босса осталось {_player.Hp} здоровья!");
                        }
                        Thread.Sleep(100);
                    }
                });

                var victoryServiceTask = Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        if (_player.Hp <= 0 && boss.Hp > 0)
                        {
                            isVictory = true;
                            break;
                        }

                        if (boss.Hp <= 0 && _player.Hp > 0)
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
                Console.WriteLine($"{_player.Name} ПОБЕДИЛ ВСЕХ!");
            }
            else
            {
                Console.WriteLine($"{_player.Name} победил чуть чуть");
            }

            Console.ReadKey();
        }
}