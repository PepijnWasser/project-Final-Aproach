using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class KeyDrop : AnimationSprite
    {
        int speed = 10;
        int column;

        int _rowControl;

        public bool hitSpeaker;
        public bool hitLight;
        public bool hitSmoke;
        public bool hitFlame;
        public bool needToDestroy;
        public bool failed;

        public KeyDrop(int RowControl) : base("keyanimation.png", 3, 3)
        {
            _rowControl = RowControl;
            SetPosition();
        }

        void SetPosition()
        {
            //depending on the column it got from keycontrol change the position to that row
            column = _rowControl;

            if (column == 1)
            {
                this.SetXY(400, 0);
            }
            if (column == 2)
            {
                this.SetXY(500, 0);
                SetFrame(2);
            }
            if (column == 3)
            {
                this.SetXY(600, 0);
                SetFrame(4);
            }
            if (column == 4)
            {
                this.SetXY(700, 0);
                SetFrame(6);
            }
        }

        void Update()
        {
            Fall();
            OutOfBounds();
            TestKeyPress();

        }

        void TestKeyPress()
        {
            // if the block is 200 above the bottom test if the correct button is pressed
            //if true return the type of key
            //if false return that it failed
            MyGame myGame = (MyGame)game;
            if (this.y > myGame.height - 200)
            {
                if(currentFrame == 0)
                {
                    if (Input.GetKey(Key.D))
                    {
                        hitSpeaker = true;
                    }
                    else
                    {
                        failed = true;
                    }
                }
                if (currentFrame == 2)
                {
                    if (Input.GetKey (Key.F))
                    {
                        hitFlame = true;
                    }
                    else
                    {
                        failed = true;
                    }
                }
                if (currentFrame == 4)
                {
                    if (Input.GetKey(Key.J))
                    {
                        hitLight = true;
                    }
                    else
                    {
                        failed = true;
                    }
                }
                if (currentFrame == 6)
                {
                    if (Input.GetKey(Key.K))
                    {
                        hitSmoke = true;
                    }
                    else
                    {
                        failed = true;
                    }
                }
                needToDestroy = true;
            }
        }

        void Fall()
        {
            //just falling
            this.y = this.y + speed;
        }

        void OutOfBounds()
        {
            //if the block is out of the screen indicate that it needs to be deleted
            MyGame myGame = (MyGame)game;
            if (this.y > myGame.height)
            {
                needToDestroy = true;
            }
        }
    }
}
