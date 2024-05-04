namespace Gunplay.Domain.Models.Shells;

public class FastShell(Shell shell) 
		   : Shell(shell)
{
	private const float SPEED = 1.6f;

	public override void Fly(float time)
	{
		base.Fly(time * SPEED);
	}
}
