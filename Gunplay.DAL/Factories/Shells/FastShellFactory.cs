using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Shells;

namespace Gunplay.Creation.Factories.Shells;

public class FastShellFactory(int damageCount, int reloadSpeedCount) : ShellFactory(damageCount, reloadSpeedCount)
{
	protected override string TexturePath => @"data\img\fastShell.png";
	public override Shell Create(Player player)
	{
		Shell shell = base.Create(player);
		FastShell fastShell = new(shell);
		player.Canoon.Shells.Add(fastShell);
		return fastShell;
	}
}
