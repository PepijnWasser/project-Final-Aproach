using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

        public bool hitSpeaker;
        public bool hitLight;
        public bool hitFlame;
        public bool failed;
        public bool switched;
        public bool hitSmoke;

        public int GetNumberOfKeyDrops()
        {
            return _keyDrops.Count;
        }

        public KeyDrop GetKeyDrop(int index)
        {
            if (index >= 0 && index < _keyDrops.Count)
            {
                return _keyDrops[index];
            }
            return null;
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
            TestHits();
            DeleteKeyDrops();
            TestLaneSwitch();
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

        void TestHits()
        {
            int numberOfSpeakerFails = 0;
            int numberOfFireFails = 0;
            int numberOfLightFails = 0;
            int numberOfSucceeds = 0;
            int numberOfSmokeFails = 0;

            for (int j = 0; j < _keyDrops.Count; j++)
            {
                if (_keyDrops[j].hitSmoke)
                {
                    hitSmoke = true;
                }
                else
                {
                    numberOfSmokeFails = numberOfSmokeFails + 1;
                }
                if (_keyDrops[j].failed)
                {
                    failed = true;
                }
                else
                {
                    numberOfSucceeds = numberOfSucceeds + 1;
                }
                if (_keyDrops[j].hitSpeaker)
                {
                    hitSpeaker = true;
                }
                else
                {
                    numberOfSpeakerFails = numberOfSpeakerFails + 1;               
                }
                if (_keyDrops[j].hitFlame)
                {
                    hitFlame = true;
                }
                else
                {
                    numberOfFireFails = numberOfFireFails + 1;
                }
                if (_keyDrops[j].hitLight)
                {
                    hitLight = true;
                }
                else
                {
                    numberOfLightFails = numberOfLightFails + 1;
                }
            }
            if (numberOfSpeakerFails == _keyDrops.Count)
            {
                hitSpeaker = false;
            }
            if (numberOfSmokeFails == _keyDrops.Count)
            {
                hitSmoke = false;
            }
            if (numberOfSucceeds == _keyDrops.Count)
            {
                failed = false;
            }
            if (numberOfLightFails == _keyDrops.Count)
            {
                hitLight = false;
            }
            if (numberOfFireFails == _keyDrops.Count)
            {
                hitFlame = false;
            }
        }

        void DeleteKeyDrops()
        {
            for (int i = 0; i < _keyDrops.Count; i++)
            {
                if (_keyDrops[i].needToDestroy)
                {
                    _keyDrops[i].LateDestroy();
                    _keyDrops[i] = null;
                    _keyDrops.Remove(_keyDrops[i]);
                }
            }
        }

        void TestLaneSwitch()
        {
            if (_keyDropRowController.switched)
            {
                switched = true;
            }
            else
            {
                switched = false;
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
