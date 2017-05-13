using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_pa
{
    class BoundingBox
    {
        public float X,Y,W,H;

        public bool CollidesWith(BoundingBox Other)
        {
            if (X < Other.X + Other.W && X + W >= Other.X
                && Y < Other.Y + Other.W && Y + H >= Other.Y)
                return true;

            return false;
        }
        
        public float HorizontalEnd() { return X + W; }
        public float VerticalEnd() { return Y + H; }
    }
}
