﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Buffers;
using Gunplay.Domain.Textures;
using OpenTK.Graphics.OpenGL;

namespace Gunplay.Domain.Models
{
	public class Muzzle(Rectangle rectangle, Texture texture) : GameObject(rectangle, texture)
	{
		public void Move(float step)
		{
			Rectangle.MoveX(step);
		}

		public void Rotate(float angle)
		{
			Rectangle.Rotate(angle);
		}
	}
}
