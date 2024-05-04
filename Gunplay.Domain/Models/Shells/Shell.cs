using Gunplay.Domain.Textures;

namespace Gunplay.Domain.Models.Shells;

public abstract class Shell(Rectangle rectangle, Texture texture) : GameObject(rectangle, texture)
{
	public float Damage { get; set; } = .5f;
	public float ReloadSpeed { get; set; } = 2f;
	public bool IsAlive { get; set; } = true;

	public abstract bool FlyStart(float speedX, float speedY, float angle);
	public abstract void Fly(float time);
}
