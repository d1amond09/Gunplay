using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Gunplay.Domain.Interfaces;
namespace Gunplay.Domain.Buffers;

public abstract class BufferObject<T> : IBuffer where T : struct
{
	private const int ERROR_CODE = -1;

	public int Id { get; set; }

    public bool IsActive { get; set; }

    public abstract T[] Data { get;  set; }

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
        GC.SuppressFinalize(this);
	}
}
