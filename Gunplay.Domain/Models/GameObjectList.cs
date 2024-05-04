using Gunplay.Domain.Buffers;

namespace Gunplay.Domain.Models;

public class GameObjectList<T> 
			 where T : GameObject
{
	private List<T> _gameObjects;
	private ArrayObjectCollection _arrayObjects;

	public GameObjectList(IEnumerable<T> gameObjects)
	{
		_gameObjects = [.. gameObjects];
		_arrayObjects = new(_gameObjects.Select(g => g.ArrayObject).ToArray());
	}

	public void Add(T entity)
	{
		_gameObjects.Add(entity);
		_arrayObjects = new(_gameObjects.Select(g => g.ArrayObject).ToArray());
	}

	public void Remove(T entity)
	{
		_gameObjects.Remove(entity);
		_arrayObjects.Remove(entity.ArrayObject);
	}

	public void AddBegin(T entity)
	{
		int index = 1;
		List<T> list = _gameObjects.GetRange(index, _gameObjects.Count - index);
		_gameObjects.Insert(index, entity);
		_gameObjects.AddRange(list);
		_arrayObjects = new(_gameObjects.Select(g => g.ArrayObject).ToArray());
	}

	public void Draw()
	{
		_arrayObjects.DrawAll();
	}

	public void Dispose()
	{
		_gameObjects = [];
		_arrayObjects.Dispose();
	}

}
