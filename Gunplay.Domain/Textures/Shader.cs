using OpenTK.Graphics.OpenGL4;

namespace Gunplay.Domain.Textures;

public class Shader
{
	private const int NONE_ID = 0;

	public int Id { get; set; }

    public Shader(ShaderType shaderType, string shaderFile) 
	{ 
		Id = GL.CreateShader(shaderType);

		string shader = File.ReadAllText(shaderFile);
		GL.ShaderSource(Id, shader);
		GL.CompileShader(Id);

		GL.GetShader(Id, ShaderParameter.CompileStatus, out var code );
		
		if (code == NONE_ID)
		{
			var infolog = GL.GetShaderInfoLog(Id);
			throw new Exception($"Error in compile shader #{Id}\n{infolog}");
		}
	}

	public void Delete(int prograId)
	{
		GL.DetachShader(prograId, Id);
		GL.DeleteShader(Id);
	}
}
