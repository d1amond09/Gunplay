using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
namespace Gunplay.Domain.Textures;

public class ShaderProgram
{
	private readonly int _id;
	private readonly int _vertexShaderIndex;
	private readonly int _fragmentShaderIndex;
	public ShaderProgram(string vertexFile, string fragmentFile) 
	{

		var vertexShader = new Shader(ShaderType.VertexShader, vertexFile);
		var fragmentShader = new Shader(ShaderType.FragmentShader, fragmentFile);

		_vertexShaderIndex = vertexShader.Id;
		_fragmentShaderIndex = fragmentShader.Id;

		_id = GL.CreateProgram();

		GL.AttachShader(_id, _vertexShaderIndex);
		GL.AttachShader(_id, _fragmentShaderIndex);

		GL.LinkProgram(_id);
		GL.GetProgram(_id, GetProgramParameterName.LinkStatus, out var code);

		if (code == 0)
		{
			var infolog = GL.GetProgramInfoLog(_id);
			throw new Exception($"Error in compile program shader #{_id}\n{infolog}");
		}

		vertexShader.Delete(_id);
		fragmentShader.Delete(_id);
	}

	public void Active() => GL.UseProgram(_id);

	public void Deactive() => GL.UseProgram(0);

	public void Delete() => GL.DeleteProgram(_id);

	public int GetLocation(string attribute) =>
		GL.GetAttribLocation(_id, attribute);
}
