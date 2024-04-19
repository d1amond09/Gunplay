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
	public MainWindow()
	{
		InitializeComponent();
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
			Height = 400,
			Width = 600,
			VerticalAlignment = VerticalAlignment.Center,
			HorizontalAlignment = HorizontalAlignment.Center,
			DataContext = this
		};
	}
}