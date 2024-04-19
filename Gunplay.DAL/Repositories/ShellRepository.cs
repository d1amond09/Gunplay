using Gunplay.DAL.Interfaces;
using Gunplay.Domain;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Shells;
namespace Gunplay.DAL;

public class ShellRepository
{
    public ShellRepository() { }
    public BasicShell Get(Player player)
	{
		float[] coords = new float[20];
		Array.Copy(player.Canoon.Bolt.Rectangle.Coordinates, coords, 20);

		Rectangle rctngl = new (coords);
		var shell = new BasicShell(rctngl, @"data\img\shell.png");
		player.Canoon.Shells.Add(shell);
		return player.Canoon.Shells.Last();
	}
}
