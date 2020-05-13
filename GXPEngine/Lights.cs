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

        bool playingAnimation = true;
        int amountOfLoops;

        public float satisfaction;
        string _color;

        Level _level;

        public Light(Level level, int x, int y, string color) : base("light.png", 5, 3)
        {
            SetXY(x, y);
            SetFrame(2);
            _level = level;
            _color = color;
            if(color == "purple")
            {
                SetFrame(5);
            }
        }

        void Update()
        {
            // if the animation needs to play play it every 70 milliseconds for 30 cycles
            satisfaction = _level.GetSatisfaction();
            if (playingAnimation == true)
            {
                millesecondCounter = millesecondCounter + Time.deltaTime;
                if (millesecondCounter > 70)
                {
                    if (satisfaction <= 2)
                    {
                        if (currentFrame < 13)
                        {
                            NextFrame();
                        }
                        else
                        {
                            currentFrame = 10;
                        }
                    }
                    else
                    {
                        if (goingRight == true)
                        {
                            if (_color == "pink")
                            {
                                if (currentFrame < 4)
                                {
                                    NextFrame();
                                }
                                else
                                {
                                    goingRight = false;
                                }
                            }
                            if (_color == "purple")
                            {
                                if (currentFrame < 9)
                                {
                                    NextFrame();
                                }
                                else
                                {
                                    goingRight = false;
                                }
                            }
                        }
                        else
                        {
                            if (_color == "pink")
                            {
                                if (currentFrame > 0)
                                {
                                    SetFrame(currentFrame - 1);
                                }
                                else
                                {
                                    goingRight = true;
                                }
                            }
                            if (_color == "purple")
                            {
                                if (currentFrame > 5)
                                {
                                    SetFrame(currentFrame - 1);
                                }
                                else
                                {
                                    goingRight = true;
                                }
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
