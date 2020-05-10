using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Speaker : AnimationSprite
    {
        int millisecondCounter;
        bool playingAnimation = false;
        int amountOfLoops;


        public Speaker(int x, int y) : base("tester.png",  2, 2)
        {
            this.SetXY(x, y);
        }

        void Update()
        {
            if(playingAnimation == true)
            {
                millisecondCounter += Time.deltaTime;
                if (millisecondCounter > 80)
                {
                    amountOfLoops = amountOfLoops + 1;
                    millisecondCounter = 0;
                    NextFrame();
                }
                if(amountOfLoops > 30 && currentFrame == 0)
                {
                    amountOfLoops = 0;
                    playingAnimation = false;
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
