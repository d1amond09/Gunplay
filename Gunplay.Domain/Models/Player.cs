using Gunplay.Domain.Models.Shells;
using Gunplay.Domain.Textures;
using Gunplay.Domain.Enum;

namespace Gunplay.Domain.Models;

public class Player(Weapon canoon, Chassis chassis,
					Texture textureMidHealth, Texture textureLowHealth, 
					Texture textureMidHealthFreeze, Texture textureLowHealthFreeze)
{
	private const float PLAYER_SPEED = .1f;
	private const float PLAYER_HEALTH = 3f;
	private const float MID_PLAYER_HEALTH = 2.5f;
	private const float LOW_PLAYER_HEALTH = 1.5f;
	private const float RESET_RELOAD_TIME = 0f;

	private readonly Texture _textureMidHealth = textureMidHealth;
	private readonly Texture _textureMidHealthFreeze = textureMidHealthFreeze;
	private readonly Texture _textureLowHealth = textureLowHealth;
	private readonly Texture _textureLowHealthFreeze = textureLowHealthFreeze;

	public Weapon Canoon { get; private set; } = canoon;
	public Chassis Chassis { get; private set; } = chassis;

	public float ReloadTime { get; private set; } = RESET_RELOAD_TIME;
	public float Health { get; private set; } = PLAYER_HEALTH;
	public float Speed { get; private set; } = PLAYER_SPEED;

	public bool IsAlive => Health > 0;
	public bool IsDead => !IsAlive;

	public GameObject[] GetObjects() 
		=> [Canoon.Bolt, Canoon.Muzzle, Chassis];

	public bool Fire(Direction direction)
	{
		if(Canoon.Fire(direction, ReloadTime))
		{
			ReloadTime = RESET_RELOAD_TIME;
			return true;
		}
		return false;
	}

	public void Update(float time)
	{
		Chassis.Update();
		Canoon.Update(time);
		ReloadTime += time;
	}

	public void Move(float time)
	{
		if (Chassis.CanMove(Speed * time))
		{
			Chassis.Move(Speed * time);
			Canoon.Move(Speed * time);
		}
	}

	public void TakeDamage(Shell shell)
	{
		shell.IsAlive = false;
		Health -= shell.Damage;
		if (shell is FreezeShell freezeShell)
		{
			Speed *= freezeShell.FreezeSpeed;
			if (Health < LOW_PLAYER_HEALTH)
			{
				Chassis.ChangeTexture(_textureLowHealthFreeze);
			}
			else if (Health < MID_PLAYER_HEALTH)
			{
				Chassis.ChangeTexture(_textureMidHealthFreeze);
			}
		}
		else
		{
			if (Health < LOW_PLAYER_HEALTH)
			{
				Chassis.ChangeTexture(_textureLowHealth);
			}
			else if (Health < MID_PLAYER_HEALTH)
			{
				Chassis.ChangeTexture(_textureMidHealth);
			}
		}
	}

	public void Dispose()
	{
		Chassis.Dispose();
		Canoon.Muzzle.Dispose();
		Canoon.Bolt.Dispose();
	}
}
