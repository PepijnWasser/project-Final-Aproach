using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class KeyDropRowController : Sprite
    {
        public int row = 1;
        public bool switched;

        public KeyDropRowController() : base("square.png")
        {
            this.SetXY(1250, 0);
        }

        void Update()
        {
            switched = false;
            CheckRow();
            UpdateRow();
        }

        void CheckRow()
        {
            if (Input.GetKeyDown(Key.Q))
            {
                row = row - 1;
                switched = true;
            }
            if (Input.GetKeyDown(Key.E))
            {
                row = row + 1;
                switched = true;
            }

            if(row > 4)
            {
                row = 1;
            }
            if(row < 1)
            {
                row = 4;
            }
        }

        void UpdateRow()
        {
            if(row == 1)
            {
                this.SetXY(1250, 0);
            }
            if (row == 2)
            {
                this.SetXY(1325, 0);
            }
            if (row == 3)
            {
                this.SetXY(1400, 0);
            }
            if (row == 4)
            {
                this.SetXY(1475, 0);
            }
        }
    }
}
