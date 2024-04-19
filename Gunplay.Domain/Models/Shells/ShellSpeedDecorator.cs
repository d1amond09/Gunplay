using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunplay.Domain.Models.Shells;

public class ShellSpeedDecorator : ShellDecorator
{
    public ShellSpeedDecorator(IShell shell) : base(shell)
    {
	    ReloadSpeed++;
	    shell.ReloadSpeed = ReloadSpeed;
    }
}
