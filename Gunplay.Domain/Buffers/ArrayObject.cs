using OpenTK.Graphics.OpenGL;
using Gunplay.Domain.Textures;
using Gunplay.Domain.Interfaces;

namespace Gunplay.Domain.Buffers;

public class ArrayObject(ArrayBuffer vertexBuffer, 
						 ElementBuffer elementBuffer, 
						 Texture texture) : IBuffer
{
	private const int ERROR_CODE = -1;

	private readonly List<int> _attribsList = [];
	private readonly Texture _texture = texture;

	public int Id { get; private set; } = GL.GenVertexArray();
	public ElementBuffer ElementBuffer { get; private set; } = elementBuffer;
	public ArrayBuffer ArrayBuffer { get; private set; } = vertexBuffer;

	public void Activate() => GL.BindVertexArray(Id);
	public void Deactivate() => GL.BindVertexArray(0);
	
	public void AttachBuffers()
	{
		Activate();
		ArrayBuffer.Activate();
		ElementBuffer.Activate();
	}

	public void AttribPointer(int index, int elementsPerVertex, int offset)
	{
		AttachBuffers();
		_attribsList.Add(index);
		GL.EnableVertexAttribArray(index);
		GL.VertexAttribPointer(index, elementsPerVertex, VertexAttribPointerType.Float, false, 5 * sizeof(float), offset);
	}
	public void Draw(int start, int count)
	{
		Activate();
		GL.DrawArrays(PrimitiveType.Triangles, start, count);
	}
	public void DrawElements(int start, DrawElementsType type, int index)
	{
		Activate();
		GL.Uniform1(index, 0);
		GL.ActiveTexture(TextureUnit.Texture0);
		GL.BindTexture(TextureTarget.Texture2D, _texture.Handle);
		GL.DrawElements(PrimitiveType.Triangles, ElementBuffer.Data.Length, type, start);
	}
	public void DisableAttribAll()
	{
		foreach (int attrib in _attribsList)
			GL.DisableVertexAttribArray(attrib);
	}
	public void Delete()
	{
		if (Id == ERROR_CODE) return;

		Deactivate();
		GL.DeleteVertexArray(Id);

		ArrayBuffer.Dispose();
		ElementBuffer.Dispose();

		Id = ERROR_CODE;
	}
	public void Dispose()
	{
		DisableAttribAll();
		Delete();
		GC.SuppressFinalize(this);
	}
}


