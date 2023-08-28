using Microsoft.AspNetCore.SignalR.Client;

namespace PrimeSieve
{
    internal class Program
    {
        // Sieve of Eratosthenes
        // Code source: https://gist.github.com/mcmullm2-dcu/648f08f3c4e96e368cbf7f4c47e0cb74

        //const string SIGNALR_ENDPOINT = "http://localhost:5049/primesHub";
        const string SIGNALR_ENDPOINT = "https://localhost:7159/primesHub";

        public static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl(SIGNALR_ENDPOINT)
                .Build();

            // Start the connection
            await connection.StartAsync();

            await connection.InvokeAsync("SendMessage", "ConsoleApp", "Hello from the console app!");

            await RunSieveAsync(connection);
        }

        public static async Task RunSieveAsync(HubConnection connection)
        {
            const int MAX = 100000;
            // Create an array of boolean values indicating whether a number is prime.
            // Start by assuming all numbers are prime by setting them to true.
            bool[] primes = new bool[MAX + 1];
            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }

            // Loop through a portion of the array (up to the square root of MAX). If
            // it's a prime, ensure all multiples of it are set to false, as they
            // clearly cannot be prime.
            for (int i = 2; i < Math.Sqrt(MAX) + 1; i++)
            {
                if (primes[i - 1])
                {
                    for (int j = (int)Math.Pow(i, 2); j <= MAX; j += i)
                    {
                        primes[j - 1] = false;
                    }
                }
            }

            // Output the results
            int count = 0;
            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i - 1])
                {
                    Console.WriteLine(i);
                    await connection.InvokeAsync("SendPrimeSieveResults", i.ToString());
                    count++;
                }
            }

            var endResult = $"There are {count} primes up to {MAX}";
            Console.WriteLine(endResult);
            await connection.InvokeAsync("SendPrimeSieveResults", endResult);
        }
    }
}