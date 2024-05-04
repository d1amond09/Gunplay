using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Buffers;
using Gunplay.Domain.Models.Shells;
using Gunplay.Domain.Textures;
using OpenTK.Graphics.OpenGL;

namespace Gunplay.Domain.Models
{
	public class Player(Weapon canoon, Chassis chassis,
						Texture textureMidHealth, Texture textureLowHealth, 
						Texture textureMidHealthFreeze)
	{
		private const float _speed = 0.1f;

		private readonly Texture _textureMidHealth = textureMidHealth;
		private readonly Texture _textureMidHealthFreeze = textureMidHealthFreeze;
		private readonly Texture _textureLowHealth = textureLowHealth;

		public Weapon Canoon { get; set; } = canoon;
		public Chassis Chassis { get; set; } = chassis;

		public float Time { get; set; }
		public float Health { get; set; } = 3;
		public float Speed { get; set; } = _speed;

		public bool IsAlive => Health > 0;
		public bool IsDead => !IsAlive;

		public List<GameObject> GetObjects() 
			=> [Canoon.Bolt, Canoon.Muzzle, Chassis];

		public bool Fire(Direction direction)
		{
			if(Canoon.Fire(direction, Time))
			{
				Time = 0;
				return true;
			}
			return false;
		}

		public void Update(float time)
		{
			Chassis.Update();
			Canoon.Update(time);
			Time += time;
		}

		public void Move(float time)
		{
			if (Math.Abs(Chassis.Rectangle.Vertices.First().X + time * Speed) < 1)
			{
				Chassis.Move(Speed * time);
				Canoon.Move(Speed * time);
			}
		}

		public void ChangeTexture(bool freeze = false)
		{
			ElementBuffer rctngl = new([0, 1, 2, 2, 1, 3], BufferUsageHint.StaticDraw);
			if(freeze)
			{
				if (Health < 1.5)
				{
					Chassis.ArrayObject = new ArrayObject(Chassis.ArrayBuffer, rctngl, _textureLowHealth);
				}
				else if (Health < 2.5)
				{
					Chassis.ArrayObject = new ArrayObject(Chassis.ArrayBuffer, rctngl, _textureMidHealthFreeze);
				}
			}
			else
			{
				if (Health < 1.5)
				{
					Chassis.ArrayObject = new ArrayObject(Chassis.ArrayBuffer, rctngl, _textureLowHealth);
				}
				else if(Health < 2.5)
				{
					Chassis.ArrayObject = new ArrayObject(Chassis.ArrayBuffer, rctngl, _textureMidHealth);
				}
			}
		}

		public void Dispose()
		{
			Chassis.Dispose();
			Canoon.Muzzle.Dispose();
			Canoon.Bolt.Dispose();
		}
	}
}
