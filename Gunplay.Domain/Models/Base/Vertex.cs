namespace Gunplay.Domain.Models.Base;

public class Vertex(float x, float y)
{
	public float X { get; set; } = x;

	public float Y { get; set; } = y;

	public float DistanceTo(Vertex vertex) => (float)
		Math.Sqrt((X - vertex.X) * (X - vertex.X) + (Y - vertex.Y) * (Y - vertex.Y));
}
