using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class LevelMusic : Canvas
    {
        SoundChannel _musicChannel;
        Sound _music;
        public LevelMusic() : base(1920, 1080)
        {
            NewMusic();
            _musicChannel = _music.Play();
        }

        void Update()
        {
            if(_musicChannel.IsPlaying == false)
            {
                _musicChannel.Stop();

                NewMusic();

                _musicChannel = _music.Play();
            }
        }

        public void NewMusic()
        {
                _music = new Sound("risk.wav", false, false);           
        }

        public void StopMusic()
        {
            _musicChannel.Stop();
        }
    }
}
