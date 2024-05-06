using Gunplay.Domain.Models.Geometry;

namespace Gunplay.Tests;

[TestClass]
public class CollisionTests
{
	[DataTestMethod]
	[DataRow(new float[] { 0, 0, 1, 0, 0, 1 }, new float[] { 1, 1, 2, 1, 1, 2 }, false)]
	[DataRow(new float[] { 0, 0, 1, 0, 0, 1 }, new float[] { 0.5f, 0.5f, 1.5f, 0.5f, 0.5f, 1.5f }, true)]
	public void IsCollidingTest(float[] vertices1, float[] vertices2, bool expected)
	{
		var polygon1 = new Polygon(VerticesFromArray(vertices1));
		var polygon2 = new Polygon(VerticesFromArray(vertices2));

		var result = polygon1.IsColliding(polygon2);

		Assert.AreEqual(expected, result);
	}

	private Vertex[] VerticesFromArray(float[] array)
	{
		var vertices = new List<Vertex>();
		for (int i = 0; i < array.Length; i += 2)
		{
			vertices.Add(new Vertex(array[i], array[i + 1]));
		}
		return vertices.ToArray();
	}
}

