using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Textures;

namespace Gunplay.Domain.Models.Shells;

public class FreezeShell(Shell shell) : Shell(shell)
{
	public float FreezeSpeed { get; set; } = 0.8f;

}
