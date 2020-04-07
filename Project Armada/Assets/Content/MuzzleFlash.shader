Shader "Coral/MuzzleFlash"
{
    Properties
    {
        _MainTex ("Muzzle Flash", 2D) = "white" {}
        _GradientMap ("Gradient Map", 2D) = "white" {}
        [HDR] _EmissionPower ("Emission Power", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
		Cull Off
        LOD 100
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha 

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _GradientMap;
            float4 _MainTex_ST;
            float4 _GradientMap_ST;
            fixed4 _EmissionPower;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                // Grayscale the main texture
                float gray = dot(col.rgb, float3(0.3, 0.59, 0.11));
                // Gradient map the texture
                fixed4 gradSample = tex2D(_GradientMap, float2(gray, 0));
                // UNITY_APPLY_FOG(i.fogCoord, gradSample);
                return fixed4(gradSample.rgb, gray) * _EmissionPower;
            }
            ENDCG
        }
    }
}
