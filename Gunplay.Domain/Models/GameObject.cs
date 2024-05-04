using Gunplay.Domain.Buffers;
using Gunplay.Domain.Textures;
using OpenTK.Graphics.OpenGL;
using Gunplay.Domain.Models.Geometry;

namespace Gunplay.Domain.Models;

public abstract class GameObject
{
	private readonly ElementBuffer _rctngl;
	public Rectangle Rectangle { get; protected set; }
	public Texture Texture { get; protected set; }
	public ArrayObject ArrayObject { get; set; }

	public GameObject(Rectangle rectangle, Texture texture)
	{
		Rectangle = rectangle;
		Texture = texture;

		ArrayBuffer ArrayBuffer = new(Rectangle.Coordinates, 
									  BufferUsageHint.StaticDraw);

		_rctngl = new([0, 1, 2, 2, 1, 3], BufferUsageHint.StaticDraw);

		ArrayObject = new ArrayObject(ArrayBuffer, _rctngl, Texture);
	}

	public void ChangeTexture(Texture texture)
		=> ArrayObject = new ArrayObject(ArrayObject.ArrayBuffer, 
										 ArrayObject.ElementBuffer, 
										 texture);
	
	public void Draw(int textureIndex)
		=>	ArrayObject.
			DrawElements(0, DrawElementsType.UnsignedInt, textureIndex);

	public void Update()
	{
		ArrayObject.ArrayBuffer.UpdateData();
	}

	public void Dispose()
	{
		ArrayObject.Dispose();
	}
}
