using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Geometry;
using Gunplay.Domain.Models.Shells;
using Gunplay.Domain.Models.Shells.Decorators;
using Gunplay.Domain.Textures;
namespace Gunplay.DAL;

public abstract class ShellFactory(int damageCount, int reloadSpeedCount)
{
	protected readonly int _damageCount = damageCount;
	protected readonly int _reloadSpeedCount = reloadSpeedCount;

	protected abstract string TexturePath { get; }

	public virtual Shell Create(Player player)
	{
		Rectangle basicShellRctngl = new([.. player.Canoon.Bolt.Rectangle.Coordinates]);
		Texture texture = Texture.LoadFromFile(TexturePath);
		Shell shell = new BasicShell(basicShellRctngl, texture);

		for (int i = 0; i < _damageCount; i++)
		{
			shell = new ShellDamageDecorator(shell);
		}

		for (int i = 0; i < _reloadSpeedCount; i++)
		{
			shell = new ShellSpeedDecorator(shell);
		}

		return shell;
	}
}
