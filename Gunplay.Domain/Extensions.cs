using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Models.Base;

namespace Gunplay.Domain;

public static class Extensions
{
	public static void UpdateCoords(this float[] coords, List<Vertex> vertices)
	{
		for(int i = 0, j = 0 ; i < coords.Length; i+= 5, j++)
		{
			coords[i] = vertices[j].X;
			coords[i + 1] = vertices[j].Y;
		}
	}

	public static float[] ToCoordinates(this List<Vertex> vertices)
		=>  [vertices[0].X, vertices[0].Y, 0.0f, 0.0f, 0.0f,
			 vertices[1].X, vertices[1].Y, 0.0f, 1.0f, 0.0f,
			 vertices[2].X, vertices[2].Y, 0.0f, 0.0f, 1.0f,
			 vertices[3].X, vertices[3].Y, 0.0f, 1.0f, 1.0f];

	public static List<Vertex> ToVertices(this float[] coords)
		=> [new(coords[0], coords[1]), new(coords[5], coords[6]),
			new(coords[10], coords[11]), new(coords[15], coords[16])];
}
