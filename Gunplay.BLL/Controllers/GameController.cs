using Gunplay.Control.Controllers;
using Gunplay.Domain.Enum;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Geometry;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Gunplay.Control;

public class GameController
{
    private readonly BackgroundController _backgroundController;
	private readonly PlayerController _playerLeftController;
	private readonly PlayerController _playerRightController;
	private readonly GameObjectList<GameObject> _gameObjects;
	private readonly Polygon Stone;

    public bool GameEnd { get; private set; }
    public int RightPlayerPoints { get; set; }
    public int LeftPlayerPoints { get; set; }
	public string Sound { get; set; }



	public GameController(BackgroundController backgroundController, 
						  PlayerController playerLeftController, 
						  PlayerController playerRightController)
    {
		_backgroundController = backgroundController;
		Background background = _backgroundController.Background;

		_playerLeftController = playerLeftController;
		Player PlayerLeft = _playerLeftController.Player;
		PlayerLeft.Canoon.Rotate(0.5f);

		_playerRightController = playerRightController;
		Player PlayerRight = _playerRightController.Player;
		PlayerRight.Canoon.Rotate(-0.5f);

		Stone = new Polygon(new(-0.30f, -1.00f), new(-0.21f, -0.68f), 
							new(-0.08f, -0.25f), new(-0.08f, -0.25f), 
							new( 0.03f, -0.40f), new( 0.10f, -0.48f), 
							new( 0.26f, -0.99f));

		List<GameObject> gameList = [];
		gameList.Add(background);
		gameList.AddRange(PlayerLeft.GetObjects());
		gameList.AddRange(PlayerRight.GetObjects());
		_gameObjects = new(gameList);
		Sound = "";
	}

	public void Update(KeyboardState keyboardState, float time)
	{
		_playerLeftController.Update(time);
		_playerRightController.Update(time);

		_playerLeftController.TouchWithStone(Stone);
		_playerRightController.TouchWithStone(Stone);

		if(_playerRightController.HitTo(_playerLeftController))
			_gameObjects.Add(_playerLeftController.Player.Chassis);

		if(_playerLeftController.HitTo(_playerRightController))
			_gameObjects.Add(_playerRightController.Player.Chassis);

		if (_playerRightController.IsLose)
		{
			LeftPlayerPoints++;
			GameEnd = true;
		}

		if (_playerLeftController.IsLose)
		{
			RightPlayerPoints++;
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
				_gameObjects.Add(shell);
			Sound = @"..\..\..\data\sounds\fire.mp3";
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
				_gameObjects.Add(shell);
		}

		_playerLeftController.ClearShell(_gameObjects);
		_playerRightController.ClearShell(_gameObjects);
	}

    public void Draw()
	{
		_gameObjects.Draw();
	}
	
	public void Deactivate()
	{
		_gameObjects.Dispose();
	}
}
