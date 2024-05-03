using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Buffers;

namespace Gunplay.Domain.Models;

public class GameObjectList<T> where T : GameObject
{
	private List<T> _gameObjects;
	private ArrayObjectCollection _arrayObjectCollection;
	public GameObjectList(List<T> gameObjects)
	{
		_gameObjects = gameObjects;
		_arrayObjectCollection = new(_gameObjects.Select(g => g.ArrayObject).ToArray());
	}

	public void Add(T entity)
	{
		_gameObjects.Add(entity);
		_arrayObjectCollection = new(_gameObjects.Select(g => g.ArrayObject).ToArray());
	}

	public void Remove(T entity)
	{
		_gameObjects.Remove(entity);
		_arrayObjectCollection.Remove(entity.ArrayObject);
	}

	public void AddBegin(T entity)
	{
		int index = 1;
		List<T> list = _gameObjects.GetRange(index, _gameObjects.Count - index);
		_gameObjects.Insert(index, entity);
		_gameObjects.AddRange(list);
		_arrayObjectCollection = new(_gameObjects.Select(g => g.ArrayObject).ToArray());
	}

	public void Draw()
	{
		_arrayObjectCollection.DrawAll();
	}

	public void Dispose()
	{
		_gameObjects = [];
		_arrayObjectCollection.Dispose();
	}

}
