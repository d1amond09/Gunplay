using Gunplay.DAL.Interfaces;
using Gunplay.Domain;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Base;
using Gunplay.Domain.Models.Shells;
namespace Gunplay.DAL;

public class PlayerRightRepository : IBaseRepository<Player>
{
    public PlayerRightRepository() 
	{
		
	}

	public Player ChangeTexture(Player player, string texturePath)
	{
		Bolt bolt = player.Canoon.Bolt;
		Muzzle muzzle = player.Canoon.Muzzle;
		Weapon weapon = new(bolt, muzzle);

		Chassis chassis = new(player.Chassis.Rectangle, texturePath);

		return new Player(weapon, chassis);
	}

	public Player Get()
	{
		Vertex[] chassisVertecies =
		{
			new(0.95f,  -0.95f),
			new(0.85f,  -0.95f),
			new(0.95f,  -0.85f),
			new(0.85f,  -0.85f)
		};

		Vertex[] muzzleVertecies =
		{
			new(0.93f,  -0.90f),
			new(0.87f,  -0.90f),
			new(0.93f,  -0.84f),
			new(0.87f,  -0.84f)
		};

		Vertex[] boltVertecies =
		{
			new(0.88f,  -0.895f),
			new(0.85f,  -0.895f),
			new(0.88f,  -0.845f),
			new(0.85f,  -0.845f)
		};

		Rectangle chassisRctngl = new (chassisVertecies);
		Rectangle muzzleRctngl = new (muzzleVertecies);
		Rectangle boltRctngl = new (boltVertecies);

		Bolt bolt = new(boltRctngl, @"data\img\player_bolt.png");
		Muzzle muzzle = new(muzzleRctngl, @"data\img\player_muzzle.png");
		Weapon weapon = new(bolt, muzzle);

		Chassis chassis = new(chassisRctngl, @"data\img\playerright_down.png");

		return new Player(weapon, chassis);
	}
}
