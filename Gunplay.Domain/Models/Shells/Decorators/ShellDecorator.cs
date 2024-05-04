using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Textures;

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
}
