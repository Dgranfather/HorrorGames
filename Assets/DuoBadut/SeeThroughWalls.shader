Shader "Custom/SeeThroughWalls" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5
    }

    SubShader {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        struct Input {
            float2 uv_MainTex;
        };

        fixed4 _Color;
        fixed _Cutoff;

        void surf (Input IN, inout SurfaceOutput o) {
            fixed4 texel = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = texel.rgb;
            o.Alpha = texel.a;
            o.Alpha *= _Color.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
