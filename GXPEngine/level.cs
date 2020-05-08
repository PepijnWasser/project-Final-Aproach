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
        Light _light = new Light();

        Bandmembers _bandmembers;

        SatisfactionBar _satisfactionBar = new SatisfactionBar();

        public Level() : base(600, 1080, false)
        {
            _music = new Sound("music.wav", true, false);
            _musicChannel = _music.Play();

            _bandmembers = new Bandmembers(this);

            AddChild(space);
            AddChild(keyDropControl);
            AddChild(_speaker);
            AddChild(_light);
            AddChild(_bandmembers);
            AddChild(_satisfactionBar);
        }

        void Update()
        {
            BackgroundControl();
            TestAnimatables();
            TestScoring();
        }

        void TestScoring()
        {
            if(keyDropControl.failed == true)
            {
                _satisfactionBar.SetRemoveScore();
            }
            else if(keyDropControl.hitSpeaker == true || keyDropControl.hitLight == true)
            {
                _satisfactionBar.SetAddScore();
            }
        }

        void TestAnimatables()
        {
            if (keyDropControl.hitSpeaker)
            {
                _speaker.PlayAnimation();
            }
            if (keyDropControl.hitLight)
            {
                _light.PlayAnimation();
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

        public float GetSatisfaction()
        {
            return _satisfactionBar.scaling;
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