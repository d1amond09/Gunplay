#version 330
in vec4 inColorFrag;
in vec2 TextureCoord;
uniform sampler2D textureSampler;
out vec4 outColor;

void main()
{
	outColor = texture(textureSampler, TextureCoord);
}