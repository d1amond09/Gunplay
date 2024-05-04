using Gunplay.Domain.Textures;
using Gunplay.Domain.Models.Geometry;

namespace Gunplay.Domain.Models;

public class Background(Rectangle rectangle, Texture texture) 
		   : GameObject(rectangle, texture)
{

}
