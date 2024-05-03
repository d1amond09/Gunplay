using Gunplay.DAL.Interfaces;
using Gunplay.DAL.Repositories;
using Gunplay.Domain;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Shells;
namespace Gunplay.DAL;

public abstract class ShellFactory
{
	public abstract BasicShell Create(Player player);
}
