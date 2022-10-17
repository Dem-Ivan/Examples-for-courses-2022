using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsynkAvaitTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int workerThreads;
            int completionPortThreads;

            ThreadPool.SetMaxThreads(10, 10);
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
          
            WritevithCollor($" workerThreads = {workerThreads}, completionPortThreads = {completionPortThreads}", ConsoleColor.White);

            for (int i = 0; i < 15; i++)
            {
                //await CreateTaskAsynk(i);
                CreateTask(i);
                Thread.Sleep(1000);

                ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
                WritevithCollor($"Итерация {i} workerThreads = {workerThreads}, completionPortThreads = {completionPortThreads}", ConsoleColor.White);
            }

            Task.Delay(200000).Wait();   
        }

        public static Task CreateTask(int i)
        {
            return Task.Run(() => 
            {
                WritevithCollor($"Создана новая задача №{i}", ConsoleColor.Red);

                Thread.Sleep(20000);

                WritevithCollor($"Завершена №{i}", ConsoleColor.Green);

                ThreadPool.GetAvailableThreads(out var workerThreads, out var completionPortThreads);
                WritevithCollor($"Количество потоков после выполнения задачи workerThreads = {workerThreads}, completionPortThreads = {completionPortThreads}", ConsoleColor.White);
            });
        }

        public static Task CreateTaskAsynk(int i)
        {
            return Task.Run(() => 
            {                
                WritevithCollor($"Создана новая задача №{i}", ConsoleColor.Red);
               
                Thread.Sleep(2000);

                WritevithCollor($"Завершена №{i}", ConsoleColor.Green);
                ThreadPool.GetAvailableThreads(out var workerThreads, out var completionPortThreads);
                WritevithCollor($"Количество потоков после выполнения задачи workerThreads = {workerThreads}, completionPortThreads = {completionPortThreads}", ConsoleColor.White);
            });
        }

        private static void WritevithCollor(string text, ConsoleColor color)
        {
            //Console.ForegroundColor = color;             
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;           
        }
    }
}
