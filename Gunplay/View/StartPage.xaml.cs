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
		public Queue<ShellType> _shellTypes;

		private int _points;
		private int _damage;
		private int _reloadSpeed;


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

			_shellTypes = new([new(@"Images/freezeShell.png", "Заморозка", 3),
							   new(@"Images/fastShell.png", "Быстрый", 2), 
							   new(@"Images/basicShell.png", "Обычный", 0)]);

			_points = 10;
			_damage = 0;
			_reloadSpeed = 0;
			pointsLeftLabel.Content = _points;
			damageLeftLabel.Content = _damage;
			reloadSpeedLeftLabel.Content = _reloadSpeed;
		}

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{
			ShellFactory leftPlayerShellFactory;
			switch(labelLeftShell.Content)
			{
				case "Обычный":
					leftPlayerShellFactory = new BasicShellFactory();
					break;
				case "Быстрый":
					leftPlayerShellFactory = new FastShellFactory();
					break;
				case "Заморозка":
					leftPlayerShellFactory = new BasicShellFactory();
					break;
				default:
					leftPlayerShellFactory = new BasicShellFactory();
					break;
			}
			GameScene game = new(GameWindowSettings.Default, NWSettings, Menu, leftPlayerShellFactory, leftPlayerShellFactory);
			game.Run();
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			Content = null;
		}
		private void AddLeftDamageButton_Click(object sender, RoutedEventArgs e)
		{
			if (_points > 0)
			{
				_damage++;
				_points--;
				damageLeftLabel.Content = _damage;
				pointsLeftLabel.Content = _points;
			}
		}

		private void RemoveLeftDamageButton_Click(object sender, RoutedEventArgs e)
		{
			if (_damage > 0)
			{
				_damage--;
				_points++;
				damageLeftLabel.Content = _damage;
				pointsLeftLabel.Content = _points;
			}
		}

		private void AddReloadSpeedLeftButton_Click(object sender, RoutedEventArgs e)
		{
			if (_points > 0)
			{
				_reloadSpeed++;
				_points--;
				reloadSpeedLeftLabel.Content = _reloadSpeed;
				pointsLeftLabel.Content = _points;
			}
		}

		private void RemoveReloadSpeedLeftButton_Click(object sender, RoutedEventArgs e)
		{
			if (_reloadSpeed > 0)
			{
				_reloadSpeed--;
				_points++;
				reloadSpeedLeftLabel.Content = _reloadSpeed;
				pointsLeftLabel.Content = _points;
			}
		}

		private void AddRightDamageButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void RemoveRightDamageButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void AddReloadSpeedRightButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void RemoveReloadSpeedRightButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void AddTypeLeftButton_Click(object sender, RoutedEventArgs e)
		{
			if(_shellTypes.First().Points <= _points)
			{
				_points += _shellTypes.Last().Points;
				ShellType shellType = _shellTypes.Dequeue();
				var uri = new Uri(shellType.ImagePath, UriKind.Relative);
				leftShell.Source = new BitmapImage(uri);
				labelLeftShell.Content = shellType.Label;
				_shellTypes.Enqueue(shellType);
				_points -= shellType.Points;
				pointsLeftLabel.Content = _points;
			}
		}

		private void RemoveTypeLeftButton_Click(object sender, RoutedEventArgs e)
		{
			if (_shellTypes.First().Points <= _points)
			{
				_points += _shellTypes.Last().Points;
				ShellType shellType = _shellTypes.Dequeue();
				var uri = new Uri(shellType.ImagePath, UriKind.Relative);
				leftShell.Source = new BitmapImage(uri);
				labelLeftShell.Content = shellType.Label;
				_shellTypes.Enqueue(shellType);
				_points -= shellType.Points;
				pointsLeftLabel.Content = _points;
			}
		}
	}
}
