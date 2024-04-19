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
	}
}
