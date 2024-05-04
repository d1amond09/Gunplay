using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Buffers;
using Gunplay.Domain.Textures;
using OpenTK.Graphics.OpenGL;

namespace Gunplay.Domain.Models;

public abstract class GameObject : IDisposable
{
	public Rectangle Rectangle { get; set; }

	public Texture Texture { get; set; }

	public ArrayBuffer ArrayBuffer { get; set; }
	public ArrayObject ArrayObject { get; set; }

	public GameObject(Rectangle rectangle, Texture texture)
	{
		Rectangle = rectangle;
		Texture = texture;
		ArrayBuffer = new(Rectangle.Coordinates, BufferUsageHint.StaticDraw);
		ElementBuffer rctngl = new([0, 1, 2, 2, 1, 3], BufferUsageHint.StaticDraw);

		ArrayObject = new ArrayObject(ArrayBuffer, rctngl, Texture);
	}

    public void Draw(int textureIndex)
	{
		ArrayObject.DrawElements(0, DrawElementsType.UnsignedInt, textureIndex);
	}

	public void Update()
	{
		ArgumentNullException.ThrowIfNull(ArrayBuffer);
		ArrayBuffer.UpdateData();
	}

    public void Dispose()
	{
		ArrayObject.Dispose();
		GC.SuppressFinalize(this);
	}
}
