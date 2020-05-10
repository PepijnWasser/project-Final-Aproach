using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Flame : AnimationSprite
    {
        int millisecondCounter;
        int amountOfCycles;
        bool playAnimation = true;
        Level _level;

        public Flame(Level level, int x, int y) : base("fire.png", 2, 3)
        {
            this.SetXY(x, y);
            _level = level;
        }

        void Update()
        {
            if (playAnimation == true)
            {
                millisecondCounter = millisecondCounter + Time.deltaTime;
                if (millisecondCounter > 50)
                {
                    millisecondCounter = 0;
                    amountOfCycles = amountOfCycles + 1;
                    if(amountOfCycles < 30)
                    {
                        if (currentFrame < 4)
                        {
                            NextFrame();
                        }
                        else
                        {
                            SetFrame(3);
                        }
                    }
                    else 
                    {
                        if(currentFrame > 0)
                        {
                            SetFrame(currentFrame - 1);
                        }
                        else
                        {
                            playAnimation = false;
                            amountOfCycles = 0;
                        }
                       
                    }
                }
            }
           
        }

        public void PlayAnimation()
        {
            playAnimation = true;
            amountOfCycles = 0;
        }
    }
}
