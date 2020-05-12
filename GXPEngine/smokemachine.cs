using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class SmokeMachine : AnimationSprite
    {
        int millisecondCounter;
        bool playAnimation = true;
        int amountOfCycles;

        Level _level;

        public SmokeMachine(Level level, int x, int y, bool mirrored = false) : base("smokemachine.png", 3, 4)
        {
            SetXY(x, y);
            _level = level;
            if (mirrored)
            {
                SetScaleXY(-1, 1);
            }
        }

        void Update()
        {
            // if the animation needs to play play it every 50 milliseconds for 30 cycles
            if (playAnimation == true)
            {
                millisecondCounter = millisecondCounter + Time.deltaTime;
                if (millisecondCounter > 70)
                {
                    millisecondCounter = 0;
                    amountOfCycles = amountOfCycles + 1;

                    if (amountOfCycles < 30)
                    {
                        if(_level.GetSatisfaction() <= 2)
                        {
                            if(currentFrame < 8)
                            {
                                NextFrame();
                            }
                            else
                            {
                                SetFrame(7);
                            }
                        }
                        else
                        {
                            if (currentFrame < 6)
                            {
                                NextFrame();
                            }
                            else
                            {
                                SetFrame(0);
                            }
                        }                    
                    }
                    else
                    {
                        if (currentFrame > 0)
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
