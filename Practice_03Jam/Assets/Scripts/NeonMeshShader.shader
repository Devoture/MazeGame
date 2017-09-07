Shader "Unlit/NeonMeshShader"
{
	Properties
	{
		_GlowColor ("Glow Color", Color) = (0, 1, 0, 1)
		_FullGlowColor ("Max Color", Color) = (1, 1, 1, 1)
		_FillColor ("Fill Color", Color) = (0, 0, 0, 1)
		_Thickness ("Thickness", Float) = 1

	}
	SubShader
	{
		Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
		LOD 100

		Pass
		{
			Cull Off
			ZWrite On
            Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma geometry geom
			
			#include "UnityCG.cginc"
			struct v2g
			{
				float4 pos : POSITION;
			};
			struct g2f
			{
				float4 pos		: POSITION;		// fragment position
				float3 dist 	: TEXCOORD0;
			};
			
			v2g vert (appdata_base v)
			{
				v2g o;
				o.pos =  UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			[maxvertexcount(3)]
			void geom(triangle v2g p[3], inout TriangleStream<g2f> triStream)
			{
				// g2f pIn;
				// pIn.pos = p[0].pos;
				// pIn.barycentric = float3(1,0,0);
				// triStream.Append(pIn);

				// pIn.pos =  p[1].pos;
				// pIn.barycentric = float3(0,1,0);
				// triStream.Append(pIn);
				
				// pIn.pos = p[2].pos;
				// pIn.barycentric = float3(0,0,1);
				// triStream.Append(pIn);

				//points in screen space
				float2 p0 = _ScreenParams.xy * p[0].pos.xy / p[0].pos.w;
				float2 p1 = _ScreenParams.xy * p[1].pos.xy / p[1].pos.w;
				float2 p2 = _ScreenParams.xy * p[2].pos.xy / p[2].pos.w;
				
				//edge vectors
				float2 v0 = p2 - p1;
				float2 v1 = p2 - p0;
				float2 v2 = p1 - p0;

				//area of the triangle
				float area = abs(v1.x*v2.y - v1.y * v2.x);

				//values based on distance to the edges
				float dist0 = area / length(v0);
				float dist1 = area / length(v1);
				float dist2 = area / length(v2);
				
				g2f pIn;
				
				//add the first point
				pIn.pos = p[0].pos;
				pIn.dist = float3(dist0,0,0);
				triStream.Append(pIn);

				//add the second point
				pIn.pos =  p[1].pos;
				pIn.dist = float3(0,dist1,0);
				triStream.Append(pIn);
				
				//add the third point
				pIn.pos = p[2].pos;
				pIn.dist = float3(0,0,dist2);
				triStream.Append(pIn);
			}
			half4 _GlowColor;
			half4 _FillColor;
			half4 _FullGlowColor;
			float _Thickness;

			half4 frag (g2f i) : COLOR
			{
				float val = min( i.dist.x, min( i.dist.y, i.dist.z));
	
				//calculate power to 2 to thin the line
				val = exp2( -1/_Thickness * val * val);
					
				return val * val * _FullGlowColor + (val-val * val) * _GlowColor + ( 1 - val ) * _FillColor;
			}
			ENDCG
		}
	}
}
