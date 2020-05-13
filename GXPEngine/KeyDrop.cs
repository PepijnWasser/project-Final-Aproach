using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class KeyDrop : AnimationSprite
    {
        int speed = 5;
        int column;

        int _rowControl;

        int millisecondCounter = 0;

        public bool hitSpeaker;
        public bool hitLight;
        public bool hitSmoke;
        public bool hitFlame;
        public bool needToRemove;
        public bool failed;

        bool playAnimation = false;

        public KeyDrop(int RowControl) : base("keyanimation.png", 4, 5)
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
                this.SetXY(732, 0);
            }
            if (column == 2)
            {
                this.SetXY(795, 0);
                SetFrame(15);
            }
            if (column == 3)
            {
                this.SetXY(855, 0);
                SetFrame(10);
            }
            if (column == 4)
            {
                this.SetXY(915, 0);
                SetFrame(5);
            }
        }

        void Update()
        {
            Fall();
            OutOfBounds();
            TestKeyPress();
            if(playAnimation == true)
            {
                PlayAnimation();
            }

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
                        playAnimation = true;
                    }
                    else
                    {
                        failed = true;
                    }
                }
                if (currentFrame == 15)
                {
                    if (Input.GetKey (Key.F))
                    {
                        hitFlame = true;
                        playAnimation = true;
                    }
                    else
                    {
                        failed = true;
                    }
                }
                if (currentFrame == 10)
                {
                    if (Input.GetKey(Key.J))
                    {
                        hitLight = true;
                        playAnimation = true;
                    }
                    else
                    {
                        failed = true;
                    }
                }
                if (currentFrame == 5)
                {
                    if (Input.GetKey(Key.K))
                    {
                        hitSmoke = true;
                        playAnimation = true;
                    }
                    else
                    {
                        failed = true;
                    }
                }
                needToRemove = true;
            }
        }

        void PlayAnimation()
        {
            millisecondCounter = millisecondCounter + Time.deltaTime;
            if(millisecondCounter > 70)
            {
                if(column == 1)
                {
                    NextFrame();
                    if(currentFrame == 5)
                    {
                        this.LateDestroy();
                    }
                }
                if(column == 2)
                {
                    NextFrame();
                    if(currentFrame == 0)
                    {
                        this.LateDestroy();
                    }
                }
                if(column == 3)
                {
                    NextFrame();
                    if(currentFrame == 15)
                    {
                        this.LateDestroy();
                    }
                }
                if(column == 4)
                {
                    NextFrame();
                    if(currentFrame == 10)
                    {
                        this.LateDestroy();
                    }
                }
                millisecondCounter = 0;
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
                this.LateDestroy();
            }
        }
    }
}
