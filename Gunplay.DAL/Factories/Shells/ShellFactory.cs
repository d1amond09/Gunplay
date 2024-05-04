using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Shells;
namespace Gunplay.DAL;

public abstract class ShellFactory
{
	public abstract Shell Create(Player player);
}
