using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Text;

namespace GXPEngine
{
    class Score : Canvas
    {
        Level _level;
        public int score = 10;

        string path = Path.GetDirectoryName("light pixel 7.ttf");
        
        PrivateFontCollection _pfc = new PrivateFontCollection();
        Font f;

        public Score(Level level) : base(960, 720)
        {
            _level = level;
            _pfc.AddFontFile(path + "light pixel 7.ttf");
            Console.WriteLine(_pfc.Families[0]);
            f = new Font(_pfc.Families[0], 30, FontStyle.Regular);
        }

        void Update()
        {
            graphics.Clear(Color.Empty);
            if(score < 10)
            {
                graphics.DrawString(score.ToString(), f, Brushes.HotPink, 260, 12);
            }
            else if(score < 100)
            {
                graphics.DrawString(score.ToString(), f, Brushes.HotPink, 250, 12);
            }
            else if(score < 1000)
            {
                graphics.DrawString(score.ToString(), f, Brushes.HotPink, 250, 12);
            }
            else
            {
                graphics.DrawString(score.ToString(), f, Brushes.HotPink, 240, 12);
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
