using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gunplay;
using Gunplay.View;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Gunplay;

public partial class MainWindow : Window
{
    public int LeftPlayerPoints { get; set; }
    public int RightPlayerPoints { get; set; }
    public MainWindow()
	{
		InitializeComponent();
		LeftPlayerPoints = 0;
		RightPlayerPoints = 0;
	}

	private void PlayButton_Click(object sender, RoutedEventArgs e)
	{
		PageFrame.Content = new StartPage
		{
			Height = 805,
			Width = 1550,
			VerticalAlignment = VerticalAlignment.Center,
			HorizontalAlignment = HorizontalAlignment.Center,
			Menu = this
		};
	}

	private void CloseButton_Click(object sender, RoutedEventArgs e)
	{
		Close();
	}

	private void SettingsButton_Click(object sender, RoutedEventArgs e)
	{
		PageFrame.Content = new SettingsPage
		{
			VerticalAlignment = VerticalAlignment.Center,
			HorizontalAlignment = HorizontalAlignment.Center,
			DataContext = this
		};
	}
}