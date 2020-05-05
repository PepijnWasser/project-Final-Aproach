using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class KeyDrop : Sprite
    {
        public string buttonToPress;
        int speed = 10;

        public KeyDrop() : base("square.png")
        {
            SetPosition();
            SetButton();
        }

        void SetPosition()
        {
            int column = Utils.Random(1, 5);
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
            }
            if (column == 4)
            {
                this.SetXY(1475, 0);
            }
        }

        void SetButton()
        {
            int button = Utils.Random(1, 3);

            if(button == 1)
            {
                buttonToPress = "A";
            }
            if(button == 2)
            {
                buttonToPress = "B";
            }
        }

        void Update()
        {
            this.y = this.y + speed;
        }
    }
}
