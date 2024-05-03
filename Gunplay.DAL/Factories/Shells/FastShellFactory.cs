using Gunplay.DAL.Interfaces;
using Gunplay.DAL.Repositories;
using Gunplay.Domain;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Shells;
namespace Gunplay.DAL;

public class FastShellFactory : ShellFactory
{
	public FastShellFactory()
	{

	}

	public override FastShell Create(Player player)
	{
		Rectangle basicShellRctngl = new([.. player.Canoon.Bolt.Rectangle.Coordinates]);
		FastShell shell = new(basicShellRctngl, @"data\img\shell.png");
		player.Canoon.Shells.Add(shell);
		return shell;
	}
}
