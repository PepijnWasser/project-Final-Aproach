using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Drummer : AnimationSprite
    {
        int milliscondCounter;
        float _satisfaction;

        Bandmembers _bandmembers;

        public Drummer(Bandmembers bandmembers) : base("drummer.png", 9, 10)
        {
            _bandmembers = bandmembers;
            SetXY(80, 0);
        }

        void Update()
        {
            _satisfaction = _bandmembers._satisfaction;
            milliscondCounter = milliscondCounter + Time.deltaTime;
            if(milliscondCounter > 70)
            {
                if (_satisfaction < 40 && _satisfaction > 10)
                {
                    if (currentFrame < 56)
                    {
                        NextFrame();
                    }
                    else
                    {
                        SetFrame(40);
                    }
                }
                else if (_satisfaction <= 10)
                {
                    if (currentFrame < 88)
                    {
                        NextFrame();
                    }
                    else
                    {
                        SetFrame(58);
                    }
                }
                else
                {
                    if (currentFrame < 34)
                    {
                        NextFrame();
                    }
                    else
                    {
                        SetFrame(0);
                    }
                }        
                milliscondCounter = 0;
            }        
        }
    }
}
