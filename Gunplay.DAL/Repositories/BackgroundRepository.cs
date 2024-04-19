using Gunplay.DAL.Interfaces;
using Gunplay.Domain;
using Gunplay.Domain.Models;
using Gunplay.Domain.Models.Base;
namespace Gunplay.DAL;

public class BackgroundRepository : IBaseRepository<Background>
{
    public BackgroundRepository() { }
    public Background Get()
	{
		Vertex[] vertecies =
		{
			new(-1.0f, -1.0f),
			new( 1.0f, -1.0f),
			new(-1.0f,  1.0f),
			new( 1.0f,  1.0f)
		};
		var rctngl = new Rectangle(vertecies);

		return new Background(rctngl, @"data\img\Background.png");
	}
}
