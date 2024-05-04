using Gunplay.Domain.Textures;

namespace Gunplay.Domain.Models;

public class Background(Rectangle rectangle, Texture texture) : GameObject(rectangle, texture)
{
}
