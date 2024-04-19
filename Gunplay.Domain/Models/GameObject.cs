using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunplay.Domain.Buffers;
using OpenTK.Graphics.OpenGL;

namespace Gunplay.Domain.Models;

public abstract class GameObject : IDisposable
{
	public ArrayBuffer ArrayBuffer { get; set; } = default!;
	public ArrayObject ArrayObject { get; set; } = default!;

    public void Draw(int textureIndex)
	{
		ArrayObject.DrawElements(0, DrawElementsType.UnsignedInt, textureIndex);
	}

	public void Update()
	{
		ArrayBuffer.UpdateData();
	}

    public void Dispose()
	{
		ArrayObject.Dispose();
		ArrayBuffer.Dispose();
	}
}
