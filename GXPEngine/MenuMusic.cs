using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class MenuMusic : Canvas
    {
        SoundChannel _musicChannel;
        Sound _music;
        public MenuMusic() : base(1920, 1080)
        {
            NewMusic();
            _musicChannel = _music.Play();
        }

        // play the menu music
        void Update()
        {
            if (_musicChannel.IsPlaying == false)
            {
                _musicChannel.Stop();

                NewMusic();

                _musicChannel = _music.Play();
            }
        }

        public void NewMusic()
        {
            _music = new Sound("algorithm.wav", true, false);
        }

        public void StopMusic()
        {
            _musicChannel.Stop();
        }
    }
}
