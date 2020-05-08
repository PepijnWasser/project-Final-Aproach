using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Bandmembers : Canvas
    {
        Drummer _drummer;
        Level _level;
        public float _satisfaction;

        public Bandmembers(Level level) : base(1920, 1080)
        {
            _drummer = new Drummer(this);
            AddChild(_drummer);
            _level = level;
        }

        void Update()
        {
            _satisfaction = _level.GetSatisfaction();
        }
    }
}
