using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class KeyDropControl : Canvas
    {
        List<KeyDrop> _keyDrops;
        KeyDropRowController _keyDropRowController;

        int millisecondCounter;
        int timeToNextKey;
        int KeyStreak;
        int streakCount;

        int KeyDropPosition = 1;

        public int GetNumberOfKeyDrops()
        {
            return _keyDrops.Count;
        }


        public KeyDropControl() : base (1920, 1080)
        {
            _keyDrops = new List<KeyDrop>();
            _keyDropRowController = new KeyDropRowController();
            AddChild(_keyDropRowController);
        }

        void Update()
        {
            millisecondCounter += Time.deltaTime;

            if (KeyStreak == 1)
            {
                if (millisecondCounter > timeToNextKey)
                {
                    AddKeyDrop();

                    millisecondCounter = 0;
                    streakCount = streakCount + 1;

                    if (streakCount > 10)
                    {
                        streakCount = 0;
                        SetKeyProperties();
                    }
                }
            }
            else if (millisecondCounter > timeToNextKey)
            {
                 AddKeyDrop();
                 SetKeyProperties();
                 millisecondCounter = 0;
            } 
        }

        void SetKeyProperties()
        {
            KeyStreak = Utils.Random(1, 8);
            if(KeyStreak == 1)
            {
                timeToNextKey = 50;
            }
            else
            {
                timeToNextKey = 250 + Utils.Random(0, 500);
            }
            KeyDropPosition = Utils.Random(_keyDropRowController.row - 1, _keyDropRowController.row + 2);
            if(KeyDropPosition < 1)
            {
                KeyDropPosition = 4;
            }
            if (KeyDropPosition > 4)
            {
                KeyDropPosition = 1;
            }
        }

        void AddKeyDrop()
        {
            KeyDrop _keyDrop = new KeyDrop(KeyDropPosition);
            AddChild(_keyDrop);
            _keyDrops.Add(_keyDrop);
        }

        public int GetKeyDropPosition()
        {
            return KeyDropPosition;
        }

    }

 
}
