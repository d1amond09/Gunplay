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
	private readonly IBaseRepository<Background> _backgroundRepository;

	public Background Background { get; private set; }

	public BackgroundController(IBaseRepository<Background> backgroundRepository)
    {
        _backgroundRepository = backgroundRepository;
		Background = _backgroundRepository.Get();
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
