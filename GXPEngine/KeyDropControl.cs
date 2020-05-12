using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace GXPEngine
{
    class KeyDropControl : Canvas
    {
        List<KeyDrop> _keyDrops;

        int millisecondCounter;

        public bool hitSpeaker;
        public bool hitLight;
        public bool hitFlame;
        public bool failed;
        public bool hitSmoke;

        string[] _hits;
        string _rows = "";
        string[] _row;

        int numberOfSpawns;

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
            InitializeSpawnFile();
        }

        void Update()
        {
            millisecondCounter += Time.deltaTime;
         
            if(millisecondCounter > 882)
            {
                AddKeyDrop();
                millisecondCounter = 0;
                numberOfSpawns = numberOfSpawns + 1;
            }

            TestHits();
            DeleteKeyDrops();
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

        void AddKeyDrop()
        {
            var _rowsToSpawnIn = new List<int>(); 
            bool check = false;


            Int32.TryParse(_row[numberOfSpawns], out int TempRows);
            _rowsToSpawnIn.Add(TempRows);

            while (check == false)
            {
                int checks = 0;

                var _rowsToRemove = new List<int>();
                var _rowsToAdd = new List<int>();
                foreach (int _row in _rowsToSpawnIn)
                {
                    if (_row > 9)
                    {
                        _rowsToRemove.Add(_row);
                        _rowsToAdd.Add(_row / 10);
                        _rowsToAdd.Add(_row % 10);
                    }
                    else
                    {
                        checks = checks + 1;
                    }
                }
                foreach(int _row in _rowsToRemove)
                {
                    _rowsToSpawnIn.Remove(_row);
                }

                foreach(int _row in _rowsToAdd)
                {
                    _rowsToSpawnIn.Add(_row);
                }

                if (checks == _rowsToSpawnIn.Count)
                {
                    check = true;
                }
            }

            foreach (int _finalRow in _rowsToSpawnIn)
            {
                if (_finalRow != 0)
                {
                    KeyDrop _keyDrop = new KeyDrop(_finalRow);
                    AddChild(_keyDrop);
                    _keyDrops.Add(_keyDrop);
                }
            }
               
                    
        }


        void InitializeSpawnFile()
        {
            string path = Path.GetDirectoryName("hits.txt");
            string[] lines = File.ReadAllLines(path + "hits.txt");
            int numberOfRowsGiven = 0;
            int numberOfRowsChecked = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                _hits = lines[i].Split(' ');
                for (int j = 0; j < _hits.Length; j++)
                {
                    numberOfRowsGiven = numberOfRowsGiven + 1;
                }
            }

            for (int i = 0; i < lines.Length; i++)
            {
                _hits = lines[i].Split(' ');               
                for (int j = 0; j < _hits.Length; j++)
                {
                     if (_hits.Length >= 1 && int.TryParse(_hits[j], out int row))
                     {
                        numberOfRowsChecked = numberOfRowsChecked + 1;
                        if(numberOfRowsChecked < numberOfRowsGiven)
                        {
                            _rows = _rows.Insert(_rows.Length, row.ToString() + ",");
                        }
                        else
                        {
                            _rows = _rows.Insert(_rows.Length, row.ToString());
                        }
                        
                     }
                    
                }
            }
            _row = _rows.Split(',');
        }
    }
}
