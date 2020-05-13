using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Startscreen : AnimationSprite
    {
        MenuMusic _music = new MenuMusic();
        public Startscreen() : base("startscreen" + ".png", 8, 1)
        {

        }

        void Update()
        {
            NextFrame();
        }
        
        /// ///////////////////////////////////////////////////////////////////////
        /// if E is pressed, return true
        /// ///////////////////////////////////////////////////////////////////////
        public bool ChangeScreen()
        {
            if (Input.GetKey(Key.E))
            {
                _music.StopMusic();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
