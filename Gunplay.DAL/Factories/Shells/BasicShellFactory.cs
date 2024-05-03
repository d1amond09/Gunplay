using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Shells;

namespace Gunplay.DAL.Repositories;

public class BasicShellFactory : ShellFactory
{
    public BasicShellFactory()
    {
        
    }

    public override BasicShell Create(Player player)
	{
		Rectangle basicShellRctngl = new([.. player.Canoon.Bolt.Rectangle.Coordinates]);
		BasicShell shell = new(basicShellRctngl, @"data\img\shell.png");
		player.Canoon.Shells.Add(shell);
		return shell;
	}
}
