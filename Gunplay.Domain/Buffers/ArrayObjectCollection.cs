using System.Collections;
using OpenTK.Graphics.OpenGL;
using Gunplay.Domain.Textures;

namespace Gunplay.Domain.Buffers;

public class ArrayObjectCollection : IEnumerable<ArrayObject>
{
	private readonly List<ArrayObject> _arrayObjects;
	private readonly ShaderProgram _shaderProgram;
	
	public int Count => _arrayObjects.Count;
	public int VertexIndex => _shaderProgram.GetLocation("aPosition");
	public int TextureIndex => _shaderProgram.GetLocation("aTexture");

	public ArrayObjectCollection(params ArrayObject[] arrayObjects)
	{
		_shaderProgram = new(@"data\shaders\shader_base.vert",
							 @"data\shaders\shader_base.frag");
		_arrayObjects = [.. arrayObjects];
		AttribPointerVertecies();
		AttribPointerTextures();
		DeactivateAll();
	}


	public void Remove(ArrayObject arrayObject)
	{
		foreach (ArrayObject item in _arrayObjects)
		{
			if(item.Id == arrayObject.Id)
			{
				_arrayObjects.Remove(item);
				return;
			}
		}
	}

	public void DrawAll()
	{
		_shaderProgram.Active();

		foreach (ArrayObject item in _arrayObjects)
			item.DrawElements(0, DrawElementsType.UnsignedInt, TextureIndex);

		_shaderProgram.Deactive();
	}

	public void DeactivateAll()
	{
		foreach(ArrayObject item in _arrayObjects)
		{
			item.Deactivate();
			item.DisableAttribAll();
		}
	}

	public void Dispose()
	{
		DeactivateAll();
		_shaderProgram.Delete();
	}

	public void AttribPointerVertecies()
	{
		foreach (ArrayObject item in _arrayObjects)
			item.AttribPointer(VertexIndex, 3, 0);
	}

	public void AttribPointerColors(int index)
	{
		foreach (ArrayObject item in _arrayObjects)
			item.AttribPointer(index, 4, 3 * sizeof(float));
	}

	public void AttribPointerTextures()
	{
		foreach (ArrayObject item in _arrayObjects)
			item.AttribPointer(TextureIndex, 2, 3 * sizeof(float));
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _arrayObjects.GetEnumerator();
	}

	public IEnumerator<ArrayObject> GetEnumerator()
	{
		return GetEnumerator();
	}
}
