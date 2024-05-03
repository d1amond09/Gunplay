using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.DAL;
using Gunplay.DAL.Interfaces;
using Gunplay.Domain.Buffers;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Base;
using Gunplay.Domain.Models.Shells;
using Gunplay.Domain.Textures;
using OpenTK.Graphics.OpenGL;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gunplay.BLL.Controllers;

public class PlayerController
{
	private readonly IBaseRepository<Player> _playerRepository;

	public Player Player { get; private set; }

	public PlayerController(IBaseRepository<Player> playerRepository)
	{
		_playerRepository = playerRepository;
		Player = _playerRepository.Get();
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

	public BasicShell? Fire(Direction direction)
	{
		ShellRepository shellRepository = new();
		BasicShell shell = shellRepository.Get(Player);
		float k = 0;
		if (direction == Direction.Left)
			k = -1;
		if (direction == Direction.Right)
			k = 1;
		if (Player.Fire(k))
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
		foreach(BasicShell shell in Player.Canoon.Shells)
		{
			if(shell.Rectangle.IsColliding(player.Chassis.Rectangle))
			{
				shell.IsAlive = false;
				ElementBuffer rctngl = new([0, 1, 2, 2, 1, 3], BufferUsageHint.StaticDraw);
				player.Chassis.ArrayObject = new ArrayObject(player.Chassis.ArrayBuffer, rctngl, Texture.LoadFromFile(@"data\img\playerleft_down-3.png"));
				player.Health--;
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
		List<BasicShell> shellsToDelete = [];
		foreach (BasicShell shll in Player.Canoon.Shells)
		{
			if (!shll.IsAlive)
			{
				shellsToDelete.Add(shll);
				gameList.Remove(shll);
				
			}
		}
		foreach(BasicShell shll in shellsToDelete)
		{
			Player.Canoon.Shells.Remove(shll);
		}
	}

	public void Deactivate()
	{
		Player.Dispose();
	}
}
