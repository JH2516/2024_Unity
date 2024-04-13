Shader"Custom/ToonShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
LOD100

        CGPROGRAM
        #pragma surface surf Lambert

struct Input
{
    float2 uv_MainTex;
    float3 worldNormal;
};

sampler2D _MainTex;
fixed4 _Color;

void surf(Input IN, inout SurfaceOutput o)
{
    fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
    o.Albedo = c.rgb;
    o.Alpha = c.a;

            // 카툰 쉐이딩을 위한 그림자 계산
    half dotProduct = dot(IN.worldNormal, float3(0, 0, -1));
    half step = clamp(dotProduct * 4, 0, 1);
    o.Albedo *= step;
}
        ENDCG
    }
FallBack"Diffuse"
}
