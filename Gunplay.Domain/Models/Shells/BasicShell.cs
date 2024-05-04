using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Buffers;
using Gunplay.Domain.Textures;
using OpenTK.Graphics.OpenGL;

namespace Gunplay.Domain.Models.Shells;

public class BasicShell : Shell
{
	private float _angle;
	private float _angleFly;
	private float _speedX;
	private float _speedY;
	private float _time;

	private Rectangle _startRectangle;

	public BasicShell(Rectangle rectangle, Texture texture) : base(rectangle, texture)
	{
		_angle = 0;
		_angleFly = 0;
		_speedX = 0;
		_speedY = 0;
		_time = 0;
		_startRectangle = Rectangle;
	}

    public override bool FlyStart(float speedX, float speedY, float angle)
    {
		_speedX = speedX;
		_speedY = speedY;
		_angle = angle;
		_time = 0;
		IsAlive = true;
		float[] coords = Rectangle.Coordinates;
		_startRectangle = new Rectangle(coords);
		return true;
	}

	public override void Fly(float time)
	{
		var t = Math.Abs(time);
		if(IsAlive)
		{
			IsAlive = Rectangle.Fly(_startRectangle, _speedX * time, _speedY * time, _time, _angle, t);
			Rectangle.Rotate(_angleFly -= 0.8f * time);
		}
		_time += time;
	}
}
