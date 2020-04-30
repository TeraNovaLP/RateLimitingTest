using System;
using System.Threading.Tasks;
using RestSharp;

namespace RateLimitingTest
{
    class Program
    {
        private static int successfulRequests;
        private static int errorRequests;

        static void Main(string[] args)
        {
            Console.Write("Target Url (Must start with http:// or https://): ");
            var targetUrl = Console.ReadLine();

            Console.Write("How many Requests?: ");
            var count = Convert.ToInt32(Console.ReadLine());

            if (!string.IsNullOrEmpty(targetUrl) && count > 0)
            {
                TestLimiting(targetUrl, count);
            }

            Console.WriteLine($"Successful requests: {successfulRequests}");
            Console.WriteLine($"Failed requests: {errorRequests}");

            Console.WriteLine("Finished!");
            Console.ReadLine();
        }

        private static void TestLimiting(string targetUrl, int count)
        {
            var requestTasks = new Task[count];

            for (var i = 0; i < count; i++)
            {
                requestTasks[i] = ExecuteRequest(targetUrl);
            }

            Task.WaitAll(requestTasks);

            // Cleanup
            for (var i = 0; i < count; i++)
            {
                requestTasks[i].Dispose();
            }
        }

        private static async Task ExecuteRequest(string targetUrl)
        {
            var client = new RestClient(targetUrl);
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine(response.StatusCode);
                successfulRequests += 1;
            }
            else
            {
                Console.WriteLine(response.StatusCode);
                errorRequests += 1;
            }
        }
    }
}
