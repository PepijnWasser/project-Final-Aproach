using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Background :AnimationSprite
    {
        public Background() : base("background.png", 4, 1)
        {
            this.SetXY(50, -15);
            this.SetScaleXY((float)1.9, (float)1.9);
        }

        //changes background color
        public void UpdateFrame()
        {
                NextFrame();
        }
    }
}
