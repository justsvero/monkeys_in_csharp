using System.Net.Http.Json;
using Svero.HelloWorld.Models;

namespace Svero.HelloWorld
{
    public class Program {
        const string URL = "https://www.montemagno.com/monkeys.json";

        public static async Task Main(string[] args) {
            var client = new HttpClient();

            try {
            var response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode) {
                var monkeys = await response.Content.ReadFromJsonAsync<List<Monkey>>();
                if (monkeys?.Count > 0) {
                    Console.WriteLine($"Number of monkeys found: {monkeys.Count}");

                    foreach (var monkey in monkeys)
                    {
                        Console.WriteLine($"=> Monkey: {monkey?.Name}");
                    }
                }
            } else {
                Console.Error.WriteLine($"The server has returned an unexpected status code: {response.StatusCode}");
            }
            } catch (Exception e) {
                Console.Error.WriteLine($"An error occurred: {e.Message}");
            }
        }
    }
}