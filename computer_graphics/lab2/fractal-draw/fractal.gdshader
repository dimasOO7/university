shader_type canvas_item;

uniform sampler2D gradient_palette : repeat_disable;
uniform float x_min = -2.2;
uniform float x_max = 1.0;
uniform float y_min = -1.2;
uniform float y_max = 1.2;
vec2 complex_sqr(vec2 z) {
    return vec2(z.x * z.x * z.x - 3.0 * z.x * z.y * z.y, 3.0 * z.x * z.x * z.y - z.y*z.y*z.y);
}
void fragment() {
	float x0 = x_min + (x_max-x_min)*UV.x;
	float y0 = y_min + (y_max-y_min)*UV.y;
	vec2 z0 = vec2(x0,y0);
	vec2 z = z0;
	int i = 0;
	for(; i < 100; i++)
	{
		z = complex_sqr(z) + z0;
		float z_mod = z.x*z.x + z.y * z.y;
		if(z_mod > 4.0f)
		{
			break;
		}
	}
	
	COLOR = texture(gradient_palette, vec2( float(i) / 100.0));
	
}