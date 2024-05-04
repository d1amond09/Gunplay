using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;

namespace Gunplay.Domain.Buffers;

public class ElementBuffer(uint[] data, BufferUsageHint hint) : BufferObject<uint>(data, hint)
{
	public override void Activate()
	{
		IsActive = true;
		GL.BindBuffer(BufferTarget.ElementArrayBuffer, Id);
	}

	public override void Deactivate()
	{
		IsActive = false;
		GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
	}

	protected override void SetType(BufferUsageHint hint)
	{
		if (Data.Length == 0)
			throw new ArgumentException("Массив не содежит ни одного элемента");

		Activate();
		GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(Data.Length * Marshal.SizeOf(typeof(uint))), Data, (BufferUsageHint)hint);
	}

	
}
