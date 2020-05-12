using System;
using System.IO;

namespace GXPEngine
{
    class EndScreen : Sprite
    {
        readonly string _scores = "";        
        readonly string[] _words;
        readonly string[] _playerThatGotHighScoreLine;
        readonly string _players = "";
        readonly string _scoretoCompare;
        string path = Path.GetDirectoryName("scoreboard.txt");

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

        //-------------------------------endscreen needs new image
        public EndScreen() : base("endScreen.png")
        {
            this.SetXY(0, -10);
            this.SetScaleXY((float)1.2, (float)1.2);

            //needs to be updated to the score 
            _scoreGot = 4;
            string[] lines = File.ReadAllLines(path + "txt");

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
            for (int i = 0; i < lines.Length; i++)
            {
                _scoretoCompare = _top1Score.ToString();               
                int top1scorelength = Int32.Parse(Math.Ceiling(Math.Log10(_top1Score)).ToString());
                if (lines[i].Length >= 7 + top1scorelength && lines[i].Substring(0, 7 + top1scorelength).ToUpper() == "SCORE: "+_top1Score)
                {                   
                    _playerThatGotHighScoreLine = lines[i - 1].Split(':');
                    if (_playerThatGotHighScoreLine.Length >= 2 && int.TryParse(_playerThatGotHighScoreLine[1], out int player1))
                    {
                        _top1Player = player1;                    
                    } 
                }
                _scoretoCompare = _top2Score.ToString();
                int top2scorelength = Int32.Parse(Math.Ceiling(Math.Log10(_top2Score)).ToString());
                if (lines[i].Length >= 7 + top2scorelength && lines[i].Substring(0, 7 + top2scorelength).ToUpper() == "SCORE: " + _top2Score)
                {
                    _playerThatGotHighScoreLine = lines[i - 1].Split(':');
                    if (_playerThatGotHighScoreLine.Length >= 2 && int.TryParse(_playerThatGotHighScoreLine[1], out int player2))
                    {
                        _top2Player = player2;
                    }
                }
                _scoretoCompare = _top3Score.ToString();
                int top3scorelength = Int32.Parse(Math.Ceiling(Math.Log10(_top3Score)).ToString());
                if (lines[i].Length >= 7 + top3scorelength && lines[i].Substring(0, 7 + top3scorelength).ToUpper() == "SCORE: " + _top3Score)
                {
                    _playerThatGotHighScoreLine = lines[i - 1].Split(':');
                    if (_playerThatGotHighScoreLine.Length >= 2 && int.TryParse(_playerThatGotHighScoreLine[1], out int player3))
                    {
                        _top3Player = player3;
                    }
                }
                _scoretoCompare = _top4Score.ToString();
                int top4scorelength = Int32.Parse(Math.Ceiling(Math.Log10(_top4Score)).ToString());
                if (lines[i].Length >= 7 + top3scorelength && lines[i].Substring(0, 7 + top4scorelength).ToUpper() == "SCORE: " + _top4Score)
                {
                    _playerThatGotHighScoreLine = lines[i - 1].Split(':');
                    if (_playerThatGotHighScoreLine.Length >= 2 && int.TryParse(_playerThatGotHighScoreLine[1], out int player4))
                    {
                        _top4Player = player4;
                    }
                }
                _scoretoCompare = _top5Score.ToString();
                int top5scorelength = Int32.Parse(Math.Ceiling(Math.Log10(_top5Score)).ToString());
                if (lines[i].Length >= 7 + top3scorelength && lines[i].Substring(0, 7 + top5scorelength).ToUpper() == "SCORE: " + _top5Score)
                {
                    _playerThatGotHighScoreLine = lines[i - 1].Split(':');
                    if (_playerThatGotHighScoreLine.Length >= 2 && int.TryParse(_playerThatGotHighScoreLine[1], out int player5))
                    {
                        _top5Player = player5;
                    }
                }
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
            File.AppendAllText(@"C:\Users\peppi\OneDrive\Desktop\project final aproach\project\project lift off\GXPEngine\bin\Debug\scoreboard.txt", System.Environment.NewLine + "PLAYER: " + _yourPlayerNumber + System.Environment.NewLine + "SCORE: " + _scoreGot);
       
            //draws all scores
            //---------------------------potentionally better way to do things
            textonscreen values = new textonscreen(_top1Player, _top1Score, _top2Player, _top2Score, _top3Player, _top3Score, _top4Player, _top4Score, _top5Player, _top5Score, _yourPlayerNumber, _yourPosition, _scoreGot);
            AddChild(values);
        }

        /// ///////////////////////////////////////////////////////////////////////
        /// if R is pressed, return true
        /// ///////////////////////////////////////////////////////////////////////
        public bool ChangeScreen()
        {
            if (Input.GetKey(Key.E))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}