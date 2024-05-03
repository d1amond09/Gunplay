using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.DAL.Interfaces;
using Gunplay.Domain.Models;

namespace Gunplay.BLL.Controllers;

public class BackgroundController
{
	private readonly IFactory<Background> _backgroundFactory;

	public Background Background { get; private set; }

	public BackgroundController(IFactory<Background> backgroundFactory)
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
