using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Light : AnimationSprite
    {
        int millesecondCounter;
        bool goingRight = true;

        bool playingAnimation = false;
        int amountOfLoops;

        public Light() : base("light.png", 2, 3)
        {
            SetFrame(2);
        }

        void Update()
        {
            if(playingAnimation == true)
            {
                millesecondCounter = millesecondCounter + Time.deltaTime;
                if (millesecondCounter > 70)
                {
                    if (goingRight == true)
                    {
                        if (currentFrame > 0 && currentFrame < 3)
                        {
                            SetFrame(currentFrame - 1);
                        }
                        else if (currentFrame == 0)
                        {
                            currentFrame = 3;
                        }
                        else if (currentFrame == 3)
                        {
                            NextFrame();
                        }
                        else
                        {
                            goingRight = false;
                        }
                    }
                    else
                    {
                        if (currentFrame >= 0 && currentFrame < 2)
                        {
                            NextFrame();
                        }
                        else if (currentFrame == 2)
                        {
                            goingRight = true;
                        }
                        else if (currentFrame == 4)
                        {
                            SetFrame(3);
                        }
                        else
                        {
                            SetFrame(0);
                        }
                    }
                    millesecondCounter = 0;
                    amountOfLoops = amountOfLoops + 1;
                    if (amountOfLoops > 30 && currentFrame == 0)
                    {
                        amountOfLoops = 0;
                        playingAnimation = false;
                    }
                }
            }
        }

        public void PlayAnimation()
        {
            playingAnimation = true;
            amountOfLoops = 0;
        }
    }
}
