using Gunplay.DAL.Repositories;
using Gunplay.Domain;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Shells;
using Gunplay.Domain.Textures;
namespace Gunplay.DAL;

public class FreezeShellFactory : ShellFactory
{
	public FreezeShellFactory()
	{

	}

	public override FreezeShell Create(Player player)
	{
		Rectangle basicShellRctngl = new([.. player.Canoon.Bolt.Rectangle.Coordinates]);
		Texture texture = Texture.LoadFromFile(@"data\img\shell.png");
		FreezeShell shell = new(basicShellRctngl, texture);
		player.Canoon.Shells.Add(shell);
		return shell;
	}
}
