using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Shells;
using Gunplay.Domain.Textures;

namespace Gunplay.DAL.Repositories;

public class BasicShellFactory(int damageCount, int reloadSpeedCount) : ShellFactory
{
	private readonly int _damageCount = damageCount;
	private readonly int _reloadSpeedCount = reloadSpeedCount;

	public override Shell Create(Player player)
	{
		Rectangle basicShellRctngl = new([.. player.Canoon.Bolt.Rectangle.Coordinates]);
		Texture texture = Texture.LoadFromFile(@"data\img\shell.png");
		BasicShell shell = new(basicShellRctngl, texture);

		ShellDamageDecorator shellDamage = new(shell);
		for (int i = 0; i < _damageCount; i++)
		{
			shellDamage = new ShellDamageDecorator(shellDamage);
		}

		ShellSpeedDecorator shellReloadSpeed = new(shellDamage);
		for (int i = 0; i < _reloadSpeedCount; i++)
		{
			shellReloadSpeed = new ShellSpeedDecorator(shellReloadSpeed);
		}


		player.Canoon.Shells.Add(shellReloadSpeed);
		return shellReloadSpeed;
	}
}
