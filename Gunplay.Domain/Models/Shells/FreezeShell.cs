using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunplay.Domain.Models.Shells;

public class FreezeShell : BasicShell
{
	public float FreezeSpeed { get; set; }
	public FreezeShell(Rectangle rectangle, string textureFilePath) : base(rectangle, textureFilePath)
	{
		FreezeSpeed = 0.5f;
	}
}
