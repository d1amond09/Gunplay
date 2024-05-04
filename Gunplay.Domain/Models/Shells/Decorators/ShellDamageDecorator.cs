using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Textures;

namespace Gunplay.Domain.Models.Shells;

public class ShellDamageDecorator : ShellDecorator
{
	public ShellDamageDecorator(Shell shell) : base(shell)
	{
		Damage += .3f;
	}

	public override void Fly(float time)
	{
		_shell.Fly(time);
	}

	public override bool FlyStart(float speedX, float speedY, float angle)
	{
		return _shell.FlyStart(speedX, speedY, angle);	
	}
}
