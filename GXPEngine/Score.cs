using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace GXPEngine
{
    class Score : Canvas
    {
        Level _level;
        public int score = 1000;

        Font f = new Font(new FontFamily("Verdana"), 45);

        public Score(Level level) : base(960, 720)
        {
            _level = level;
        }

        void Update()
        {
            graphics.Clear(Color.Empty);
            if(score < 10)
            {
                graphics.DrawString(score.ToString(), f, Brushes.HotPink, 260, 2);
            }
            else if(score < 100)
            {
                graphics.DrawString(score.ToString(), f, Brushes.HotPink, 250, 2);
            }
            else if(score < 1000)
            {
                graphics.DrawString(score.ToString(), f, Brushes.HotPink, 230, 2);
            }
            else
            {
                graphics.DrawString(score.ToString(), f, Brushes.HotPink, 230, 2);
            }
           
        }

        public void AddScore()
        {
            if (_level.GetSatisfaction() <= 2)
            {
                score = score + 1;
            }
            if (_level.GetSatisfaction() > 2 && _level.GetSatisfaction() < 22)
            {
                score = score + 2;
            }
            else if(_level.GetSatisfaction() >= 22)
            {
                score = score + 3;
            }
        }
    }
}
