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
        int _musicToPlay = 1;
        public float bpm;

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

        // play the next song
        public void NewMusic()
        {         
            if(_musicToPlay > 4)
            {
                _musicToPlay = 1;
            }

            if(_musicToPlay == 1)
            {
                _music = new Sound("pressure.wav", false, false);
                bpm = 1000 / (136 / 60) * 2;
            }
            if(_musicToPlay == 2)
            {
                _music = new Sound("Thought Contagion.wav", false, false);
                bpm = 1000 / (140 / 60);
            }
            if(_musicToPlay == 3)
            {
                _music = new Sound("plug.wav", false, false);
                bpm = 1000 / (136 / 60);
            }
            if(_musicToPlay == 4)
            {
                _music = new Sound("Butterflies and Hurricanes.wav", false, false);
                bpm = 1000 / (115 / 60);
            }
            _musicToPlay = _musicToPlay + 1;
        }

        // stop the music
        public void StopMusic()
        {
            _musicChannel.Stop();
        }

        // go to the next song (same as update)
        public void NextSong()
        {
            _musicChannel.Stop();

            NewMusic();

            _musicChannel = _music.Play();
        }
    }
}
