using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;
using SDL2;

namespace Game_pa
{

    class ButtonState
    {
        public ButtonState() { }

        public bool WasDown;
        public bool IsDown;

        public bool PressedThisFrame()
        {
            return (IsDown && !WasDown);
        }
    }



    static class Input
    {

        public enum ArrowKeysID { ARROW_UP = 0, ARROW_RIGHT, ARROW_DOWN, ARROW_LEFT }
        public enum ActionKeysID { JUMP = 0 }

        public static ButtonState[] ArrowKeys = new ButtonState[4] ;
        public static ButtonState[] ActionKeys = new ButtonState[1] ;

        static public void InitFrameInput()
        {
            for (int i=0;i<ArrowKeys.Length;i++)
            {
                ArrowKeys[i].WasDown = ArrowKeys[i].IsDown;
              //  ArrowKeys[i].IsDown = false;
            }

            for (int i = 0; i < ActionKeys.Length; i++)
            {
                ActionKeys[i].WasDown = ActionKeys[i].IsDown;
              //  ActionKeys[i].IsDown = false;
            }
        }

        static public void UpdateFrameInput(SDL_Event Event, Boolean IsDown)
        {
            //aca se remappearian los controles si fueran remappeabels
            if (Event.key.keysym.sym == SDL_Keycode.SDLK_UP)
                ArrowKeys[(int)ArrowKeysID.ARROW_UP].IsDown = IsDown;

            if (Event.key.keysym.sym == SDL_Keycode.SDLK_RIGHT)
                ArrowKeys[(int)ArrowKeysID.ARROW_RIGHT].IsDown = IsDown;

            if (Event.key.keysym.sym == SDL_Keycode.SDLK_DOWN)
                ArrowKeys[(int)ArrowKeysID.ARROW_DOWN].IsDown = IsDown;

            if (Event.key.keysym.sym == SDL_Keycode.SDLK_LEFT)
                ArrowKeys[(int)ArrowKeysID.ARROW_LEFT].IsDown = IsDown;

            if (Event.key.keysym.sym == SDL_Keycode.SDLK_SPACE)
                ActionKeys[(int)ActionKeysID.JUMP].IsDown = IsDown;
        }


        static public void Init()
        {
            for (int i = 0; i < ArrowKeys.Length; i++)
            {
                ArrowKeys[i] = new ButtonState();
            }

            for (int i = 0; i < ActionKeys.Length; i++)
            {
                ActionKeys[i] = new ButtonState();
            }
        }
    }
}
