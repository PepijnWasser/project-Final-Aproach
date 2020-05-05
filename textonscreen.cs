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

        Font f = new Font(new FontFamily("Verdana"), 20);

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
            graphics.DrawString(_top1player, f, Brushes.White, 410, 351);
            graphics.DrawString(_top2player, f, Brushes.White, 410, 400);
            graphics.DrawString(_top3player, f, Brushes.White, 410, 449);
            graphics.DrawString(_top4player, f, Brushes.White, 410, 498);
            graphics.DrawString(_top5player, f, Brushes.White, 410, 547);

            graphics.DrawString(_top1score, f, Brushes.White, 175, 351);
            graphics.DrawString(_top2score, f, Brushes.White, 175, 400);
            graphics.DrawString(_top3score, f, Brushes.White, 175, 449);
            graphics.DrawString(_top4score, f, Brushes.White, 175, 498);
            graphics.DrawString(_top5score, f, Brushes.White, 175, 547);

            //sets your current achievment and player number
            graphics.DrawString(_scoreGot, f, Brushes.White, 275, 624);
            graphics.DrawString(_yourplayernumber, f, Brushes.White, 410, 624);
        }
    }   
}
