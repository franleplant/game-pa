using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDL2;
using static SDL2.SDL;
using System.Threading.Tasks;

namespace Game_pa
{
    class Renderer
    {
        public static IntPtr SDLRenderer;
        public static void Init(IntPtr SDLWindow)
        {
            SDLRenderer = SDL_CreateRenderer(SDLWindow, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
        }

        public static void ClearFrame()
        {
            SDL_RenderClear(SDLRenderer);
        }
        public static void SetRenderColor(byte r,byte g, byte b,byte a)
        {
            SDL_SetRenderDrawColor(Renderer.SDLRenderer,r,g,b,a);
        }
        public static void RenderPresent()
        {
            SDL_RenderPresent(Renderer.SDLRenderer);
        }

        public static void DrawRect(int _x, int _y, int _w, int _h)
        {
            SDL_Rect r = new SDL_Rect();
            r.x = _x;
            r.y = _y;
            r.w = _w;
            r.h = _h;
            SDL_RenderFillRect(SDLRenderer, ref r);
        }
    }
}
