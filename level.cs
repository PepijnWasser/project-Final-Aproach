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

        SoundChannel _musicChannel;
        Sound _music;

        public Level() : base(600, 1080, false)
        {
            _music = new Sound("music.wav", true, false);
            _musicChannel = _music.Play();

            AddChild(space);      
        }

        void Update()
        {
            BackgroundControl();
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
            if(Input.GetKey(Key.E))
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