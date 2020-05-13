using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class SideBar : AnimationSprite
    {
        int millisecondCounter;

        public SideBar() : base("sidebar.png", 3, 2)
        {
            SetXY(720, 0);
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
