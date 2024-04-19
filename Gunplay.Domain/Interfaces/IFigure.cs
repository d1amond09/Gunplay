using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Models.Base;

namespace Gunplay.Domain.Interfaces;

public interface IFigure
{
	public List<Vertex> Vertices { get; set; }
}
