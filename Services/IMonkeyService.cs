using Svero.MonkeysInCsharp.Models;

namespace Svero.MonkeysInCsharp.Services;

/// <summary>
/// Defines the methods a service for monkeys has to
/// provide.
/// <summary>
public interface IMonkeyService {
	/// <summary>
	/// Returns a collection of available monkeys.
	/// </summary>
    Task<ICollection<Monkey>> GetMonkeysAsync();

	/// <summary>
	/// Returns a collection with monkeys with the
	/// matching name. This collection can be empty.
	/// </summary>
    Task<ICollection<Monkey>> FindByNameAsync(string name);
}