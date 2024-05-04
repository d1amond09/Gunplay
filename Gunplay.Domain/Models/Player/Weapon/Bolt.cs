using Gunplay.Domain.Textures;
using Gunplay.Domain.Models.Geometry;

namespace Gunplay.Domain.Models;

public class Bolt(Rectangle rectangle, Texture texture) 
		   : GameObject(rectangle, texture)
{
	public void Move(float step)
		=> Rectangle.MoveX(step);

	public void Rotate(float angle, float centerX, float centerY)
		=> Rectangle.Rotate(angle, centerX, centerY);
}
