using Gunplay.Domain.Textures;
using Gunplay.Domain.Models.Geometry;

namespace Gunplay.Domain.Models;

public class Muzzle(Rectangle rectangle, Texture texture) 
		   : GameObject(rectangle, texture)
{
	public void Move(float step)
		=> Rectangle.MoveX(step);

	public void Rotate(float angle)
		=> Rectangle.Rotate(angle);
}
