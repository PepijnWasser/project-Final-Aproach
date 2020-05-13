using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Crowd : AnimationSprite
    {
        Level _level;
        int millisecondCounter;

        public Crowd(Level level) : base("crowd.png", 1, 7)
        {
            _level = level;
            this.SetXY(0, 540);
        }

        void Update()
        {
            millisecondCounter = millisecondCounter + Time.deltaTime;
            if(millisecondCounter > 200)
            {
                if(_level.GetSatisfaction() <= 2)
                {
                    if(currentFrame < 6)
                    {
                        NextFrame();
                    }
                    else
                    {
                        SetFrame(5);
                    }
                }
                if (_level.GetSatisfaction() > 2 && _level.GetSatisfaction() < 22)
                {
                    if (currentFrame < 1)
                    {
                        NextFrame();
                    }
                    else
                    {
                        SetFrame(0);
                    }
                }
                if (_level.GetSatisfaction() > 22)
                {
                    if (currentFrame < 4)
                    {
                        NextFrame();
                    }
                    else
                    {
                        SetFrame(2);
                    }
                }

                millisecondCounter = 0;
            }
        }
    }
}
