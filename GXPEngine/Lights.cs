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

        public float satisfaction;

        Level _level;

        public Light(Level level, int x, int y) : base("light.png", 3, 3)
        {
            SetXY(x, y);
            SetFrame(2);
            _level = level;
        }

        void Update()
        {
            satisfaction = _level.GetSatisfaction();
            if (playingAnimation == true)
            {
                millesecondCounter = millesecondCounter + Time.deltaTime;
                if (millesecondCounter > 70)
                {
                    if(satisfaction <= 10)
                    {
                        if(currentFrame < 7)
                        {
                            NextFrame();
                        }
                        else
                        {
                            currentFrame = 5;
                        }
                    }
                    else
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
                    }
                   
                    millesecondCounter = 0;
                    amountOfLoops = amountOfLoops + 1;
                    if (amountOfLoops > 30 + Utils.Random(0, 5))
                    {
                        amountOfLoops = 0;
                        if(satisfaction <= 10)
                        {
                            if(currentFrame == 5)
                            {
                                playingAnimation = false;
                            }
                        }
                        else
                        {
                            playingAnimation = false;
                        }
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
