using Gunplay.DAL.Repositories;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Geometry;
using Gunplay.Domain.Textures;
namespace Gunplay.DAL;

public class PlayerLeftFactory : Factory<Player>
{
	private readonly Rectangle _startChassisRctngl;
	private readonly Rectangle _startMuzzleRctngl;
	private readonly Rectangle _startBoltRctngl;

	private readonly Texture _textureMidHealth;
	private readonly Texture _textureLowHealth;
	private readonly Texture _textureMidHealthFreeze;

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
		_textureMidHealthFreeze = Texture.LoadFromFile(@"data\img\playerleft_down-2-freeze.png");
	}

    public override Player Create()
	{
		Texture textureBolt = Texture.LoadFromFile(@"data\img\player_bolt.png");
		Texture textureMuzzle = Texture.LoadFromFile(@"data\img\player_muzzle.png");
		Texture textureChassis = Texture.LoadFromFile(@"data\img\playerright_down.png");

		Bolt bolt = new(_startBoltRctngl, textureBolt);
		Muzzle muzzle = new(_startMuzzleRctngl, textureMuzzle);
		Weapon weapon = new(bolt, muzzle);
		Chassis chassis = new(_startChassisRctngl, textureChassis);

		return new Player(weapon, chassis, _textureMidHealth, _textureLowHealth, _textureMidHealthFreeze, _textureLowHealth);
	}
}
