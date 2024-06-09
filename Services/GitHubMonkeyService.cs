using System.Net.Http.Json;
using Svero.MonkeysInCsharp.Models;

namespace Svero.MonkeysInCsharp.Services;

/// <summary>
/// Implements a monkey service using a JSON-based
/// collection of monkeys hosted on GitHub.
/// </summary>
public class GitHubMonkeyService : IMonkeyService
{
    const string URL = "https://www.montemagno.com/monkeys.json";

    List<Monkey> _monkeys = [];

    private async Task Refresh() {
        var client = new HttpClient();

        try
        {
            var response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                var monkeys = await response.Content.ReadFromJsonAsync<List<Monkey>>();
                if (monkeys?.Count > 0) {
                    _monkeys = monkeys;
                }
            }
            else
            {
                Console.Error.WriteLine($"The server has returned an unexpected status code: {response.StatusCode}");
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"An error occurred: {e.Message}");
        }
        
    }

    public async Task<ICollection<Monkey>> FindByNameAsync(string name)
    {
        if (_monkeys?.Count == 0) {
            await Refresh();
        }

        return _monkeys?.FindAll(m => string.Equals(m.Name, name, StringComparison.InvariantCultureIgnoreCase)) ?? [];
    }

    public async Task<ICollection<Monkey>> GetMonkeysAsync()
    {
        if (_monkeys?.Count > 0)
        {
            return _monkeys;
        }

        await Refresh();

        return _monkeys ?? [];
    }
}