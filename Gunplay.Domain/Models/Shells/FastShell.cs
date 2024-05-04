using Gunplay.Domain.Textures;

namespace Gunplay.Domain.Models.Shells;

public class FastShell(Rectangle rectangle, Texture texture) : BasicShell(rectangle, texture)
{
	public float Speed { get; set; } = 1.6f;

	public override void Fly(float time)
	{
		base.Fly(time * Speed);
	}
}
