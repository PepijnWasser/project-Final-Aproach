using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Music : Canvas
    {
        SoundChannel _musicChannel;
        Sound _music;

        public Music() : base(1920, 1080)
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

        void NewMusic()
        {
            int randomSong = Utils.Random(1, 4);
            if (randomSong == 1)
            {
                _music = new Sound("Risk.wav", false, false);
            }
            if (randomSong == 2)
            {
                _music = new Sound("Persistence.wav", false, false);
            }
            if (randomSong == 3)
            {
                _music = new Sound("Second Class Human.wav", false, false);
            }
        }

        public void StopMusic()
        {
            _musicChannel.Stop();
        }
    }
}
