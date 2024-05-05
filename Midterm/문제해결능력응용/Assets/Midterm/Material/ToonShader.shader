SShader"Custom/ToonShader"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _ShadowIntensity("Shadow Intensity", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
LOD200
        
        CGPROGRAM
        #pragma surface surf Toon

sampler2D _MainTex;
fixed4 _Color;
float _ShadowIntensity;

struct Input
{
    float2 uv_MainTex;
    float3 worldNormal;
            INTERNAL_DATA
};

void surf(Input IN, inout SurfaceOutput o)
{
    fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
    float lighting = dot(normalize(IN.worldNormal), float3(0.5, 0.5, -1)); // 조명의 강도 계산
    lighting = clamp(lighting, 0, 1); // 조명의 강도를 0과 1 사이로 제한
    float shadow = 1 - _ShadowIntensity; // 그림자 효과 계산
    o.Albedo = c.rgb * lighting * shadow; // 색상에 조명의 강도와 그림자 효과를 곱하여 적용
    o.Alpha = c.a;
}
        ENDCG
    }
FallBack"Diffuse"
}
