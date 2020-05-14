using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Text;


namespace GXPEngine
{
    class textonscreen : Canvas
    {
        string _top1score;
        string _top2score;
        string _top3score;
        string _top4score;
        string _top5score;
        string _scoreGot;

        string path = Path.GetDirectoryName("light pixel 7.ttf");

        PrivateFontCollection _pfc = new PrivateFontCollection();

        Font f, g, h, i, j;

        public textonscreen(int top1player, int top1score, int top2player, int top2score, int top3player, int top3score, int top4player, int top4score, int top5player, int top5score, int yourplayernumber, int yourPosition, int scoreGot) : base(600, 800)
        {
            _pfc.AddFontFile(path + "light pixel 7.ttf");
            f = new Font(_pfc.Families[0], 10, FontStyle.Regular);
            g = new Font(_pfc.Families[0], 15, FontStyle.Regular);
            h = new Font(_pfc.Families[0], 20, FontStyle.Regular);
            i = new Font(_pfc.Families[0], 25, FontStyle.Regular);
            j = new Font(_pfc.Families[0], 30, FontStyle.Regular);

            _top1score = top1score.ToString();
            _top2score = top2score.ToString();
            _top3score = top3score.ToString();
            _top4score = top4score.ToString();
            _top5score = top5score.ToString();
            _scoreGot = scoreGot.ToString();

            //sets score and player
            graphics.Clear(Color.Empty);

            graphics.DrawString(_top1score, f, Brushes.Cyan, 520, 220);
            graphics.DrawString(_top2score, g, Brushes.Cyan, 510, 285);
            graphics.DrawString(_top3score, h, Brushes.Cyan, 500, 365);
            graphics.DrawString(_top4score, i, Brushes.Cyan, 490, 465);
            graphics.DrawString(_top5score, j, Brushes.Cyan, 480, 595);

            //sets your current achievment and player number
            graphics.DrawString(_scoreGot, h, Brushes.Cyan, 550, 155);
            /*graphics.DrawString(_yourplayernumber, f, Brushes.Cyan, 550, 190);*/

        }
    }
}
