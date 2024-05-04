namespace Gunplay.Creation.Factories;

public abstract class Factory<TEntity>
{
	public abstract TEntity Create();
}
