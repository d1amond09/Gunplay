using Gunplay.Domain.Extensions;

namespace Gunplay.Domain.Models.Geometry;

public class Rectangle : Polygon
{
	public float[] Coordinates { get; protected set; }

	public Rectangle(params Vertex[] vertices) : base(vertices)
	{
		Coordinates = Vertices.ToCoordinates();
	}

	public Rectangle(float[] coordinates) 
	{
		Vertices = [new Vertex(coordinates[0],  coordinates[1]),
					new Vertex(coordinates[5],  coordinates[6]),
					new Vertex(coordinates[10], coordinates[11]),
					new Vertex(coordinates[15], coordinates[16])];
		Coordinates = coordinates;
	}

	public void MoveX(float step)
	{
		
		Vertices.ForEach(vertex => vertex.X += step);
		Coordinates.UpdateCoords(Vertices);
	}

	public void MoveY(float step)
	{
		Vertices.ForEach(vertex => vertex.Y += step);
		Coordinates.UpdateCoords(Vertices);
	}

	public void Rotate(float angleInDegrees)
	{
		const float K = 1.77777f;
		var angle = angleInDegrees * (float)Math.PI / 180.0f;

		foreach(Vertex vertex in Vertices)
		{
			float x = vertex.X;
			float y = vertex.Y;

			float translatedX = x - Vertices.First().X;
			float translatedY = y - Vertices.First().Y;

			float newX = translatedX * (float)Math.Cos(angle / K) - 
						 translatedY * (float)Math.Sin(angle / K);

			float newY = translatedX * (float)Math.Sin(angle * K) + 
						 translatedY * (float)Math.Cos(angle * K);

			vertex.X = newX + Vertices.First().X;
			vertex.Y = newY + Vertices.First().Y;
		}
		Coordinates.UpdateCoords(Vertices);
	}

	public void Rotate(float angleInDegrees, float centerX, float centerY)
	{
		const float K = 1.77777f;
		var angle = angleInDegrees * (float)Math.PI / 180.0f;

		foreach (Vertex vertex in Vertices)
		{
			float x = vertex.X;
			float y = vertex.Y;

			float translatedX = x - centerX;
			float translatedY = y - centerY;

			float newX = translatedX * (float)Math.Cos(angle / K) - translatedY * (float)Math.Sin(angle / K);
			float newY = translatedX * (float)Math.Sin(angle * K) + translatedY * (float)Math.Cos(angle * K);

			vertex.X = newX + centerX;
			vertex.Y = newY + centerY;
		}
		Coordinates.UpdateCoords(Vertices);
	}

	public bool Fly(Rectangle startRectangle, float speedX, float speedY, float time, float angle, float updateTime)
	{
		for (int i = 0; i < Coordinates.Length; i += 5)
		{
			float vX = speedX * updateTime * (float)Math.Cos(angle * (float)Math.PI / 180.0f);
			float newX = startRectangle.Coordinates[i] + vX * time;
			float newY = startRectangle.Coordinates[i + 1] + (speedY * (float)Math.Sin(angle * (float)Math.PI / 180.0f) * time - (9.8f * 0.5f * time * time)) * updateTime;
			if (newX > 1.2f || newX < -1.2f || newY > 1.2f || newY < -1.2f)
			{
				return false;
			}
			else
			{
				Coordinates[i] = newX;
				Coordinates[i + 1] = newY;
			}
		}
		Vertices = Coordinates.ToVertices();
		return true;
	}
}
