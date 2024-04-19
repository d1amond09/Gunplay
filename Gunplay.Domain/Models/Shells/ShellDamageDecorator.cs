using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunplay.Domain.Models.Shells;

public class ShellDamageDecorator : ShellDecorator
{
	public ShellDamageDecorator(IShell shell) : base(shell)
	{
		Damage++;
		shell.Damage = Damage;
	}
}
