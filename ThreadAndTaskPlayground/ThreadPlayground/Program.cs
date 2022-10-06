namespace ThreadPlayground
{
    internal class Program
    {
        static void Main()
        {
            var player = new Creature("Name");

            var playerRunThread = new Thread(player.Run);
            var playerJumpThread = new Thread(player.Jump);

            playerRunThread.Start();
            playerJumpThread.Start();
            
            var playerGetFallDamageThread = new Thread(player.GetFallDamage);
            playerGetFallDamageThread.Start(10);


            var getHealingPoisonsThread = new Thread(player.GetHealingPoisons);
            var healingParameters = new[] {10, 1};
            getHealingPoisonsThread.Start(healingParameters);
            

            for (int i = 0; i < 8; i++)
            {
                Thread monster = new(player.GetFightDamage);
                monster.Name = $"Монстер {i}";
                monster.Start(10);
            }

            var totalMonstersCount = 5;
            for (int i = 0; i < totalMonstersCount; i++)
            {
                Thread monster = new(player.GetUltimateDamage);
                monster.Name = $"Монстер {i}";
                monster.Start(totalMonstersCount);
            }
            
            Console.ReadKey();
        }
    }
}