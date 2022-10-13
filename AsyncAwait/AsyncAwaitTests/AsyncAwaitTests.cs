using System.Diagnostics;
using AsyncAwait;
using Xunit.Abstractions;

namespace AsyncAwaitTests;

public class AsyncAwaitTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Creature _player;

    public AsyncAwaitTests(ITestOutputHelper testOutputHelper)
    {
        var converter = new Converter(testOutputHelper);
        Console.SetOut(converter);
        
        _testOutputHelper = testOutputHelper;
        _player = new Creature("Name");
    }

    [Fact]
    public void Test1OneSync()
    {
        _player.Eat(10, "Meet");
        _player.Drink(10, "Vine");
    }
    
    [Fact]
    public void Test2MultipleSync()
    {
        var eatTask = Task.Run(() => _player.Eat(10, "Meet"));
        var drinkTask = Task.Run(() => _player.Drink(10, "Vine"));
        eatTask.Wait();
        drinkTask.Wait();
    }
    
    [Fact]
    public async Task Test3MultipleAsync()
    {
        var sw = new Stopwatch();
        sw.Start();
        await _player.EatAsync(10, "Meet");
        await _player.DrinkAsync(10, "Vine");
        sw.Stop();
        
        _testOutputHelper.WriteLine(sw.ElapsedMilliseconds.ToString());
    }
    
    [Fact]
    public async Task Test4MultipleAsyncOptimization()
    {
        var sw = new Stopwatch();
        sw.Start();
        
        var eatTask = _player.EatAsync(10, "Meet");
        var drinkTask = _player.DrinkAsync(10, "Vine");

        await eatTask;
        await drinkTask;
        
        sw.Stop();
        
        _testOutputHelper.WriteLine(sw.ElapsedMilliseconds.ToString());
    }
    
    [Fact]
    public async Task Test5AwaitPrimitives()
    {
        var eatTask =  _player.EatAsync(10, "Meet");
        var drinkTask = _player.DrinkAsync(10, "Vine");

        await eatTask;
        await drinkTask;

        await Task.WhenAny(eatTask, drinkTask);
        _testOutputHelper.WriteLine("Быстро перекусили");
    }
    
    [Fact]
    public async Task Test6AwaitPrimitives()
    {
        var eatTask =  _player.EatAsync(10, "Meet");
        var drinkTask = _player.DrinkAsync(10, "Vine");

        await eatTask;
        await drinkTask;

        await Task.WhenAll(eatTask, drinkTask);
        _testOutputHelper.WriteLine("Плотно поужинали");
    }
    
    [Fact]
    public async Task Test6AwaitManagement()
    {
        var payment = _player.TavernDinnerAsync(10, "Meet", "Vine");

        _testOutputHelper.WriteLine("Травим байки");
        
        _testOutputHelper.WriteLine($"Заплатили {await payment} денег");
        
        _testOutputHelper.WriteLine("Продолжаем травить байки");
    }
}