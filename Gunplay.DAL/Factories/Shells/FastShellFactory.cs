using Gunplay.DAL.Repositories;
using Gunplay.Domain;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Shells;
using Gunplay.Domain.Textures;
namespace Gunplay.DAL;

public class FastShellFactory(int damageCount, int reloadSpeedCount) : ShellFactory(damageCount, reloadSpeedCount)
{
	protected override string TexturePath => @"data\img\shell.png";
	public override Shell Create(Player player)
	{
		Shell shell = base.Create(player);
		FastShell fastShell = new(shell);
		player.Canoon.Shells.Add(fastShell);
		return fastShell;
	}
}
