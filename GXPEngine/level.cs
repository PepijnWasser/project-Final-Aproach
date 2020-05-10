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

        List<Speaker> _speakers;
        Speaker _speaker;

        List<Light> _lights;
        Light _light;

        Bandmembers _bandmembers;

        List<Flame> _flames;
        Flame _flame;

        List<SmokeMachine> _smokeMachines;
        SmokeMachine _smokemachine;

        SatisfactionBar _satisfactionBar = new SatisfactionBar();

        Music _music = new Music();

        public Level() : base(600, 1080, false)
        {
            _bandmembers = new Bandmembers(this);

            _speakers = new List<Speaker>();
            _flames = new List<Flame>();
            _lights = new List<Light>();
            _smokeMachines = new List<SmokeMachine>();

            AddChild(space);
            AddChild(keyDropControl);           
            AddChild(_bandmembers);
            AddChild(_satisfactionBar);
            AddChild(_music);

            AddSpeakers();
            AddLights();
            AddFlames();
            AddSmokeMachines();

        }

        void AddSpeakers()
        {
            _speaker = new Speaker(200, 200);
            _speakers.Add(_speaker);
            _speaker = new Speaker(500, 500);
            _speakers.Add(_speaker);

            for(int i = 0; i < _speakers.Count; i++)
            {
                AddChild(_speakers[i]);
            }
        }
        void AddLights()
        {
            _light = new Light(this, 100, 100);
            _lights.Add(_light);
            _light = new Light(this, 400, 400);
            _lights.Add(_light);

            for (int i = 0; i < _lights.Count; i++)
            {
                AddChild(_lights[i]);
            }
        }
        void AddSmokeMachines()
        {
            _smokemachine = new SmokeMachine(this, 700, 100);
            _smokeMachines.Add(_smokemachine);
            _smokemachine = new SmokeMachine(this, 600, 700);
            _smokeMachines.Add(_smokemachine);

            for (int i = 0; i < _smokeMachines.Count; i++)
            {
                AddChild(_smokeMachines[i]);
            }
        }

        void AddFlames()
        {
            _flame = new Flame(this, 100, 100);
            _flames.Add(_flame);
            _flame = new Flame(this, 400, 400);
            _flames.Add(_flame);

            for (int i = 0; i < _flames.Count; i++)
            {
                AddChild(_flames[i]);

            }
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
                _satisfactionBar.SetAddScore(5);
            }

            if(keyDropControl.switched == true)
            {
                _satisfactionBar.SetAddScore(15);
            }
        }

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