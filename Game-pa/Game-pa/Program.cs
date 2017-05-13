using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using static SDL2.SDL;



namespace Game_pa
{
    class Program
    {

        static List<Entity> Entities = new List<Entity>();

        static void Main(string[] args)
        {
            SDL_Init(SDL_INIT_VIDEO);
            var SDLWindow = SDL_CreateWindow("Ay", 50, 50, 1600, 900, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
            bool Quitting = false;
            if (SDLWindow != IntPtr.Zero)
            {
                var SDLSurface = SDL_GetWindowSurface(SDLWindow);
                Renderer.Init(SDLWindow);

                Player Character = new Player();
                Character.Init();
                Entities.Add(Character);

                Input.Init();

                while (!Quitting)
                {
                    Renderer.SetRenderColor(15, 9, 9, 255);
                    Renderer.ClearFrame();

                    Input.InitFrameInput();

                    SDL_Event CurrentEvent = new SDL.SDL_Event();
                    while (SDL_PollEvent(out CurrentEvent) != 0)
                    {
                        if (CurrentEvent.type == SDL_EventType.SDL_QUIT)
                        {
                            Quitting = true;
                        }
                        else if (CurrentEvent.type == SDL_EventType.SDL_KEYDOWN)
                        {
                            Input.UpdateFrameInput(CurrentEvent,true);
                        }
                        else if (CurrentEvent.type == SDL_EventType.SDL_KEYUP)
                        {
                            Input.UpdateFrameInput(CurrentEvent,false);
                        }
                    }

                    foreach (Entity ent in Entities)
                        ent.Loop(0.1666f); //vsync esta activado
                    
                    foreach (Entity ent in Entities)
                        ent.Draw();

                    Renderer.RenderPresent();

                }
            }
        }
    }
}
