using Gunplay.Domain.Textures;
using Gunplay.Domain.Enum;
using Gunplay.Domain.Models.Geometry;

namespace Gunplay.Domain.Models.Shells;

public abstract class Shell(Rectangle rectangle, Texture texture) : GameObject(rectangle, texture)
{
	protected const float SPEED_X = 2.2f;
	protected const float SPEED_Y = 6.3f;
	protected const float DELTA_ANGLE_FLY = -90.8f;

	protected float _time = 0;
	protected float _angle = 0;
	protected float _angleFly = 0;
	protected float _kDirection = 0;
	protected Rectangle _startRectangle = rectangle;

	public virtual float Damage { get; protected set; } = .5f;
	public virtual float ReloadSpeed { get; protected set; } = 2f;

	public bool IsAlive { get; set; } = true;

	public Shell(Shell shell) : this(shell.Rectangle, shell.Texture)
	{
		Damage = shell.Damage;
		ReloadSpeed = shell.ReloadSpeed;
	}

	public virtual bool FlyStart(Direction dir, float angle)
	{
		_angle = angle;
		_angleFly = 0;
		_time = 0;
		_startRectangle = new Rectangle(Rectangle.Coordinates);

		_kDirection = dir == Direction.Right ?  1f : 
					  dir == Direction.Left	 ? -1f : 0;

		return true;
	}

	public virtual void Fly(float updateTime)
	{
		if (IsAlive)
		{
			IsAlive = Rectangle.Fly(_startRectangle, 
									SPEED_X * _kDirection, 
									SPEED_Y * _kDirection, 
									_time, _angle, updateTime);

			_angleFly += updateTime * DELTA_ANGLE_FLY * _kDirection;
			Rectangle.Rotate(_angleFly * updateTime);
		}
		_time += updateTime;
	}
}
