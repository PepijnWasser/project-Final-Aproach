using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Drummer : AnimationSprite
    {
        int millisecondCounter;
        float _satisfaction;

        Bandmembers _bandmembers;

        public Drummer(Bandmembers bandmembers) : base("drummer.png", 9, 10)
        {
            _bandmembers = bandmembers;
            SetXY(308, 307);
        }

        void Update()
        {
            //every 70 milliseconds go change the frame depending on satisfaction
            _satisfaction = _bandmembers._satisfaction;
            millisecondCounter = millisecondCounter + Time.deltaTime;
            if(millisecondCounter > 70)
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
                        SetFrame(1);
                    }
                }        
                millisecondCounter = 0;
            }        
        }
    }
}
