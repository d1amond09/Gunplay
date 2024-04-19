using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Audio.OpenAL;
using OpenTK.Graphics.OpenGL;

namespace Gunplay.Domain.Buffers;

public class ArrayBuffer : BufferObject<float>
{
	public override float[] Data { get; set; }

	public ArrayBuffer(float[] data, BufferUsageHint hint)
	{
		Id = GL.GenBuffer();

		Data = data;
		SetType(hint);
	}

	public override void Activate()
	{
		IsActive = true;
		GL.BindBuffer(BufferTarget.ArrayBuffer, Id);
	}

	public override void Deactivate()
	{
		IsActive = false;
		GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
	}

	protected override void SetType(BufferUsageHint hint)
	{
		if (Data.Length == 0)
			throw new ArgumentException("Массив не содежит ни одного элемента");

		Activate();
		GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(Data.Length * Marshal.SizeOf(typeof(float))), Data, hint);
	}

	public void UpdateData()
	{
		Activate();
		GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(Data.Length * Marshal.SizeOf(typeof(float))), Data, BufferUsageHint.DynamicDraw);
	}
}
