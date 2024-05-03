using Gunplay.DAL.Interfaces;
using Gunplay.DAL.Repositories;
using Gunplay.Domain;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Base;
namespace Gunplay.DAL;

public class BackgroundFactory : Factory<Background>
{
	private readonly Rectangle _backgroungRctngl;

    public BackgroundFactory() 
	{
		_backgroungRctngl = new(new(-1.0f, -1.0f), new(1.0f, -1.0f),
								new(-1.0f, 1.0f), new(1.0f, 1.0f));
	}

	public override Background Create()
	{
		return new Background(_backgroungRctngl, @"data\img\Background.png");
	}
}
