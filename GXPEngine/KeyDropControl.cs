using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class KeyDropControl : Canvas
    {
        List<KeyDrop> _keyDrops;
        int millisecondCounter;
        int timeToNextKey;

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
            millisecondCounter = millisecondCounter + Time.deltaTime;
            if(millisecondCounter > timeToNextKey)
            {
                AddKeyDrop();
                test();
                TimeBeforeNextKey();
                millisecondCounter = 0;
            }
         
        }

        void TimeBeforeNextKey()
        {
            timeToNextKey = 250 + Utils.Random(0, 500);
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
