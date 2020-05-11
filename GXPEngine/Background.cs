using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Background :AnimationSprite
    {
        int millisecondCounter;

        public Background() : base("background.png", 2, 2)
        {
           
        }

        void Update()
        {
            millisecondCounter = millisecondCounter + Time.deltaTime;

            if(millisecondCounter > 100)
            {
                NextFrame();
                millisecondCounter = 0;
            }
        }
    }
}
