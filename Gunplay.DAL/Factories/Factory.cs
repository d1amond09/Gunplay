using Gunplay.DAL.Interfaces;

namespace Gunplay.DAL.Repositories;

public abstract class Factory<TEntity> : IFactory<TEntity>
{
	public abstract TEntity Create();
}
