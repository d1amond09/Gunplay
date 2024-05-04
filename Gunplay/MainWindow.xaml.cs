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

	public MediaPlayer MediaPlayer { get; set; }
	public int FPS { get; set; }

	public MainWindow()
	{
		InitializeComponent();
		MediaPlayer = new();
		MediaPlayer.Open(new Uri(@"..\..\..\data\music\Music.mp3", UriKind.RelativeOrAbsolute));
		MediaPlayer.Play();
		LeftPlayerPoints = 0;
		RightPlayerPoints = 0;
		FPS = 0;
		MediaPlayer.MediaEnded += MediaPlayer_MediaEnded!;
	}

	private void MediaPlayer_MediaEnded(object sender, EventArgs e)
	{
		MediaPlayer.Position = TimeSpan.Zero;
	}

	private void PlayButton_Click(object sender, RoutedEventArgs e)
	{
		PageFrame.Content = new StartPage(this)
		{
			Height = 850,
			Width = 1550,
			VerticalAlignment = VerticalAlignment.Center,
			HorizontalAlignment = HorizontalAlignment.Center,
		};
	}

	private void CloseButton_Click(object sender, RoutedEventArgs e)
	{
		MediaPlayer.Stop();
		Close();
	}

	private void SettingsButton_Click(object sender, RoutedEventArgs e)
	{
		PageFrame.Content = new SettingsPage(this)
		{
			Height = 400,
			Width = 650,
			VerticalAlignment = VerticalAlignment.Center,
			HorizontalAlignment = HorizontalAlignment.Center,
			DataContext = this,
		};
	}
}