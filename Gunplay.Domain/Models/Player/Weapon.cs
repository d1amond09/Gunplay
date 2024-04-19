using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Models.Shells;

namespace Gunplay.Domain.Models
{
	public class Weapon
	{
		private float _deltaAngle = 20f;
		private float angleInDegrees = 0;
        public Bolt Bolt { get; set; }

        public Muzzle Muzzle { get; set; }

		public List<BasicShell> Shells { get; set; }

		public Weapon(Bolt bolt, Muzzle muzzle)
        {
            Bolt = bolt;
            Muzzle = muzzle;
			Shells = [];
        }

		public bool Fire(float speedX, float speedY, float time)
		{
			if (Shells.Count > 0)
			{
				Bolt.Fire();
				var shll = Shells.Last();
				if(time >= shll.ReloadSpeed)
					return shll.FlyStart(speedX, speedY, angleInDegrees);
			}
			return false;
		}

        public void Move(float step)
        {
            Bolt.Move(step);
            Muzzle.Move(step);
        }

		public void Update(float time)
		{
			Bolt.Update();
			Muzzle.Update();
			Shells.ForEach(shell => shell.Update());
			Shells.ForEach(shell => shell.Fly(time));
		}

		public void Rotate(float time)
		{
			const float maxAngle = 85.0f;
			const float minAngle = 10.0f;
			float angle = _deltaAngle * time;

			if (Math.Abs(angleInDegrees + angle) >= minAngle && Math.Abs(angleInDegrees + angle) < maxAngle)
			{
				float centerX = Muzzle.Rectangle.Coordinates[0];
				float centerY = Muzzle.Rectangle.Coordinates[1];

				Bolt.Rotate(angle, centerX, centerY);
				Muzzle.Rotate(angle);

				angleInDegrees += angle;
			}
		}
	}
}
