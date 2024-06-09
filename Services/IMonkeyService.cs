using Svero.HelloWorld.Models;

namespace Svero.HelloWorld.Services;

public interface IMonkeyService {
    Task<ICollection<Monkey>> GetMonkeys();

    ICollection<Monkey> FindByName(string name);
}