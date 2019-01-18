Shader "Custom Shader" {
	Properties{
		_MainTex("Texture", 2D) = "white" {}
	_ColorTint("Tint", Color) = (0.3, 1.0, 0.26, 1.0)
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		CGPROGRAM
#pragma surface surf Lambert finalcolor:mycolor
		struct Input {
		float2 uv_MainTex;
	};
	fixed4 _ColorTint;
	void mycolor(Input IN, SurfaceOutput o, inout fixed4 color)
	{
		color *= _ColorTint;
	}
	sampler2D _MainTex;
	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
	}
	ENDCG
	}
		Fallback "Diffuse"
}