Shader "Custom/PostProcessPixelate"
{
	Properties
	{
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Pixelate ("Pixelate (A)", 2D) = "white" {}
		_PixelPower ("Pixel Power", Range(0,0.1)) = 0.05
	}
SubShader
{
	Pass
	{
		ZTest Always Cull Off ZWrite Off
				
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform sampler2D _Pixelate;
			uniform half4 _Pixelate_ST;
			uniform half _PixelPower;

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert( appdata_img v )
			{
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			float4 frag (v2f i) : SV_Target
			{
				fixed pix = tex2D(_Pixelate, i.uv * _Pixelate_ST.xy - _Pixelate_ST.zw).a;
				fixed2 pp = _PixelPower / _Pixelate_ST.xy;
				fixed2 uv = lerp(i.uv, round(i.uv / pp) * pp, pix);
				fixed4 color = tex2D(_MainTex, uv); 
				
				return color;
			}
		ENDCG

	}
}

Fallback off

}
