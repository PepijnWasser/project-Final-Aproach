using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GXPEngine
{
    class Score : Canvas
    {
        Level _level;
        int _score = 99;

        Font f = new Font(new FontFamily("Verdana"), 60);

        public Score(Level level) : base(960, 720)
        {
            _level = level;
        }

        void Update()
        {
            graphics.Clear(Color.Empty);
            if(_score < 10)
            {
                graphics.DrawString(_score.ToString(), f, Brushes.White, 320, 220);
            }
            else if(_score < 100)
            {
                graphics.DrawString(_score.ToString(), f, Brushes.White, 310, 220);
            }
            else if(_score < 1000)
            {
                graphics.DrawString(_score.ToString(), f, Brushes.White, 280, 220);
            }
            else
            {
                graphics.DrawString(_score.ToString(), f, Brushes.White, 250, 220);
            }
           
        }

        public void AddScore()
        {
            if (_level.GetSatisfaction() <= 10)
            {
                _score = _score + 1;
            }
            if (_level.GetSatisfaction() > 10 && _level.GetSatisfaction() < 40)
            {
                _score = _score + 2;
            }
            else if(_level.GetSatisfaction() >= 40)
            {
                _score = _score + 3;
            }
        }
    }
}
