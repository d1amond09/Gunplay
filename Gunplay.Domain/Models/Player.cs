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
	public class Player
	{
		private const float _speed = 0.1f;
		private const float _speedX = 2.2f;
		private const float _speedY = 6.3f;
		private float _direction = 0f;

		private readonly Texture _textureMidHealth;
		private readonly Texture _textureLowHealth;
		public float Time { get; set; }

		public Weapon Canoon { get; set; }

		public Chassis Chassis { get; set; }

		public float Health { get; set; }

		public bool IsAlive => Health > 0;
		public bool IsDead => !IsAlive;

        public Player(Weapon canoon, Chassis chassis, Texture textureMidHealth, Texture textureLowHealth)
		{
			_textureMidHealth = textureMidHealth;
			_textureLowHealth = textureLowHealth;
			Canoon = canoon;
			Chassis = chassis;
			Health = 3;
		}

		public List<GameObject> GetObjects() 
			=> [Canoon.Bolt, Canoon.Muzzle, Chassis];

		public bool Fire(float k)
		{
			_direction = k;
			var t = Canoon.Fire(_speedX * _direction, _speedY * _direction, Time);
			Time = t ? 0 : Time;
			return t;
		}

		public void Update(float time)
		{
			Chassis.Update();
			Canoon.Update(time * _direction);
			Time += Math.Abs(time);
		}

		public void Move(float time)
		{
			if (Math.Abs(Chassis.Rectangle.Vertices.First().X + time * _speed) < 1)
			{
				Chassis.Move(_speed * time);
				Canoon.Move(_speed * time);
			}
		}

		public void ChangeTexture()
		{
			ElementBuffer rctngl = new([0, 1, 2, 2, 1, 3], BufferUsageHint.StaticDraw);

			if(Health < 2)
			{
				Chassis.ArrayObject = new ArrayObject(Chassis.ArrayBuffer, rctngl, _textureLowHealth);
			}
			else if(Health < 3)
			{
				Chassis.ArrayObject = new ArrayObject(Chassis.ArrayBuffer, rctngl, _textureMidHealth);
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
