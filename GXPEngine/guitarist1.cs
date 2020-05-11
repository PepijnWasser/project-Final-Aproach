using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Guitarist1 : AnimationSprite
    {
        Bandmembers _bandmembers;
        float _satisfaction;
        int millisecondCounter;

        public Guitarist1(Bandmembers bandmembers) : base("guitarist 1.png", 7, 7)
        {
            _bandmembers = bandmembers;
            SetXY(60, 260);
        }

        void Update()
        {
            _satisfaction = _bandmembers._satisfaction;
            millisecondCounter = millisecondCounter + Time.deltaTime;
            if (millisecondCounter > 70)
            {
                if (_satisfaction < 40 && _satisfaction > 10)
                {
                    if (currentFrame < 12)
                    {
                        NextFrame();
                    }
                    else
                    {
                        SetFrame(0);
                    }
                }
                else if (_satisfaction <= 10)
                {
                    if (currentFrame < 88)
                    {
                        
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    if (currentFrame < 23)
                    {
                        SetFrame(23);
                    }
                    else if (currentFrame < 42)
                    {
                        NextFrame();
                    }
                    else
                    {
                        SetFrame(23);
                    }
                }
                millisecondCounter = 0;
            }
        }
    }
}
