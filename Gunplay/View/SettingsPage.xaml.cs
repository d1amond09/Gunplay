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
using Gunplay.Domain.Textures;

namespace Gunplay.View
{
	public partial class SettingsPage : Page
	{
		public MainWindow Menu { get; set; }
		public SettingsPage(MainWindow menu)
		{
			Menu = menu;
			InitializeComponent();
			musicSlider.Value = menu.MediaPlayer.Volume;
			switch(Menu.FPS)
			{
				case 90: fps90.IsChecked = true; break;
				case 144: fps144.IsChecked = true; break;
				default: fpsAuto.IsChecked = true; break;
			}
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			Content = null;
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			ArgumentNullException.ThrowIfNull(fps90.IsChecked);
			ArgumentNullException.ThrowIfNull(fps144.IsChecked);

			if (fps90.IsChecked.Value) Menu.FPS = 90;
			else if (fps144.IsChecked.Value) Menu.FPS = 144;
			else Menu.FPS = 0;
			Content = null;
		}

		private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if(sender is Slider slider)
			{
				Menu.MediaPlayer.Volume = slider.Value;
			}
		}
	}
}
