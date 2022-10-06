using ThreadPlayground;
using Xunit.Abstractions;

namespace ThreadTests;

public class ThreadTests
{
    private readonly Creature _player;
    
    public ThreadTests(ITestOutputHelper output)
    {
        var converter = new Converter(output);
        Console.SetOut(converter);
        
        _player = new Creature("Name");
    }
    
    [Fact]
    public void Test1()
    {
        _player.Run();
        _player.Jump();
        
        Console.ReadKey();
    }
    
    [Fact]
    public void Test1Threads()
    {
        var playerRunThread = new Thread(_player.Run);
        var playerJumpThread = new Thread(_player.Jump);

        playerRunThread.Start();
        playerJumpThread.Start();
        
        Console.ReadKey();
    }
    
    [Fact]
    public void Test2ParametrizedThreads()
    {
        var playerGetFallDamageThread = new Thread(_player.GetFallDamage);
        playerGetFallDamageThread.Start(10);
        
        Console.ReadKey();
    }
    
    [Fact]
    public void Test3MultipleParametrizedThreads()
    {
        var getHealingPoisonsThread = new Thread(_player.GetHealingPoisons);
        var healingParameters = new[] {10, 1};
        getHealingPoisonsThread.Start(healingParameters);
        
        Console.ReadKey();
    }
    
    [Fact]
    public void Test4()
    {
        for (int i = 0; i < 8; i++)
        {
            Thread monster = new(_player.GetFightDamageBug);
            monster.Name = $"Монстер {i}";
            monster.Start(10);
        }
        
        Console.ReadKey();
    }
    
    [Fact]
    public void Test4Lock()
    {
        for (int i = 0; i < 8; i++)
        {
            Thread monster = new(_player.GetFightDamage);
            monster.Name = $"Монстер {i}";
            monster.Start(10);
        }
        
        Console.ReadKey();
    }
    
    [Fact]
    public void Test5()
    {
        var totalMonstersCount = 10;
        for (int i = 0; i < totalMonstersCount; i++)
        {
            Thread monster = new(_player.GetUltimateDamageBug);
            monster.Name = $"Монстер {i}";
            monster.Start(totalMonstersCount);
        }
            
        Console.ReadKey();
    }
    
    [Fact]
    public void Test5Semaphore()
    {
        var totalMonstersCount = 10;
        for (int i = 0; i < totalMonstersCount; i++)
        {
            Thread monster = new(_player.GetUltimateDamage);
            monster.Name = $"Монстер {i}";
            monster.Start(totalMonstersCount);
        }
            
        Console.ReadKey();
    }
}