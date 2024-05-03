using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunplay.Domain.Models.Shells;

public abstract class ShellDecorator : IShell
{
	private IShell _shell;

	public float Damage { get; set; }
	public float ReloadSpeed { get; set; }

	public ShellDecorator(IShell shell) 
	{ 
		_shell = shell;
		_shell.Damage = Damage;
		_shell.ReloadSpeed = ReloadSpeed;
	}
}
