Shader "Coral/Muzzle Flash (HDR)"
{
	Properties
    {
        _MainTex ("Muzzle Flash", 2D) = "white" {}
        _GradientMap ("Gradient Map", 2D) = "white" {}
        _DetailMap ("Detail Map", 2D) = "white" {}
        [HDR] _EmissionColor ("Emission Power", Color) = (1, 1, 1, 1)
		_Alpha ("Alpha", Float) = 0.0
	}
	SubShader {
		Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
		LOD 200
		Cull Off

		CGPROGRAM
		#include "Assets/Developer/Rendering/ShaderLibraries/WesHelpers.cginc"
		#include "Assets/Developer/Rendering/ShaderLibraries/noiseSimplex.cginc"
		#pragma surface surf SimpleRGBA noforwardadd noambient alpha vertex:vert
		#pragma target 4.0

		sampler2D _MainTex, _GradientMap, _DetailMap;
		fixed4 _EmissionColor;
		fixed _Alpha;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		struct Input {
			float2 uv_MainTex;
            float2 uv_GradientMap;
			float2 uv_DetailMap;
			float fresnel;
			float3 pos;
		};

		void vert(inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);

			// Fresnel Rim Parameters
			half _RimWidth = 0.64;

			o.fresnel = wesFresnel(v.vertex, v.normal, _RimWidth);
			o.pos = UnityObjectToClipPos(v.vertex).xyz;
		}

		void surf (Input IN, inout SurfaceOutput o) {
            fixed4 col = tex2D(_MainTex, IN.uv_MainTex);
			float noise = tex2D(_DetailMap, IN.uv_DetailMap + float2(_Time.y, _Time.y)).r;
            // Grayscale the main texture
            float gray = col.r;
			gray = lerp(gray, clamp(gray + (noise * 2 * 0.37), 0.0, 1.0), 0.18);
            // Gradient map the texture
            fixed4 gradSample = tex2D(_GradientMap, float2(clamp(gray + (0.1 * _Alpha), 0.0, 1.0), 0));
            float graySample = dot(gradSample.rgb, float3(0.3, 0.59, 0.11));
            // Emission/Masking
            fixed4 outCol = fixed4(gradSample.rgb, graySample * gray) * _EmissionColor;
            // -- OUTPUTS
			o.Albedo = outCol;
			o.Alpha = clamp((gray - ((1.0 - _Alpha) * 0.8)) * graySample, 0.0, 1.0) * clamp(ceil(_Alpha), 0.0, 1.0);
			o.Emission = outCol;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
