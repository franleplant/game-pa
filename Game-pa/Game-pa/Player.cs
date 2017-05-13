using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Game_pa
{
    class Player : Entity
    {
        static Vector2 Gravity = new Vector2(.0f, 15.0f);

        Vector2 Velocity = new Vector2();
        Vector2 Acceleration = new Vector2();
        public BoundingBox CollisionBox;
        public bool Airborne = true;


        public override void Init()
        {
            Position = new Vector2(500, 80);
            CollisionBox = new BoundingBox();
            CollisionBox.X = 0; CollisionBox.Y = 0; CollisionBox.W = 32; CollisionBox.H = 32;
        }

        public override void Loop(float frameTime)
        {
            if (Airborne) Acceleration = Player.Gravity;
          


            if (Input.ActionKeys[(int)Input.ActionKeysID.JUMP].PressedThisFrame())
                Velocity -= new Vector2(0,75);

            Velocity.X = 0;

            if (Input.ArrowKeys[(int)Input.ArrowKeysID.ARROW_RIGHT].IsDown)
                Velocity.X = 20;

            if (Input.ArrowKeys[(int)Input.ArrowKeysID.ARROW_LEFT].IsDown)
                Velocity.X = -20;

            Velocity += (Acceleration * frameTime);
            Position += (Velocity * frameTime);

            if (CollisionBox.VerticalEnd() + (int)Position.Y > 900) //900 = height de la screen
            {
                Position.Y = 900 - CollisionBox.VerticalEnd();
                Velocity.Y = 0;
            }
        }

        public override void Draw()
        {
            Renderer.SetRenderColor(120, 0, 0, 1);
            Renderer.DrawRect((int)Position.X, (int)Position.Y, (int)(CollisionBox.W), (int)(CollisionBox.H));
        }
    }
}
