using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GXPEngine
{
    public class Level : Canvas
    {
        int _levelMillisecondCounter;
        int _levelSecondCounter;

        Background space = new Background();
        KeyDropControl keyDropControl = new KeyDropControl();

        SoundChannel _musicChannel;
        Sound _music;

        Speaker _speaker = new Speaker();

        public Level() : base(600, 1080, false)
        {
            _music = new Sound("music.wav", true, false);
            _musicChannel = _music.Play();

            AddChild(space);
            AddChild(keyDropControl);
            AddChild(_speaker);
        }

        void Update()
        {
            BackgroundControl();
            TestAnimatables();
        }

        void TestAnimatables()
        {
            if (keyDropControl.hitSpeaker)
            {
                _speaker.PlayAnimation();
            }
        }

        void BackgroundControl()
        {
            _levelMillisecondCounter += Time.deltaTime;
            if (_levelMillisecondCounter >= 1000)
            {
                _levelMillisecondCounter = 0;
                _levelSecondCounter = _levelSecondCounter + 1;
            }
            if (_levelSecondCounter == 60)
            {
                space.UpdateFrame();
                _levelSecondCounter = 0;
            }
        }  


        public bool ChangeScreen()
        {
            if(Input.GetKey(Key.P))
            {
                _musicChannel.Stop();
                return true;
            }
            else
            {
                return false;
            }
        }      
    }
}