using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Game_pa
{
    class Entity
    {
        //.NET 4.6 ya trae una clase de v2 (?)
        public Vector2 Position = new Vector2(0, 0);

        virtual public void Init() { }
        virtual public void Loop(float frameTime) { } //frameTime quizas deberia ser double
        virtual public void Draw() { }
    }
}
