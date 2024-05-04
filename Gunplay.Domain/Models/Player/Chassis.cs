using Gunplay.Domain.Textures;
using Gunplay.Domain.Models.Geometry;

namespace Gunplay.Domain.Models;

public class Chassis(Rectangle rectangle, Texture texture) 
		   : GameObject(rectangle, texture)
{
	public bool CanMove(float step) =>
		Math.Abs(Rectangle.Vertices.First().X + step) < 1;

	public void Move(float step) 
		=> Rectangle.MoveX(step);
}
