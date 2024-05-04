namespace Gunplay.Domain.Models.Shells.Decorators;

public class ShellDamageDecorator(Shell shell) 
		   : ShellDecorator(shell)
{
	public override float Damage => _shell.Damage + .2f;
}
