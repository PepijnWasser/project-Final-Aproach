using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class KeyDrop : AnimationSprite
    {
        public string buttonToPress;
        int speed = 15;
        int column;
        bool _streak;
        KeyDropControl _keyDropControl;

        public KeyDrop(KeyDropControl keyDropControl, bool streak) : base("keyanimation.png", 2, 1)
        {
            SetButton();
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

        void SetButton()
        {
            int button = Utils.Random(1, 3);

            if (button == 1)
            {
                buttonToPress = "A";
            }
            if (button == 2)
            {
                buttonToPress = "B";
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
            if (this.y > myGame.height - 500)
            {
                if(currentFrame == 0)
                {
                    if (Input.GetKeyDown(Key.S))
                    {
                        this.LateDestroy();
                    }
                }
                if (currentFrame == 1)
                {
                    if (Input.GetKeyDown (Key.B))
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
