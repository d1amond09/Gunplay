namespace Gunplay.Domain.Models.Shells;

public abstract class ShellDecorator : Shell
{
	protected Shell _shell;

	public ShellDecorator(Shell shell) : base(shell.Rectangle, shell.Texture)
	{ 
		_shell = shell;
		Damage = _shell.Damage;
		ReloadSpeed = _shell.ReloadSpeed;
		Rectangle = _shell.Rectangle;
		Texture = _shell.Texture;
	}
	public override void Fly(float time)
	{
		_shell.Fly(time);
	}

	public override bool FlyStart(Direction dir, float angle)
	{
		return _shell.FlyStart(dir, angle);
	}
}
