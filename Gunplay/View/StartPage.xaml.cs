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
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Gunplay.View
{
	public partial class StartPage : Page
	{
		public MainWindow Menu { get; set; } = default!;

		private int _points;
		private int _damage;
		private int _reloadSpeed;


		private NativeWindowSettings NWSettings => new()
		{
			WindowState = OpenTK.Windowing.Common.WindowState.Maximized,
			//WindowBorder = WindowBorder.Hidden,
			StartFocused = true,
			StartVisible = true,

			Flags = ContextFlags.ForwardCompatible,         //ForwardCompatible
			APIVersion = new Version(4, 6),         //4,6
			Profile = ContextProfile.Core,  //Core
			API = ContextAPI.OpenGL,
		};

		public GameScene GameScene =>
			new(GameWindowSettings.Default, NWSettings, Menu);

		public StartPage()
		{
			InitializeComponent();
			_points = 10;
			_damage = 0;
			_reloadSpeed = 0;
			pointsLeftLabel.Content = _points;
			damageLeftLabel.Content = _damage;
			reloadSpeedLeftLabel.Content = _reloadSpeed;
		}

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{
			Menu.Hide();
			GameScene.Run();
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
	}
}
