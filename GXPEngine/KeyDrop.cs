using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class KeyDrop : AnimationSprite
    {
        public string buttonToPress;
        int speed = 20;
        int column;
        bool _streak;
        KeyDropControl _keyDropControl;

        public KeyDrop(KeyDropControl keyDropControl, bool streak) : base("keyanimation.png", 2, 1)
        {
            _streak = streak;
            _keyDropControl = keyDropControl;
            SetPosition();
        }

        void SetPosition()
        {
            if (_streak == true)
            {
                Console.WriteLine(_streak);
                column = _keyDropControl.GetStreakPosition();
            }
            else
            {
                column = Utils.Random(1, 5);
            }
            if (column == 1)
            {
                this.SetXY(1250, 0);
            }
            if (column == 2)
            {
                this.SetXY(1325, 0);
            }
            if (column == 3)
            {
                this.SetXY(1400, 0);
                NextFrame();
            }
            if (column == 4)
            {
                this.SetXY(1475, 0);
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
                    if (Input.GetKey(Key.S))
                    {
                        this.LateDestroy();
                    }
                }
                if (currentFrame == 1)
                {
                    if (Input.GetKey (Key.B))
                    {
                        this.LateDestroy();
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
                this.LateDestroy();
            }
        }
    }
}
