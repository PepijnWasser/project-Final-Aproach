using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Startscreen : AnimationSprite
    {

        public Startscreen() : base("startscreen" + ".png", 8, 1)
        {

        }

        void Update()
        {

        }

        //screen fade
        void Fading()
        {

        }

        /// ///////////////////////////////////////////////////////////////////////
        /// if E is pressed, return true
        /// ///////////////////////////////////////////////////////////////////////
        public bool ChangeScreen()
        {
            if (Input.GetKey(Key.E))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
