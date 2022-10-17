namespace AsyncAwait;

public class Creature
{
    public string Name { get; set; }
    public int Hp { get; set; } = 100;

    public Creature(string name)
    {
        Name = name;
    }

    public void Eat(int count, string foodName)
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{Name} ест {i} кусок еды {foodName}, осталось {count-i}");
            Task.Delay(800).Wait();
        }
    }
    
    public async Task EatAsync(int count, string foodName)
    {
        await Task.Run(() => Eat(count, foodName));
    }
    
    public void Drink(int count, string drinkName)
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{Name} пьёт {i} глоток напитка {drinkName}, осталось {count-i}");
            Task.Delay(800).Wait();
        }
    }
    
    public async Task DrinkAsync(int count, string drinkName)
    {
        await Task.Run(() => Drink(count, drinkName));
    }
    
    public async Task<int> TavernDinnerAsync(int count, string foodName, string drinkName)
    {
        int payment = 0;
        
        var eatTask =  Task.Run(() => Eat(count, foodName));
        
        var drinkTask = Task.Run(() => Drink(count, drinkName));

        await eatTask;
        payment += 10;

        await drinkTask;
        payment += 10;

        return payment;
    }
}