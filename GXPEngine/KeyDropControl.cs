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
        int KeyStreak;
        int streakCount;

        int streakPosition = 1;

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
            millisecondCounter += Time.deltaTime;

            if (KeyStreak == 1)
            {
                if (millisecondCounter > timeToNextKey)
                {
                    AddKeyDrop(true);
                    test();
                    millisecondCounter = 0;
                    streakCount = streakCount + 1;

                    if (streakCount > 10)
                    {
                        streakCount = 0;
                        SpawnKeyTime();
                    }
                }
            }
            else if (millisecondCounter > timeToNextKey)
            {
                 AddKeyDrop(false);
                 test();
                 SpawnKeyTime();
                 millisecondCounter = 0;
            } 
        }

        void SpawnKeyTime()
        {
            KeyStreak = Utils.Random(1, 4);
            if(KeyStreak == 1)
            {
                timeToNextKey = 90;
                streakPosition = Utils.Random(1, 5);
                Console.WriteLine("test");

            }
            else
            {
                timeToNextKey = 250 + Utils.Random(0, 500);
            }
        }

        void AddKeyDrop(bool streak)
        {
            KeyDrop _keyDrop = new KeyDrop(this, streak);
            AddChild(_keyDrop);
            _keyDrops.Add(_keyDrop);
        }

        void test()
        {
            for(int i = 0; i < _keyDrops.Count; i++)
            {
                
            }
        }

        public int GetStreakPosition()
        {
            return streakPosition;
        }

    }

 
}
