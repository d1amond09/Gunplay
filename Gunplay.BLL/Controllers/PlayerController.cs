using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.DAL;
using Gunplay.DAL.Repositories;
using Gunplay.Domain.Buffers;
using Gunplay.Domain.Models;
using Gunplay.Domain;
using Gunplay.Domain.Models.Geometry;
using Gunplay.Domain.Models.Shells;
using Gunplay.Domain.Textures;
using OpenTK.Graphics.OpenGL;

namespace Gunplay.BLL.Controllers;

public class PlayerController
{
	private readonly Factory<Player> _playerFactory;
	private readonly ShellFactory _shellFactory;

	public Player Player { get; private set; }

	public PlayerController(Factory<Player> playerFactory, ShellFactory shellFactory)
	{
		_shellFactory = shellFactory;	
		_playerFactory = playerFactory;
		Player = _playerFactory.Create();
	}

	public void Move(Direction direction, float time)
	{
		if(direction == Direction.Left)
			Player.Move(-time);
		if (direction == Direction.Right)
			Player.Move(time);
	}

	public void RotateCanoon(Direction direction, float time)
	{
		if (direction == Direction.Up)
			Player.Canoon.Rotate(time);
		if (direction == Direction.Down)
			Player.Canoon.Rotate(-time);
	}

	public Shell? Fire(Direction direction)
	{
		Shell shell = _shellFactory.Create(Player);

		if (Player.Fire(direction))
			return shell;
		return null;
	}

	public void TouchWithStone(Polygon polygon)
	{
		Player.Canoon.Shells
			.Where(x => x.Rectangle.IsColliding(polygon))
			.ToList().ForEach(x => x.IsAlive = false);
	}

	public bool HitTo(Player player)
	{
		foreach(Shell shell in Player.Canoon.Shells)
		{
			if(shell.Rectangle.IsColliding(player.Chassis.Rectangle))
			{
				shell.IsAlive = false;
				player.Health -= shell.Damage;
				if(shell is FreezeShell freezeShell)
				{
					player.Speed *= freezeShell.FreezeSpeed;
					player.ChangeTexture(true);
				}
				else
				{
					player.ChangeTexture();
				}

				return true;
			}
		}
		return false;
	}

	public void Update(float time)
	{
		Player.Update(time);
	}

	public void ClearShell(GameObjectList<GameObject> gameList)
	{
		List<Shell> shellsToDelete = [];
		foreach (Shell shll in Player.Canoon.Shells)
		{
			if (!shll.IsAlive)
			{
				shellsToDelete.Add(shll);
				gameList.Remove(shll);
				
			}
		}
		foreach(Shell shll in shellsToDelete)
		{
			Player.Canoon.Shells.Remove(shll);
		}
	}

	public void Deactivate()
	{
		Player.Dispose();
	}
}
