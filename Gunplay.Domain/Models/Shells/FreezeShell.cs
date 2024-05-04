namespace Gunplay.Domain.Models.Shells;

public class FreezeShell(Shell shell) 
		   : Shell(shell)
{
	private const float FREEZE_SPEED = .8f;
	public float FreezeSpeed { get; protected set; } = FREEZE_SPEED;

}
