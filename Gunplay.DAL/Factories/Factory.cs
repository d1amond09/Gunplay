namespace Gunplay.DAL.Repositories;

public abstract class Factory<TEntity>
{
	public abstract TEntity Create();
}
