using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Gunplay.Domain.Models;
using Gunplay.Control;
using Gunplay.Creation.Factories.Shells;
using Gunplay.Control.Controllers;
using Gunplay.Creation.Factories;

namespace Gunplay;

public class GameScene : GameWindow
{
	private readonly MainWindow _mainWindow;
	private readonly GameController _gameController;

	private double FrameTime { get; set; }
	private double FPS { get; set; }
	
	public GameScene(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings, 
					 MainWindow mainWindow, ShellFactory leftPlayerShellFactory, ShellFactory rightPlayerShellFactory)
		: base(gameWindowSettings, nativeWindowSettings)
	{
		_mainWindow = mainWindow;
		VSync = VSyncMode.On;
		CursorState = CursorState.Hidden;

		Title = "Перестрелка";
		if(_mainWindow.FPS != 0)
			UpdateFrequency = _mainWindow.FPS;

		Factory<Background> backgroundFactory = new BackgroundFactory();
		BackgroundController backgroundController = new(backgroundFactory);

		Factory<Player> playerLeftFactory = new PlayerLeftFactory();
		PlayerController playerLeftController = new(playerLeftFactory, leftPlayerShellFactory);

		Factory<Player> playerRightFactory = new PlayerRightFactory();
		PlayerController playerRightController = new(playerRightFactory, rightPlayerShellFactory);

		_gameController = new(backgroundController, playerLeftController, playerRightController)
		{
			RightPlayerPoints = _mainWindow.RightPlayerPoints,
			LeftPlayerPoints = _mainWindow.LeftPlayerPoints,
			
		};
	}

	protected override void OnLoad()
	{
		base.OnLoad();
		_mainWindow.Hide();
	}


	protected override void OnResize(ResizeEventArgs e)
	{
		base.OnResize(e);
		GL.Viewport(0, 0, e.Width, e.Height);
	}

	protected override void OnUpdateFrame(FrameEventArgs frameEventArgs)
	{
		FrameTime += frameEventArgs.Time;
		FPS++;
		if (FrameTime >= 1)
		{
			Title = $"Перестрелка - " + FPS;
			FPS = 0;
			FrameTime = 0;
		}

		var key = KeyboardState;
		_gameController.Update(key, (float) frameEventArgs.Time);

		if(_gameController.GameEnd)
		{
			_mainWindow.RightPlayerPoints = _gameController.RightPlayerPoints;
			_mainWindow.LeftPlayerPoints = _gameController.LeftPlayerPoints;
			_mainWindow.Show();
			Close();
			Dispose();
		}
		if (key.IsKeyDown(Keys.Escape))
		{
			_mainWindow.Show();
			Close();
			Dispose();
		}


		base.OnUpdateFrame(frameEventArgs);
	}



	protected override void OnRenderFrame(FrameEventArgs e)
	{
		GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

		_gameController.Draw();
		
		base.OnRenderFrame(e);
		SwapBuffers();
	}


	protected override void OnUnload()
	{
		_gameController.Deactivate();
		base.OnUnload();
	}
}
