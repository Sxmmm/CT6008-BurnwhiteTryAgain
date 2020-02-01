﻿Shader "Unlit/ColourMinMax"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Effect("EffectAmount", range(-1, 1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

			float _Effect;

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

				float avgCol = (col.r + col.g + col.b) / 3;
				float polarity = min(sign(avgCol - 0.5), 0);

				col.rgb = col.rgb + ((polarity - col.rgb) * _Effect);

                return col;
            }
            ENDCG
        }
    }
}
