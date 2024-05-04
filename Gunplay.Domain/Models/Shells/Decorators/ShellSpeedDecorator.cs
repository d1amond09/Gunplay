namespace Gunplay.Domain.Models.Shells.Decorators;

public class ShellSpeedDecorator(Shell shell) 
		   : ShellDecorator(shell)
{
	public override float ReloadSpeed => _shell.ReloadSpeed - .15f;
}
