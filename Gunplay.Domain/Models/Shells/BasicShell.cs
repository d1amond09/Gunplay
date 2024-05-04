using Gunplay.Domain.Textures;
using Gunplay.Domain.Models.Geometry;

namespace Gunplay.Domain.Models.Shells;

public class BasicShell(Rectangle rectangle, Texture texture) : Shell(rectangle, texture)
{

}
