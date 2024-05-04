using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;

namespace Gunplay.Domain.Buffers;

public class ArrayBuffer(float[] data, BufferUsageHint hint) : BufferObject<float>(data, hint)
{
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
