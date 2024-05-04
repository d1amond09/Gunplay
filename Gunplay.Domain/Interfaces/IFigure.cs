using Gunplay.Domain.Models.Geometry;

namespace Gunplay.Domain.Interfaces;

public interface IFigure
{
	public List<Vertex> Vertices { get; }
}
