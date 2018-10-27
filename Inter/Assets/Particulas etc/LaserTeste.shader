// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33038,y:32783,varname:node_4795,prsc:2|emission-2393-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32299,y:32609,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:acf143c0f2678c547b3c24a0a065bb59,ntxv:3,isnm:False|UVIN-953-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32722,y:32908,varname:node_2393,prsc:2|A-6074-RGB,B-2053-RGB,C-797-RGB,D-9248-OUT,E-500-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32275,y:32775,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32275,y:32932,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32259,y:33082,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:500,x:32469,y:33024,varname:node_500,prsc:2|A-6074-A,B-797-A;n:type:ShaderForge.SFN_Time,id:1275,x:32648,y:32523,varname:node_1275,prsc:2;n:type:ShaderForge.SFN_Vector1,id:5914,x:32476,y:32702,varname:node_5914,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:5904,x:32487,y:32572,varname:node_5904,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Append,id:3478,x:32660,y:32658,varname:node_3478,prsc:2|A-5904-OUT,B-5914-OUT;n:type:ShaderForge.SFN_Multiply,id:7141,x:32853,y:32718,varname:node_7141,prsc:2|A-1275-T,B-3478-OUT;n:type:ShaderForge.SFN_TexCoord,id:2559,x:32822,y:32523,varname:node_2559,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:953,x:33019,y:32629,varname:node_953,prsc:2|A-2559-UVOUT,B-7141-OUT;proporder:6074-797;pass:END;sub:END;*/

Shader "Shader Forge/LaserTeste" {
    Properties {
        _MainTex ("MainTex", 2D) = "bump" {}
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_1275 = _Time;
                float2 node_953 = (i.uv0+(node_1275.g*float2(0.8,0.0)));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_953, _MainTex));
                float3 emissive = (_MainTex_var.rgb*i.vertexColor.rgb*_TintColor.rgb*2.0*(_MainTex_var.a*_TintColor.a));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
