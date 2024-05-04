using Gunplay.Domain.Models.Shells;
using Gunplay.Domain.Enum;

namespace Gunplay.Domain.Models
{
	public class Weapon(Bolt bolt, Muzzle muzzle)
	{
		private const float DELTA_ANGLE = 20f;
		private const float MAX_ANGLE = 85.0f;
		private const float MIN_ANGLE = 10.0f;

		private float angleInDegrees = 0;

		public Bolt Bolt => bolt;
		public Muzzle Muzzle => muzzle;
		public List<Shell> Shells { get; private set; } = [];

		public bool Fire(Direction direction, float time)
		{
			if (Shells.Count > 0)
			{
				var shll = Shells.Last();
				if(time >= shll.ReloadSpeed)
					return shll.FlyStart(direction, angleInDegrees);
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
			float angle = DELTA_ANGLE * time;

			if (Math.Abs(angleInDegrees + angle) >= MIN_ANGLE && 
				Math.Abs(angleInDegrees + angle) < MAX_ANGLE)
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
