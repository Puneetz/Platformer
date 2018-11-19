Shader "Sprites/Tint"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}

        _Body("Body", Color) = (0.71, 0.26, 0.18, 1)
		_Head("Head", Color) = (0.91, 0.47, 0.22, 1)
		_AccentLight("Accent Light", Color) = (0.94, 0.73, 0.54, 1)
		_AccentDark("Accent Dark", Color) = (0.64, 0.44, 0.31, 1)

        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
 
    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }
 
        Cull Off
        Lighting Off
        ZWrite Off
        Fog { Mode Off }
        Blend SrcAlpha OneMinusSrcAlpha
 
        Pass
        {
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma multi_compile DUMMY PIXELSNAP_ON

            #include "UnityCG.cginc"
           
            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
            };
 
            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                half2 texcoord  : TEXCOORD0;
            };
 
            v2f vert(appdata_t IN)
            {
                v2f OUT;

                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color;

                #ifdef PIXELSNAP_ON
                OUT.vertex = UnityPixelSnap(OUT.vertex);
                #endif
 
                return OUT;
            }
 
            sampler2D _MainTex;

			fixed4 _Body;
			fixed4 _Head;
			fixed4 _AccentLight;
			fixed4 _AccentDark;

			static const fixed4 BodyDefault = fixed4(0.71, 0.26, 0.18, 1);
			static const fixed4 HeadDefault = fixed4(0.91, 0.47, 0.22, 1);
			static const fixed4 AccentLightDefault = fixed4(0.94, 0.73, 0.54, 1);
            static const fixed4 AccentDarkDefault = fixed4(0.64, 0.44, 0.31, 1);

            fixed4 frag(v2f IN) : COLOR
            {
                half4 texcol = tex2D(_MainTex, IN.texcoord);

				if (distance(texcol, BodyDefault) < 0.01)
				{
					texcol = _Body;
				}
				else if (distance(texcol, HeadDefault) < 0.01)
				{
					texcol = _Head;
				}
				else if (distance(texcol, AccentLightDefault) < 0.01)
				{
					texcol = _AccentLight;
				}
				else if (distance(texcol, AccentDarkDefault) < 0.01)
				{
					texcol = _AccentDark;
				}

                return texcol * IN.color;
            }

        ENDCG
        }
    }

    Fallback "Sprites/Default"
}