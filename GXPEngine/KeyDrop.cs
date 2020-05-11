using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class KeyDrop : AnimationSprite
    {
        int speed = 20;
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
            MyGame myGame = (MyGame)game;
            if (this.y > myGame.height - 200)
            {
                if(currentFrame == 0)
                {
                    if (Input.GetKey(Key.A))
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
                    if (Input.GetKey (Key.S))
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
                    if (Input.GetKey(Key.D))
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
                    if (Input.GetKey(Key.F))
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
            this.y = this.y + speed;
        }

        void OutOfBounds()
        {
            MyGame myGame = (MyGame)game;
            if (this.y > myGame.height)
            {
                needToDestroy = true;
            }
        }
    }
}
