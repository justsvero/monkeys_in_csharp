using Svero.MonkeysInCsharp.Services;

namespace Svero.MonkeysInCsharp;

public class Program
{
    public static async Task Main(string[] args)
    {
        var monkeyService = new GitHubMonkeyService();

        var monkeys = await monkeyService.GetMonkeysAsync();
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