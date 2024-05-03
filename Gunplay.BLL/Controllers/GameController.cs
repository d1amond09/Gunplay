using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.BLL.Controllers;
using Gunplay.DAL;
using Gunplay.DAL.Interfaces;
using Gunplay.Domain.Buffers;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Base;
using Gunplay.Domain.Models.Shells;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Gunplay.BLL;

public class GameController
{
    public bool GameEnd { get; private set; }
    private readonly BackgroundController _backgroundController;
	private readonly PlayerController _playerLeftController;
	private readonly PlayerController _playerRightController;
	private readonly Polygon Stone;
    public GameObjectList<GameObject> GameList { get; set; }

    public GameController(BackgroundController backgroundController, PlayerController playerLeftController, PlayerController playerRightController)
    {
		_backgroundController = backgroundController;
		Background background = _backgroundController.Background;

		_playerLeftController = playerLeftController;
		Player PlayerLeft = _playerLeftController.Player;
		PlayerLeft.Canoon.Rotate(0.5f);

		_playerRightController = playerRightController;
		Player PlayerRight = _playerRightController.Player;
		PlayerRight.Canoon.Rotate(-0.5f);

		Stone = new Polygon(new(-0.30f, -1f), new(-0.21f, -0.68f), 
							new(-0.08f, -0.25f), new(-0.08f, -0.25f), 
							new(0.03f, -0.40f), new(0.1f, -0.48f), 
							new(0.26f, -0.99f));

		List<GameObject> gameList = [];
		gameList.Add(background);
		gameList.AddRange(PlayerLeft.GetObjects());
		gameList.AddRange(PlayerRight.GetObjects());
		GameList = new(gameList);
	}

	public void Update(KeyboardState keyboardState, float time)
	{
		_playerLeftController.Update(time);
		_playerRightController.Update(time);

		//Debug.WriteLine(_playerLeftController.Player.Canoon.Shells.Count);

		_playerLeftController.TouchWithStone(Stone);
		_playerRightController.TouchWithStone(Stone);

		if(_playerRightController.HitTo(_playerLeftController.Player))
			GameList.Add(_playerRightController.Player.Chassis);
		_playerLeftController.HitTo(_playerRightController.Player);

		if(_playerRightController.Player.IsDead || _playerLeftController.Player.IsDead)
		{
			GameEnd = true;
		}

		var key = keyboardState;
		if (key.IsKeyDown(Keys.D))
		{
			if(!_playerLeftController.Player.Chassis.Rectangle.IsColliding(Stone))
				_playerLeftController.Move(Direction.Right, time);
		}

		if (key.IsKeyDown(Keys.A))
		{
			_playerLeftController.Move(Direction.Left, time);
		}

		if (key.IsKeyDown(Keys.W))
		{
			_playerLeftController.RotateCanoon(Direction.Up, time);
		}

		if (key.IsKeyDown(Keys.S))
		{
			_playerLeftController.RotateCanoon(Direction.Down, time);
		}

		if (key.IsKeyPressed(Keys.Space))
		{
			var shell = _playerLeftController.Fire(Direction.Right);
			if (shell != null)
				GameList.Add(shell);
		}

		if (key.IsKeyDown(Keys.L))
		{
			_playerRightController.Move(Direction.Right, time);
		}

		if (key.IsKeyDown(Keys.J))
		{
			if (!_playerRightController.Player.Chassis.Rectangle.IsColliding(Stone))
				_playerRightController.Move(Direction.Left, time);
		}

		if (key.IsKeyDown(Keys.I))
		{
			_playerRightController.RotateCanoon(Direction.Down, time);
		}

		if (key.IsKeyDown(Keys.K))
		{
			_playerRightController.RotateCanoon(Direction.Up, time);
		}

		if (key.IsKeyPressed(Keys.Enter))
		{
			var shell = _playerRightController.Fire(Direction.Left);
			if (shell != null)
				GameList.Add(shell);
		}

		_playerLeftController.ClearShell(GameList);
		_playerRightController.ClearShell(GameList);
	}

    public void Draw()
	{
		GameList.Draw();
	}
	
	public void Deactivate()
	{
		GameList.Dispose();
	}
}
