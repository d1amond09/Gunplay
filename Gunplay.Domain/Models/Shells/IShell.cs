using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunplay.Domain.Models.Shells;

public interface IShell
{
    public uint Damage { get; set; }

	public float ReloadSpeed { get; set; }

}
