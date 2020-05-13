using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GXPEngine
{
    public class Level : Canvas
    {
        Background space = new Background();
        KeyDropControl keyDropControl;

        List<Speaker> _speakers;
        Speaker _speaker;

        List<Light> _lights;
        Light _light;

        Bandmembers _bandmembers;

        Score _score;

        List<Flame> _flames;
        Flame _flame;

        List<SmokeMachine> _smokeMachines;
        SmokeMachine _smokemachine;

        SatisfactionBar _satisfactionBar = new SatisfactionBar();

        SideBar _sideBar = new SideBar();

        LevelMusic _music = new LevelMusic();

        SatisfactionCase _satisfactionCase = new SatisfactionCase();

        Crowd _crowd;

        public Level() : base(960, 720, false)
        {
            _bandmembers = new Bandmembers(this);
            _score = new Score(this);
            keyDropControl = new KeyDropControl(this);
            _crowd = new Crowd(this);

            _speakers = new List<Speaker>();
            _flames = new List<Flame>();
            _lights = new List<Light>();
            _smokeMachines = new List<SmokeMachine>();

            AddChild(space);                   
            AddChild(_satisfactionBar);
            AddChild(_music);
            AddChild(_score);
            AddChild(_crowd);
            AddChild(_sideBar);
            AddChild(_satisfactionCase);
            AddChild(keyDropControl);

            AddSpeakers();
            AddLights();
            AddFlames();
            AddSmokeMachines();

            AddChild(_bandmembers);

        }

        ////////////////////////////////////////////////////////////////////////////
        ///until void Update(): spawn a object and add it to a list of those objects
        ////////////////////////////////////////////////////////////////////////////
        void AddSpeakers()
        {
            _speaker = new Speaker(33, 373);
            _speakers.Add(_speaker);
            _speaker = new Speaker(575, 373);
            _speakers.Add(_speaker);

            for(int i = 0; i < _speakers.Count; i++)
            {
                AddChild(_speakers[i]);
            }
        }
        void AddLights()
        {
            _light = new Light(this, 26, 112, "purple");
            _lights.Add(_light);
            _light = new Light(this, 122, 112, "pink");
            _lights.Add(_light);
            _light = new Light(this, 488, 112, "purple");
            _lights.Add(_light);
            _light = new Light(this, 575, 112, "pink");
            _lights.Add(_light);

            for (int i = 0; i < _lights.Count; i++)
            {
                AddChild(_lights[i]);
            }
        }
        void AddSmokeMachines()
        {
            _smokemachine = new SmokeMachine(this, 485, 362, true);
            _smokeMachines.Add(_smokemachine);
            _smokemachine = new SmokeMachine(this, 250, 362, false);
            _smokeMachines.Add(_smokemachine);

            for (int i = 0; i < _smokeMachines.Count; i++)
            {
                AddChild(_smokeMachines[i]);
            }
        }

        void AddFlames()
        {
            _flame = new Flame(this, 581, 272);
            _flames.Add(_flame);
            _flame = new Flame(this, 37, 272);
            _flames.Add(_flame);
            _flame = new Flame(this, 250, 299);
            _flames.Add(_flame);
            _flame = new Flame(this, 380, 299);
            _flames.Add(_flame);

            for (int i = 0; i < _flames.Count; i++)
            {
                AddChild(_flames[i]);

            }
        }

        void Update()
        {
            TestSong();
            TestAnimatables();
            TestScoring();
        }

        //if you press M it goes to the next song
        void TestSong()
        {
            if (Input.GetKeyDown(Key.M))
            {
                _music.NextSong();
            }
        }

        //if you failed something remove score. if you did something right add score
        void TestScoring()
        {
            if (keyDropControl.failed == true)
            {
                _satisfactionBar.SetRemoveScore();
                
            }
            else
            {
                if (keyDropControl.hitSpeaker == true)
                {
                    _score.AddScore();
                    _satisfactionBar.SetAddScore(5);
                }
                if (keyDropControl.hitSmoke == true)
                {
                    _score.AddScore();
                    _satisfactionBar.SetAddScore(5);
                }
                if (keyDropControl.hitLight == true)
                {
                    _score.AddScore();
                    _satisfactionBar.SetAddScore(5);
                }
                if (keyDropControl.hitFlame == true)
                {
                    _score.AddScore();
                    _satisfactionBar.SetAddScore(5);
                }

            }
        }

        //if you did something reght animate the right thing
        void TestAnimatables()
        {
            if (keyDropControl.hitFlame)
            {
                for (int i = 0; i < _flames.Count; i++)
                {
                    _flames[i].PlayAnimation();
                }
            }
            if (keyDropControl.hitSpeaker)
            {
                for(int i = 0; i < _speakers.Count; i++)
                {
                    _speakers[i].PlayAnimation();
                }
            }
            if (keyDropControl.hitLight)
            {
                for (int i = 0; i < _lights.Count; i++)
                {
                    _lights[i].PlayAnimation();
                }
            }
            if (keyDropControl.hitSmoke)
            {
                for (int i = 0; i < _smokeMachines.Count; i++)
                {
                    _smokeMachines[i].PlayAnimation();
                }
            }
        }

        public float GetSatisfaction()
        {
            return _satisfactionBar.scaling;
        }

        public float GetBPM()
        {
            return _music.bpm;
        }

        public int GetScore()
        {
            return _score.score;
        }

        public bool ChangeScreen()
        {
            if(_music.noMoreMusic)
            {
                _music.StopMusic();
                return true;
            }
            else
            {
                return false;
            }
        }      
    }
}