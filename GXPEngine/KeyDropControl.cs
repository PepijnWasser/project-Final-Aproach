using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class KeyDropControl : Canvas
    {
        List<KeyDrop> _keyDrops;
        KeyDrop _keyDrop;

        public int GetNumberOfKeyDrops()
        {
            return _keyDrops.Count;
        }


        public KeyDropControl() : base (1920, 1080)
        {
      
        }

        void Update()
        {
            AddKeyDrop();
        }

        void AddKeyDrop()
        {
            _keyDrop = new KeyDrop();
            AddChild(_keyDrop);
            _keyDrops.Add(_keyDrop);
        }
    }
}
