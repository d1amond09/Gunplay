using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gunplay.DAL;
using Gunplay.DAL.Repositories;
using Gunplay.Domain.Models.Shells;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Gunplay.View
{
	public partial class StartPage : Page
	{
		public MainWindow Menu { get; set; } = default!;
		public Queue<ShellType> _leftShellTypes;
		public Queue<ShellType> _rightShellTypes;

		private int _leftPoints;
		private int _leftDamage;
		private int _leftReloadSpeed;
		
		private int _rightPoints;
		private int _rightDamage;
		private int _rightReloadSpeed;


		private NativeWindowSettings NWSettings => new()
		{
			WindowState = OpenTK.Windowing.Common.WindowState.Maximized,
			ClientSize = new (1920, 1080),
			WindowBorder = WindowBorder.Hidden,
			StartFocused = true,
			StartVisible = true,

			Flags = ContextFlags.ForwardCompatible,     
			APIVersion = new Version(4, 6),      
			Profile = ContextProfile.Core, 
			API = ContextAPI.OpenGL,
		};

		public StartPage()
		{
			InitializeComponent();

			_leftShellTypes = new([new(@"Images/freezeShell.png", "Заморозка", 3),
							   new(@"Images/fastShell.png", "Быстрый", 2), 
							   new(@"Images/basicShell.png", "Обычный", 0)]);

			_rightShellTypes = new([new(@"Images/freezeShell.png", "Заморозка", 3),
							   new(@"Images/fastShell.png", "Быстрый", 2),
							   new(@"Images/basicShell.png", "Обычный", 0)]);


			_leftPoints = 6;
			_leftDamage = 0;
			_leftReloadSpeed = 0;

			_rightPoints = 6;
			_rightDamage = 0;
			_rightReloadSpeed = 0;

			pointsRightLabel.Content = _rightPoints;
			damageRightLabel.Content = _rightDamage;
			reloadSpeedRightLabel.Content = _rightReloadSpeed;

		}

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{
			if(int.TryParse(damageLeftLabel.Content.ToString(), out int leftDamageCount) && 
			   int.TryParse(reloadSpeedLeftLabel.Content.ToString(), out int leftReloadSpeedCount) &&
			   int.TryParse(damageRightLabel.Content.ToString(), out int rightDamageCount) &&
			   int.TryParse(reloadSpeedRightLabel.Content.ToString(), out int rightReloadSpeedCount))
			{
				ShellFactory leftPlayerShellFactory = labelLeftShell.Content switch
				{
					"Обычный" => new BasicShellFactory(leftDamageCount, leftReloadSpeedCount),
					"Быстрый" => new FastShellFactory(leftDamageCount, leftReloadSpeedCount),
					"Заморозка" => new FreezeShellFactory(leftDamageCount, leftReloadSpeedCount),
					_ => new BasicShellFactory(leftDamageCount, leftReloadSpeedCount),
				};

				ShellFactory rightPlayerShellFactory = labelRightShell.Content switch
				{
					"Обычный" => new BasicShellFactory(rightDamageCount, rightReloadSpeedCount),
					"Быстрый" => new FastShellFactory(rightDamageCount, rightReloadSpeedCount),
					"Заморозка" => new FreezeShellFactory(rightDamageCount, rightReloadSpeedCount),
					_ => new BasicShellFactory(rightDamageCount, rightReloadSpeedCount),
				};

				GameScene game = new(GameWindowSettings.Default, NWSettings, Menu, leftPlayerShellFactory, rightPlayerShellFactory);
				game.Run();
			}
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			Content = null;
		}
		private void AddLeftDamageButton_Click(object sender, RoutedEventArgs e)
		{
			if (_leftPoints > 0)
			{
				_leftDamage++;
				_leftPoints--;
				damageLeftLabel.Content = _leftDamage;
				pointsLeftLabel.Content = _leftPoints;
			}
		}

		private void RemoveLeftDamageButton_Click(object sender, RoutedEventArgs e)
		{
			if (_leftDamage > 0)
			{
				_leftDamage--;
				_leftPoints++;
				damageLeftLabel.Content = _leftDamage;
				pointsLeftLabel.Content = _leftPoints;
			}
		}

		private void AddReloadSpeedLeftButton_Click(object sender, RoutedEventArgs e)
		{
			if (_leftPoints > 0)
			{
				_leftReloadSpeed++;
				_leftPoints--;
				reloadSpeedLeftLabel.Content = _leftReloadSpeed;
				pointsLeftLabel.Content = _leftPoints;
			}
		}

		private void RemoveReloadSpeedLeftButton_Click(object sender, RoutedEventArgs e)
		{
			if (_leftReloadSpeed > 0)
			{
				_leftReloadSpeed--;
				_leftPoints++;
				reloadSpeedLeftLabel.Content = _leftReloadSpeed;
				pointsLeftLabel.Content = _leftPoints;
			}
		}

		private void AddRightDamageButton_Click(object sender, RoutedEventArgs e)
		{
			if (_rightPoints > 0)
			{
				_rightDamage++;
				_rightPoints--;
				damageRightLabel.Content = _rightDamage;
				pointsRightLabel.Content = _rightPoints;
			}
		}

		private void RemoveRightDamageButton_Click(object sender, RoutedEventArgs e)
		{
			if (_rightDamage > 0)
			{
				_rightDamage--;
				_rightPoints++;
				damageRightLabel.Content = _rightDamage;
				pointsRightLabel.Content = _rightPoints;
			}
		}

		private void AddReloadSpeedRightButton_Click(object sender, RoutedEventArgs e)
		{
			if (_rightPoints > 0)
			{
				_rightReloadSpeed++;
				_rightPoints--;
				reloadSpeedRightLabel.Content = _rightReloadSpeed;
				pointsRightLabel.Content = _rightPoints;
			}
		}

		private void RemoveReloadSpeedRightButton_Click(object sender, RoutedEventArgs e)
		{
			if (_rightReloadSpeed > 0)
			{
				_rightReloadSpeed--;
				_rightPoints++;
				reloadSpeedRightLabel.Content = _rightReloadSpeed;
				pointsRightLabel.Content = _rightPoints;
			}
		}

		private void AddTypeLeftButton_Click(object sender, RoutedEventArgs e)
		{
			if(_leftShellTypes.First().Points <= _leftPoints)
			{
				_leftPoints += _leftShellTypes.Last().Points;
				ShellType shellType = _leftShellTypes.Dequeue();
				var uri = new Uri(shellType.ImagePath, UriKind.Relative);
				leftShell.Source = new BitmapImage(uri);
				labelLeftShell.Content = shellType.Label;
				_leftShellTypes.Enqueue(shellType);
				_leftPoints -= shellType.Points;
				pointsLeftLabel.Content = _leftPoints;
			}
		}

		private void RemoveTypeLeftButton_Click(object sender, RoutedEventArgs e)
		{
			if (_leftShellTypes.First().Points <= _leftPoints)
			{
				_leftPoints += _leftShellTypes.Last().Points;
				ShellType shellType = _leftShellTypes.Dequeue();
				var uri = new Uri(shellType.ImagePath, UriKind.Relative);
				leftShell.Source = new BitmapImage(uri);
				labelLeftShell.Content = shellType.Label;
				_leftShellTypes.Enqueue(shellType);
				_leftPoints -= shellType.Points;
				pointsLeftLabel.Content = _leftPoints;
			}
		}

		private void AddTypeRightButton_Click(object sender, RoutedEventArgs e)
		{
			if (_rightShellTypes.First().Points <= _rightPoints)
			{
				_rightPoints += _rightShellTypes.Last().Points;
				ShellType shellType = _rightShellTypes.Dequeue();
				var uri = new Uri(shellType.ImagePath, UriKind.Relative);
				rightShell.Source = new BitmapImage(uri);
				labelRightShell.Content = shellType.Label;
				_rightShellTypes.Enqueue(shellType);
				_rightPoints -= shellType.Points;
				pointsRightLabel.Content = _rightPoints;
			}
		}

		private void RemoveTypeRightButton_Click(object sender, RoutedEventArgs e)
		{
			if (_rightShellTypes.First().Points <= _rightPoints)
			{
				_rightPoints += _rightShellTypes.Last().Points;
				ShellType shellType = _rightShellTypes.Dequeue();
				var uri = new Uri(shellType.ImagePath, UriKind.Relative);
				rightShell.Source = new BitmapImage(uri);
				labelRightShell.Content = shellType.Label;
				_rightShellTypes.Enqueue(shellType);
				_rightPoints -= shellType.Points;
				pointsRightLabel.Content = _rightPoints;
			}
		}
	}
}
