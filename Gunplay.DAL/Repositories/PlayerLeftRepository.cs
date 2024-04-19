using Gunplay.DAL.Interfaces;
using Gunplay.Domain;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Shells;
namespace Gunplay.DAL;

public class PlayerLeftRepository : IBaseRepository<Player>
{
    public PlayerLeftRepository() 
	{
		
	}

    public Player Get()
	{

		Rectangle chassisRctngl = new (new(-0.95f, -0.95f),
									   new(-0.85f, -0.95f),
									   new(-0.95f, -0.85f),
									   new(-0.85f, -0.85f));

		Rectangle muzzleRctngl = new (new(-0.93f, -0.90f),
									  new(-0.87f, -0.90f),
									  new(-0.93f, -0.84f),
									  new(-0.87f, -0.84f));

		Rectangle boltRctngl = new (new(-0.88f, -0.895f),
									new(-0.85f, -0.895f),
									new(-0.88f, -0.845f),
									new(-0.85f, -0.845f));

		Bolt bolt = new(boltRctngl, @"data\img\player_bolt.png");
		Muzzle muzzle = new(muzzleRctngl, @"data\img\player_muzzle.png");
		Weapon weapon = new(bolt, muzzle);

		Chassis chassis = new(chassisRctngl, @"data\img\playerleft_down.png");

		return new Player(weapon, chassis);
	}
}
