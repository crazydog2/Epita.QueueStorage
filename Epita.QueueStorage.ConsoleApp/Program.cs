using System;
using System.Threading.Tasks;

namespace Epita.QueueStorage.ConsoleApp
{
    class Program
    {
        #region ConnectionString

        private static string connectionString = "";

        #endregion

        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting ...");

            var queueService = new QueueService(connectionString);

            string message = await queueService.DequeueMessageAsync("queueepita").ConfigureAwait(false);

            Console.WriteLine(message);

            Console.WriteLine("Press [Enter] to exit");
            Console.ReadLine();
        }
    }
}