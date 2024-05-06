using Gunplay.Domain.Models.Geometry;

namespace Gunplay.Tests;

[TestClass]
public class MovementTests 
{
	[DataTestMethod]
	[DataRow(20, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 2, 2, 0, 0, 1, 3, 3, 0, 1, 1)]
	[DataRow(20, 0, 1, 1, 5, 1, 9, 2, 0, 0, 1, 2, 2, 3, 1, 1, 3, 2, 0, 2, 4)]
	public void TestRectangleConstructor(int length, params float[] coordinates)
	{
		var rectangle = new Rectangle(coordinates);
		Assert.IsNotNull(rectangle);
		Assert.AreEqual(length, rectangle.Coordinates.Length);
	}

	[DataTestMethod]
	[DataRow(1)]
	[DataRow(-1)]
	[DataRow(0)]
	[DataRow(50)]
	[DataRow(-50)]
	public void TestMoveX(float step)
	{
		var rectangle = new Rectangle(new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1), new Vertex(0, 1));
		rectangle.MoveX(step);
		Assert.AreEqual(step, rectangle.Vertices[0].X);
	}

	[DataTestMethod]
	[DataRow(1)]
	[DataRow(-1)]
	[DataRow(0)]
	[DataRow(50)]
	[DataRow(-50)]
	public void TestMoveY(float step)
	{
		var rectangle = new Rectangle(new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1), new Vertex(0, 1));
		rectangle.MoveY(step);
		Assert.AreEqual(step, rectangle.Vertices[0].Y);
	}

	[DataTestMethod]
	[DataRow(45)]
	[DataRow(0)]
	[DataRow(-45)]
	public void TestRotate(float angle)
	{
		var rectangle = new Rectangle(new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1), new Vertex(0, 1));
		rectangle.Rotate(angle);
		Assert.AreEqual(0, rectangle.Vertices[0].X, 0.01);hs
	}

	[DataTestMethod]
	[DataRow(45, 0.5f, 0.5f)]
	public void TestRotateAroundPoint(float angle, float centerX, float centerY)
	{
		var rectangle = new Rectangle(new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1), new Vertex(0, 1));
		rectangle.Rotate(angle, centerX, centerY);
		rectangle.Vertices.ForEach(v => Console.WriteLine($"{v.X}; {v.Y}"));
		Assert.AreEqual(0.26, rectangle.Vertices[0].X, 0.01);
	}

	[DataTestMethod]
	[DataRow(1, 1, 1, 45, 1)]
	[DataRow(1, 2, 3, 35, 2)]
	[DataRow(5, 3, 5, 65, 6)]
	public void TestFly(float speedX, float speedY, float time, float angle, float updateTime)
	{
		var startRectangle = new Rectangle(new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1), new Vertex(0, 1));
		var rectangle = new Rectangle(new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1), new Vertex(0, 1));
		var result = rectangle.Fly(startRectangle, speedX, speedY, time, angle, updateTime);
            Assert.IsFalse(result);
	}
}