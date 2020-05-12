using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Guitarist2 : AnimationSprite
    {
        Bandmembers _bandmembers;
        float _satisfaction;
        int millisecondCounter;

        public Guitarist2(Bandmembers bandmembers) : base("guitarist 2.png", 8, 8)
        {
            _bandmembers = bandmembers;
            SetXY(500, 250);
        }

        void Update()
        {
            //every 70 milliseconds go change the frame depending on satisfaction
            _satisfaction = _bandmembers._satisfaction;
            millisecondCounter = millisecondCounter + Time.deltaTime;
            if (millisecondCounter > 70)
            {
                if (_satisfaction < 22 && _satisfaction > 2)
                {
                    if (currentFrame < 36)
                    {
                        NextFrame();
                    }
                    else
                    {
                        SetFrame(27);
                    }
                }
                else if (_satisfaction <= 2)
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
                    if (currentFrame < 26)
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
