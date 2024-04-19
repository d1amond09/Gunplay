using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Buffers;
using Gunplay.Domain.Textures;
using OpenTK.Graphics.OpenGL;


namespace Gunplay.Domain.Models;

public class Background : GameObject
{
	public Rectangle Rectangle { get; set; }

	public Texture Texture { get; set; }

	public Background(Rectangle rectangle, string textureFilePath) 
	{ 
		Rectangle = rectangle;
		Texture = Texture.LoadFromFile(textureFilePath);

		ArrayBuffer = new(Rectangle.Coordinates, BufferUsageHint.StaticDraw);
		ElementBuffer rctngl = new([0, 1, 2, 2, 1, 3], BufferUsageHint.StaticDraw);

		ArrayObject = new ArrayObject(ArrayBuffer, rctngl, Texture);
	}
}
