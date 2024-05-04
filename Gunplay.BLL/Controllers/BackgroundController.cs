using Gunplay.Creation.Factories;
using Gunplay.Domain.Models;

namespace Gunplay.Control.Controllers;

public class BackgroundController
{
	private readonly Factory<Background> _backgroundFactory;

	public Background Background { get; private set; }

	public BackgroundController(Factory<Background> backgroundFactory)
    {
		_backgroundFactory = backgroundFactory;
		Background = _backgroundFactory.Create();
    }

	public void Draw(int textureIndex)
	{
		Background.Draw(textureIndex);
	}

	public void Deactivate()
	{
		Background.Dispose();
	}
}
