using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class KeyDropControl : Canvas
    {
        List<KeyDrop> _keyDrops;

        public int GetNumberOfKeyDrops()
        {
            return _keyDrops.Count;
        }


        public KeyDropControl() : base (1920, 1080)
        {
            _keyDrops = new List<KeyDrop>();         
        }

        void Update()
        {
            AddKeyDrop();
            test();
        }

        void AddKeyDrop()
        {
            KeyDrop _keyDrop = new KeyDrop();
            AddChild(_keyDrop);
            _keyDrops.Add(_keyDrop);
        }

        void test()
        {
            for(int i = 0; i < _keyDrops.Count; i++)
            {
                Console.WriteLine("test");
            }
        }
    }
}
