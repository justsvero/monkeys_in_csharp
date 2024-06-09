using Svero.HelloWorld.Services;

namespace Svero.HelloWorld;

public class Program
{
    public static async Task Main(string[] args)
    {
        var monkeyService = new GitHubMonkeyService();

        var monkeys = await monkeyService.GetMonkeys();
        if (monkeys?.Count > 0)
        {
            Console.WriteLine($"Found {monkeys.Count} monkey(s)");
        }
        else
        {
            Console.WriteLine("No monkeys found");
        }
    }
}