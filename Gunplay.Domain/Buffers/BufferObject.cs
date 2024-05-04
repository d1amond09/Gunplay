using OpenTK.Graphics.OpenGL;
using Gunplay.Domain.Interfaces;

namespace Gunplay.Domain.Buffers;

public abstract class BufferObject<T> : IBuffer where T : struct
{
	private const int ERROR_CODE = -1;

	public int Id { get; protected set; }
    public bool IsActive { get; protected set; }
	public T[] Data { get; protected set; }
	
    public BufferObject(T[] data, BufferUsageHint hint)
	{
		Id = GL.GenBuffer();
		Data = data;
		SetType(hint);
	}

    public abstract void Activate();
    public abstract void Deactivate();
    protected abstract void SetType(BufferUsageHint hint);

    public void Delete()
    {
        if (Id == ERROR_CODE) return;

        Deactivate();
        GL.DeleteBuffer(Id);
        Id = ERROR_CODE;
    }

	public void Dispose()
	{
        Delete();
	}
}
