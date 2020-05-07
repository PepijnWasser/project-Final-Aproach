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
        public bool needToDestroy;

        public KeyDrop(int RowControl) : base("keyanimation.png", 4, 1)
        {
            _rowControl = RowControl;
            SetPosition();
        }

        void SetPosition()
        {
            column = _rowControl;

            if (column == 1)
            {
                this.SetXY(1250, 0);
            }
            if (column == 2)
            {
                this.SetXY(1325, 0);
                NextFrame();
            }
            if (column == 3)
            {
                this.SetXY(1400, 0);
                NextFrame();
                NextFrame();
            }
            if (column == 4)
            {
                this.SetXY(1475, 0);
                NextFrame();
                NextFrame();
                NextFrame();
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
                        needToDestroy = true;
                        hitSpeaker = true;
                    }
                }
                if (currentFrame == 1)
                {
                    if (Input.GetKey (Key.S))
                    {
                        needToDestroy = true;
                    }
                }
                if (currentFrame == 2)
                {
                    if (Input.GetKey(Key.D))
                    {
                        hitLight = true;
                        needToDestroy = true;
                    }
                }
                if (currentFrame == 3)
                {
                    if (Input.GetKey(Key.F))
                    {
                        needToDestroy = true;
                    }
                }
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
