using System.Net.Http.Json;
using Svero.HelloWorld.Models;

namespace Svero.HelloWorld.Services;

/// <summary>
/// Implements a monkey service using a JSON-based
/// collection of monkeys hosted on GitHub.
/// </summary>
public class GitHubMonkeyService : IMonkeyService
{
    const string URL = "https://www.montemagno.com/monkeys.json";

    List<Monkey> _monkeys = [];

    public ICollection<Monkey> FindByName(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Monkey>> GetMonkeys()
    {
        if (_monkeys?.Count > 0)
        {
            return _monkeys;
        }

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
        
        return _monkeys ?? [];
    }
}