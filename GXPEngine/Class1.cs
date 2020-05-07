using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Bandmembers : Canvas
    {
        Drummer _drummer = new Drummer();

        public Bandmembers() : base(1920, 1080)
        {
            AddChild(_drummer);
        }
    }
}
