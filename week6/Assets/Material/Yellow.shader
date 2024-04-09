Shader "Unlit/Yellow"
{
    Properties
    {
        //_MainTex ("Texture", 2D) = "white" {}
        _DiffuseColor("DiffuseColor", Color) = (1,1,1.1)
        _LightDirection("LightDirection", Vector) = (1,-1,-1,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }//불투명한, Transparent를 쓰면 투명해진다, alpha값을 사용할지 사용하는 설정
        LOD 100

        Pass
        {
            CGPROGRAM
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members viewDirection)
#pragma exclude_renderers d3d11
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            //#pragma multi_compile_fog

            #include "UnityCG.cginc"//유니티용 c#으로 쉐이더 만드는 라이브러리

            struct appdata
            {
                float4 vertex : POSITION;//버텍스
                //float2 uv : TEXCOORD0;//조명
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;//시멘틱 
                float3 normal : NORMAL;
                float3 viewDirection;
            };

            float4 _DiffuseColor;
            float4 _LightDirection;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                o.viewDirection = normalize(_WorldSpaceCameraPos - v.vertex.xyz);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                //fixed4 col = float4(1.0f,1.0f,0.0f,1.0f);
                float lightDir = normalize(_LightDirection);
                float lightIntensity = (dot(i.normal,lightDir),0);
                float4 ViewerVector = viewDirection;
                
                float4 DiffuseResult = _DiffuseColor * lightIntensity;
                float4 ReflectVectorResult = reflect(-lightDir,i.normal);
                float4 SpecularResult = pow(max(dot(ReflectVectorResult * ViewerVector),0), lightIntensity);
                float4 FinalResult = DiffuseResult * ReflectVectorResult * SpecularResult;
                return float4(FinalResult);
            }
            ENDCG
        }
    }
}
