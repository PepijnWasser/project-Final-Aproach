using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Drummer : AnimationSprite
    {
        int milliscondCounter;

        public Drummer() : base("drummer.png", 5, 4)
        {
            SetXY(80, 0);
        }

        void Update()
        {
            milliscondCounter = milliscondCounter + Time.deltaTime;
            if(milliscondCounter > 70)
            {
                if(currentFrame < 17)
                {
                    NextFrame();
                }
                else
                {
                    SetFrame(0);
                }
                milliscondCounter = 0;
            }        
        }
    }
}
