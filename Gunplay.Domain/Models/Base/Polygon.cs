using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Interfaces;

namespace Gunplay.Domain.Models.Base;

public class Polygon : IFigure
{
	public List<Vertex> Vertices { get; set; }

	public Polygon(params Vertex[] vertices)
    {
		Vertices = [.. vertices];
    }

	public bool IsColliding(Polygon polygon)
	{
		foreach (var edge in GetEdges(this))
		{
			var axis = GetNormal(edge);
			var minMaxA = ProjectPolygon(axis, this);
			var minMaxB = ProjectPolygon(axis, polygon);

			if (!Overlap(minMaxA, minMaxB))
				return false;
		}

		foreach (var edge in GetEdges(polygon))
		{
			var axis = GetNormal(edge);
			var minMaxA = ProjectPolygon(axis, this);
			var minMaxB = ProjectPolygon(axis, polygon);

			if (!Overlap(minMaxA, minMaxB))
				return false;
		}

		return true;
	}

	private List<Vertex> GetEdges(IFigure figure)
	{
		var edges = new List<Vertex>();
		for (int i = 0; i < figure.Vertices.Count; i++)
		{
			var vertex1 = figure.Vertices[i];
			var vertex2 = figure.Vertices[(i + 1) % figure.Vertices.Count];
			edges.Add(new Vertex(vertex2.X - vertex1.X, vertex2.Y - vertex1.Y));
		}
		return edges;
	}

	private Vertex GetNormal(Vertex edge)
	{
		return new Vertex(-edge.Y, edge.X);
	}

	private (float Min, float Max) ProjectPolygon(Vertex axis, IFigure figure)
	{
		float min = Vector2.Dot(new Vector2(axis.X, axis.Y), new Vector2(figure.Vertices[0].X, figure.Vertices[0].Y));
		float max = min;
		for (int i = 1; i < figure.Vertices.Count; i++)
		{
			float p = Vector2.Dot(new Vector2(axis.X, axis.Y), new Vector2(figure.Vertices[i].X, figure.Vertices[i].Y));
			if (p < min)
				min = p;
			else if (p > max)
				max = p;
		}
		return (Min: min, Max: max);
	}

	private bool Overlap((float Min, float Max) a, (float Min, float Max) b)
	{
		return a.Min <= b.Max && a.Max >= b.Min;
	}
}
