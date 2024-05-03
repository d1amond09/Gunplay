using Gunplay.DAL.Interfaces;
using Gunplay.DAL.Repositories;
using Gunplay.Domain;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Shells;
using Gunplay.Domain.Textures;
namespace Gunplay.DAL;

public class PlayerLeftFactory : Factory<Player>
{
	private readonly Rectangle _startChassisRctngl;

	private readonly Rectangle _startMuzzleRctngl;

	private readonly Rectangle _startBoltRctngl;

	private readonly Texture _textureMidHealth;
	private readonly Texture _textureLowHealth;



	public PlayerLeftFactory() 
	{
		_startChassisRctngl = new(new(-0.95f, -0.95f), new(-0.85f, -0.95f),
								  new(-0.95f, -0.85f), new(-0.85f, -0.85f));

		_startMuzzleRctngl = new(new(-0.93f, -0.90f), new(-0.87f, -0.90f),
								 new(-0.93f, -0.84f), new(-0.87f, -0.84f));

		_startBoltRctngl = new(new(-0.88f, -0.895f), new(-0.85f, -0.895f),
							   new(-0.88f, -0.845f), new(-0.85f, -0.845f));

		_textureMidHealth = Texture.LoadFromFile(@"data\img\playerleft_down-2.png");
		_textureLowHealth = Texture.LoadFromFile(@"data\img\playerleft_down-5.png");
	}

    public override Player Create()
	{

		Bolt bolt = new(_startBoltRctngl, @"data\img\player_bolt.png");
		Muzzle muzzle = new(_startMuzzleRctngl, @"data\img\player_muzzle.png");
		Weapon weapon = new(bolt, muzzle);
		Chassis chassis = new(_startChassisRctngl, @"data\img\playerleft_down.png");

		return new Player(weapon, chassis, _textureMidHealth, _textureLowHealth);
	}
}
