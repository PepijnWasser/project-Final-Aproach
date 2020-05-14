using System;
using System.IO;
using System.Collections.Generic;

namespace GXPEngine
{
    class EndScreen : Sprite
    {
        readonly string _scores = "";        
        readonly string[] _words;
        readonly string[] _playerThatGotHighScoreLine;
        readonly string _players = "";
        readonly string _scoretoCompare;

        readonly int _top1Player;
        readonly int _top2Player;
        readonly int _top3Player;
        readonly int _top4Player;
        readonly int _top5Player;

        readonly int _top1Score = 1;
        readonly int _top2Score = 1;
        readonly int _top3Score = 1;
        readonly int _top4Score = 1;
        readonly int _top5Score = 1;
        readonly int _heigestPlayerNumber = 1;
        readonly int _yourPlayerNumber;
        readonly int _yourPosition;
        readonly int _scoreGot;

        Sprite playAgain = new Sprite("Restart.png");
        Sprite exit = new Sprite("Exit1.png");

        public bool replay = false;

        public EndScreen(int scoreGot) : base("Endscreen1.png")
        {
            /*this.SetXY(0, -10);
            this.SetScaleXY((float)1.2, (float)1.2);*/

            _scoreGot = scoreGot;
            string path = Path.GetDirectoryName("scoreboard.txt");
            string[] lines = File.ReadAllLines(path + "scoreboard.txt");

            //make an array with all scores got
            for (int i = 0; i < lines.Length; i++)
            {              
                if (lines[i].Length >= 5 && lines[i].Substring(0, 5).ToUpper() == "SCORE")
                {
                    _words = lines[i].Split(':');
                    if (_words.Length >= 2 && int.TryParse(_words[1], out int score))
                    {
                         _scores = _scores.Insert(0, score.ToString()+",");
                    }
                }
            }

            //for each score in the array, test what position it is. if it is in top3 update others
            string[] _score = _scores.Split(',');
            for (int i = 0; i < _score.Length; i++)
            {
                //sets your position
                Int32.TryParse(_score[i], out int TempScore);
                if(TempScore >= _scoreGot)
                {
                    _yourPosition = _yourPosition + 1;
                }
                if (TempScore >= _top1Score)
                {
                    _top5Score = _top4Score;
                    _top4Score = _top3Score;
                    _top3Score = _top2Score;
                    _top2Score = _top1Score;
                    _top1Score = TempScore;
                }
                else if (TempScore >= _top2Score)
                {
                    _top5Score = _top4Score;
                    _top4Score = _top3Score;
                    _top3Score = _top2Score;
                    _top2Score = TempScore;
                }
                else if (TempScore >= _top3Score)
                {
                    _top5Score = _top4Score;
                    _top4Score = _top3Score;
                    _top3Score = TempScore;
                    
                }
                else if (TempScore >= _top4Score)
                {
                    _top5Score = _top4Score;
                    _top4Score = TempScore;
                }
                else if (TempScore >= _top5Score)
                {
                    _top5Score = TempScore;
                }

            }

            //search for topscore and get the player who got that score
            var playerNumbersUsed = new List<int>();
            bool player1Full = false;
            bool player2Full = false;
            bool player3Full = false;
            bool player4Full = false;
            bool player5Full = false;

            for (int i = 0; i < lines.Length; i++)
            {               
                _scoretoCompare = _top1Score.ToString();
                int top1scorelength = Int32.Parse(Math.Ceiling(Math.Log10(_top1Score)).ToString());
                if(_top1Score == 1)
                {
                    top1scorelength = 1;
                }
                if (_top1Score == 10)
                {
                    top1scorelength = 2;
                }
                if (_top1Score == 100)
                {
                    top1scorelength = 3;
                }
                if (_top1Score == 1000)
                {
                    top1scorelength = 4;
                }
                if (_top1Score == 10000)
                {
                    top1scorelength = 5;
                }
                if (lines[i].Length >= 7 + top1scorelength && lines[i].Substring(0, 7 + top1scorelength).ToUpper() == "SCORE: "+_top1Score)
                {                   
                    _playerThatGotHighScoreLine = lines[i - 1].Split(':');                   
                    if (_playerThatGotHighScoreLine.Length >= 2 && int.TryParse(_playerThatGotHighScoreLine[1], out int player1))
                    {
                        bool used = false;
                        foreach (int player in playerNumbersUsed)
                        {
                            if (player1 == player)
                            {
                                used = true;
                                Console.WriteLine("test");
                            }
                        }
                        if (used == false && player1Full == false)
                        {
                            player1Full = true;
                            _top1Player = player1;
                            Console.WriteLine("player 1");
                            playerNumbersUsed.Add(Int32.Parse(_playerThatGotHighScoreLine[1]));
                        }
                    }
                }
                _scoretoCompare = _top2Score.ToString();
                int top2scorelength = Int32.Parse(Math.Ceiling(Math.Log10(_top2Score)).ToString());
                if (_top2Score == 1)
                {
                    top2scorelength = 1;
                }
                if (_top2Score == 10)
                {
                    top2scorelength = 2;
                }
                if (_top2Score == 100)
                {
                    top2scorelength = 3;
                }
                if (_top2Score == 1000)
                {
                    top2scorelength = 4;
                }
                if (_top2Score == 10000)
                {
                    top2scorelength = 5;
                }
                if (lines[i].Length >= 7 + top2scorelength && lines[i].Substring(0, 7 + top2scorelength).ToUpper() == "SCORE: " + _top2Score)
                {
                    _playerThatGotHighScoreLine = lines[i - 1].Split(':');
                    if (_playerThatGotHighScoreLine.Length >= 2 && int.TryParse(_playerThatGotHighScoreLine[1], out int player2))
                    {
                        bool used = false;
                        foreach (int player in playerNumbersUsed)
                        {
                            if (player2 == player)
                            {
                                used = true;
                            }
                        }
                        if (used == false && player2Full == false)
                        {
                            player2Full = true;
                            _top2Player = player2;
                            Console.WriteLine("player 2");
                            playerNumbersUsed.Add(Int32.Parse(_playerThatGotHighScoreLine[1]));
                        }
                    }
                }
                _scoretoCompare = _top3Score.ToString();
                int top3scorelength = Int32.Parse(Math.Ceiling(Math.Log10(_top3Score)).ToString());
                if (_top3Score == 1)
                {
                    top3scorelength = 1;
                }
                if (_top3Score == 10)
                {
                    top3scorelength = 2;
                }
                if (_top3Score == 100)
                {
                    top3scorelength = 3;
                }
                if (_top3Score == 1000)
                {
                    top3scorelength = 4;
                }
                if (_top3Score == 10000)
                {
                    top3scorelength = 5;
                }
                if (lines[i].Length >= 7 + top3scorelength && lines[i].Substring(0, 7 + top3scorelength).ToUpper() == "SCORE: " + _top3Score)
                {
                    _playerThatGotHighScoreLine = lines[i - 1].Split(':');
                    if (_playerThatGotHighScoreLine.Length >= 2 && int.TryParse(_playerThatGotHighScoreLine[1], out int player3))
                    {
                        bool used = false;
                        foreach (int player in playerNumbersUsed)
                        {
                            if (player3 == player)
                            {
                                used = true;
                            }
                        }
                        if (used == false && player3Full == false)
                        {
                            player3Full = true;
                            _top3Player = player3;
                            Console.WriteLine("player 3");
                            playerNumbersUsed.Add(Int32.Parse(_playerThatGotHighScoreLine[1]));
                        }
                    }
                }
                _scoretoCompare = _top4Score.ToString();
                int top4scorelength = Int32.Parse(Math.Ceiling(Math.Log10(_top4Score)).ToString());
                if (_top1Score == 1)
                {
                    top4scorelength = 1;
                }
                if (_top4Score == 10)
                {
                    top4scorelength = 2;
                }
                if (_top4Score == 100)
                {
                    top4scorelength = 3;
                }
                if (_top4Score == 1000)
                {
                    top4scorelength = 4;
                }
                if (_top4Score == 10000)
                {
                    top4scorelength = 5;
                }
                if (lines[i].Length >= 7 + top3scorelength && lines[i].Substring(0, 7 + top4scorelength).ToUpper() == "SCORE: " + _top4Score)
                {
                    _playerThatGotHighScoreLine = lines[i - 1].Split(':');
                    if (_playerThatGotHighScoreLine.Length >= 2 && int.TryParse(_playerThatGotHighScoreLine[1], out int player4))
                    {
                        bool used = false;
                        foreach (int player in playerNumbersUsed)
                        {
                            if (player4 == player)
                            {
                                used = true;
                            }
                        }
                        if (used == false && player4Full == false)
                        {
                            player4Full = true;
                            _top4Player = player4;
                            Console.WriteLine("player 4");
                            playerNumbersUsed.Add(Int32.Parse(_playerThatGotHighScoreLine[1]));
                        }
                    }
                }
                _scoretoCompare = _top5Score.ToString();
                int top5scorelength = Int32.Parse(Math.Ceiling(Math.Log10(_top5Score)).ToString());
                if (_top5Score == 1)
                {
                    top5scorelength = 1;
                }
                if (_top5Score == 10)
                {
                    top5scorelength = 2;
                }
                if (_top5Score == 100)
                {
                    top5scorelength = 3;
                }
                if (_top5Score == 1000)
                {
                    top5scorelength = 4;
                }
                if (_top5Score == 10000)
                {
                    top5scorelength = 5;
                }
                if (lines[i].Length >= 7 + top3scorelength && lines[i].Substring(0, 7 + top5scorelength).ToUpper() == "SCORE: " + _top5Score)
                {
                    _playerThatGotHighScoreLine = lines[i - 1].Split(':');
                    if (_playerThatGotHighScoreLine.Length >= 2 && int.TryParse(_playerThatGotHighScoreLine[1], out int player5))
                    {
                        bool used = false;
                        foreach(int player in playerNumbersUsed)
                        {
                            if(player5 == player)
                            {
                                used = true;
                            }
                        }
                        if(used == false && player5Full == false)
                        {
                            player5Full = true;
                            _top5Player = player5;
                            Console.WriteLine("player 5");
                            playerNumbersUsed.Add(Int32.Parse(_playerThatGotHighScoreLine[1]));
                        }
                    }
                }
            }

            foreach(int player in playerNumbersUsed)
            {
                Console.WriteLine(player);
            }

            //make an array with all scores got
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length >= 6 && lines[i].Substring(0, 6).ToUpper() == "PLAYER")
                {
                    _words = lines[i].Split(':');
                    if (_words.Length >= 2 && int.TryParse(_words[1], out int player))
                    {
                        _players = _players.Insert(0, player.ToString() + ",");
                    }
                }
            }
            string[] _individualPlayers = _players.Split(',');
            for (int i = 0; i < _individualPlayers.Length; i++)
            {
                Int32.TryParse(_individualPlayers[i], out int TempPlayer);
                if (TempPlayer > _heigestPlayerNumber)
                {
                    _heigestPlayerNumber = TempPlayer;
                    _yourPlayerNumber = _heigestPlayerNumber + 1;             
                }
            }
            File.AppendAllText(path + "scoreboard.txt", System.Environment.NewLine + "PLAYER: " + _yourPlayerNumber + System.Environment.NewLine + "SCORE: " + _scoreGot);
       
            //draws all scores
            //---------------------------potentionally better way to do things
            textonscreen values = new textonscreen(_top1Player, _top1Score, _top2Player, _top2Score, _top3Player, _top3Score, _top4Player, _top4Score, _top5Player, _top5Score, _yourPlayerNumber, _yourPosition, _scoreGot);
            AddChild(values);

            AddChild(playAgain);
            AddChild(exit);

            playAgain.SetXY(783, 15);
            exit.SetXY(878, 15);
        }

        void Update()
        {
            PlayAgain();
        }

        /// ///////////////////////////////////////////////////////////////////////
        /// if left click is pressed over "X" icon, return true
        /// ///////////////////////////////////////////////////////////////////////
        public bool ChangeScreen()
        {
            if (exit.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButton(0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
            else return false;
        }

        void PlayAgain()
        {
            if (playAgain.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButton(0))
                {
                    replay = true;
                }
            }
        }
    }
}