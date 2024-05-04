using Gunplay.DAL.Repositories;
using Gunplay.Domain;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Geometry;
using Gunplay.Domain.Textures;
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
		Texture texture = Texture.LoadFromFile(@"data\img\Background.png");
		return new Background(_backgroungRctngl, texture);
	}
}
