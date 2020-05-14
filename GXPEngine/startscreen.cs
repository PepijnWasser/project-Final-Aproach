using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;

namespace GXPEngine
{
    class Startscreen : Canvas
    {
        MenuMusic _music = new MenuMusic();

        Sprite background = new Sprite("MuseBg.jpg");
        Sprite play = new Sprite("play.png");
        Sprite highscore = new Sprite("highscore.png");
        Sprite exit = new Sprite("exit.png");

        public bool highscorePressed = false;

        public Startscreen() : base(960, 720)
        {
            AddChild(background);
            AddChild(play);
            AddChild(highscore);
            AddChild(exit);

            play.SetXY(40, 230);
            highscore.SetXY(40, 320);
            exit.SetXY(40, 410);

            scaleDown(0.65f);
        }

        void Update()
        {
            MenuSelector();
        }

        void scaleDown(float x)
        {
            play.SetScaleXY(x, x);
            highscore.SetScaleXY(x, x);
            exit.SetScaleXY(x, x);
        }

        /// ///////////////////////////////////////////////////////////////////////
        /// if left click is pressed over play button, return true
        /// ///////////////////////////////////////////////////////////////////////
        public bool ChangeScreen()
        {
            if (play.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButton(0))
                {
                    _music.StopMusic();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }

        void MenuSelector()
        {
            if (highscore.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButton(0))
                {
                    _music.StopMusic();
                    highscorePressed = true;
                }
            }

            if (exit.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButton(0))
                {
                    MyGame myGame = (MyGame)game;
                    myGame.LateDestroy();
                }
            }
        }
    }
}
