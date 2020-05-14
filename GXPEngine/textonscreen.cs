using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace GXPEngine
{
    class textonscreen : Canvas
    {
        string _top1player;
        string _top1score;
        string _top2player;
        string _top2score;
        string _top3player;
        string _top3score;
        string _top4player;
        string _top4score;
        string _top5player;
        string _top5score;
        string _yourplayernumber;
        string _yourPosition;
        string _scoreGot;

        Font f = new Font(new FontFamily("Light Pixel-7"), 10);
        Font g = new Font(new FontFamily("Light Pixel-7"), 15);
        Font h = new Font(new FontFamily("Light Pixel-7"), 20);
        Font i = new Font(new FontFamily("Light Pixel-7"), 25);
        Font j = new Font(new FontFamily("Light Pixel-7"), 30);

        public textonscreen(int top1player, int top1score, int top2player, int top2score, int top3player, int top3score, int top4player, int top4score, int top5player, int top5score, int yourplayernumber, int yourPosition, int scoreGot) : base(600, 800)
            {
            _top1player = top1player.ToString();
            _top1score = top1score.ToString();
            _top2player = top2player.ToString();
            _top2score = top2score.ToString();
            _top3player = top3player.ToString();
            _top3score = top3score.ToString();
            _top4player = top4player.ToString();
            _top4score = top4score.ToString();
            _top5player = top5player.ToString();
            _top5score = top5score.ToString();
            _yourplayernumber = yourplayernumber.ToString();
            _yourPosition = yourPosition.ToString();
            _scoreGot = scoreGot.ToString();
            
            //sets score and player
            graphics.Clear(Color.Empty);
            /*graphics.DrawString(_top1player, f, Brushes.Cyan, 410, 351);
            graphics.DrawString(_top2player, f, Brushes.Cyan, 410, 400);
            graphics.DrawString(_top3player, f, Brushes.Cyan, 410, 449);
            graphics.DrawString(_top4player, f, Brushes.Cyan, 410, 498);
            graphics.DrawString(_top5player, f, Brushes.Cyan, 410, 547);*/

            graphics.DrawString(_top1score, f, Brushes.Cyan, 390, 250);
            graphics.DrawString(_top2score, g, Brushes.Cyan, 380, 305);
            graphics.DrawString(_top3score, h, Brushes.Cyan, 370, 375);
            graphics.DrawString(_top4score, i, Brushes.Cyan, 360, 465);
            graphics.DrawString(_top5score, j, Brushes.Cyan, 350, 585);

            //sets your current achievment and player number
            graphics.DrawString(_scoreGot, h, Brushes.Cyan, 500, 190);
            /*graphics.DrawString(_yourplayernumber, f, Brushes.Cyan, 550, 190);*/

        }
    }   
}
