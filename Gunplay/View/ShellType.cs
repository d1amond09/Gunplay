namespace Gunplay.View;

public class ShellType(string imagePath, string label, int points)
{
	public string ImagePath { get; set; } = imagePath;
	public string Label { get; set; } = label;
	public int Points { get; set; } = points;
}
