using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Buffers;
using Gunplay.Domain.Textures;
using OpenTK.Graphics.OpenGL;

namespace Gunplay.Domain.Models
{
	public class Bolt : GameObject
	{
		public Rectangle Rectangle { get; set; }

		public Texture Texture { get; set; }

		public Bolt(Rectangle rectangle, string textureFilePath)
		{
			Rectangle = rectangle;
			Texture = Texture.LoadFromFile(textureFilePath);

			ArrayBuffer = new(Rectangle.Coordinates, BufferUsageHint.DynamicDraw);
			ElementBuffer rctngl = new([0, 1, 2, 2, 1, 3], BufferUsageHint.StaticDraw);

			ArrayObject = new ArrayObject(ArrayBuffer, rctngl, Texture);
		}

		public Bolt(Rectangle rectangle, Texture texture)
		{
			Rectangle = rectangle;
			Texture = texture;

			ArrayBuffer = new(Rectangle.Coordinates, BufferUsageHint.StaticDraw);
			ElementBuffer rctngl = new([0, 1, 2, 2, 1, 3], BufferUsageHint.StaticDraw);

			ArrayObject = new ArrayObject(ArrayBuffer, rctngl, Texture);
		}

		public void Fire()
		{
			
		}

		public void Move(float step)
		{
			Rectangle.MoveX(step);
		}

		public void Rotate(float angle, float centerX, float centerY)
		{
			Rectangle.Rotate(angle, centerX, centerY);
		}
	}
}
