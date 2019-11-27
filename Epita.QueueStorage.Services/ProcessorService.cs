using System;
using System.Threading.Tasks;
using Epita.QueueStorage.Services.Contracts;

namespace Epita.QueueStorage.Services
{
    /// <summary>
    /// DO NOT REMOVE OR EDIT
    /// </summary>
    public class ProcessorService : IProcessorService
    {
        public Task ProcessAsync(string userId)
        {
            char id = userId[userId.Length - 1];

            return ComputeAsync(id);
        }

        private static Task ComputeAsync(char id) => id switch
        {
            '1' => Task.Delay(1000),
            '2' => Task.Delay(5000),
            '3' => Task.Delay(10000),
            '4' => Task.Delay(30000),
            '5' => Task.Delay(70000),
            '6' => Task.Delay(new Random().Next(60000, 190000)),
            _ => throw new ArgumentException(message: "id", paramName: nameof(id)),
        };
    }
}