namespace Gunplay.Domain.Models.Shells;

public class FastShell : BasicShell
{
	public float Speed { get; set; }
	public FastShell(Rectangle rectangle, string textureFilePath) : base(rectangle, textureFilePath)
	{
		Speed = 1.1f;
	}
}
