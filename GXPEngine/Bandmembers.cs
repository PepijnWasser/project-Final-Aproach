using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Bandmembers : Canvas
    {
        Drummer _drummer;
        Guitarist1 _guitarist1;
        Guitarist2 _guitarist2;
        Level _level;
        public float _satisfaction;

        public Bandmembers(Level level) : base(1920, 1080)
        {
            _drummer = new Drummer(this);
            _guitarist1 = new Guitarist1(this);
            _guitarist2 = new Guitarist2(this);
            AddChild(_drummer);
            AddChild(_guitarist1);
            AddChild(_guitarist2);


            _level = level;
        }

        void Update()
        {
            _satisfaction = _level.GetSatisfaction();
        }
    }
}
