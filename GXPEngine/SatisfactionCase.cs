using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class SatisfactionCase : AnimationSprite
    {
        int millisecondCounter;

        public SatisfactionCase() : base("satisfactionCase.png", 1, 4)
        {
            this.SetXY(0, 0);
        }

        void Update()
        {
            millisecondCounter = millisecondCounter + Time.deltaTime;
            if(millisecondCounter > 200)
            {
                if(currentFrame < 3)
                {
                    NextFrame();
                }
                else
                {
                    SetFrame(0);
                }

                millisecondCounter = 0;

            }
        }
    }
}
