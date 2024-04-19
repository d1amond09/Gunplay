using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace Gunplay.Domain.Buffers;

public class ElementBuffer : BufferObject<uint>
{
    public override uint[] Data { get; set; }

    public ElementBuffer(uint[] data, BufferUsageHint hint)
	{
		Id = GL.GenBuffer();
		Data = data;

		SetType(hint);
	}

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
