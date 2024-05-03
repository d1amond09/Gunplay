namespace Gunplay.DAL.Interfaces;

public interface IFactory<TEntity>
{
	TEntity Create();
}
