#version 330
layout(location = 0) in vec3 aPosition;
layout(location = 1) in vec4 aColor;
layout(location = 2) in vec2 aTexture;
out vec2 TextureCoord;
out vec4 inColorFrag;
void main()
{
	TextureCoord = aTexture;
	gl_Position = vec4(aPosition, 1.0);
}
