using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GXPEngine
{
    class SatisfactionBar : Sprite
    {
        public float scaling = 30;
        float showedScaling;
        int millisecondCounter;
        int millisecondCounter2;
        int millisecondCounter3;
        bool removeScore;
        int removeScoreCycles;
        bool addScore;
        float amountToAdd;
        bool lowGain;

        public SatisfactionBar() : base("satisfactionBar.png")
        {
            MyGame myGame = (MyGame)game;
            this.SetXY(0, myGame.height - 100);
        }

        void Update()
        {
            LowGainTime();
            AddScore();  
            RemoveScore();
            MakeLifelyFeeling();
            UpdateBar();
        }

        void AddScore()
        {
            if (addScore == true)
            {
                if (lowGain == false)
                {
                    scaling = scaling + amountToAdd / 10;
                }
                else
                {
                    scaling = scaling + amountToAdd / 50;
                }
                addScore = false;
            }
        }

        void RemoveScore()
        {
            if (removeScore == true)
            {
                lowGain = true;
                millisecondCounter2 = millisecondCounter2 + Time.deltaTime;
                if (millisecondCounter2 > 50)
                {
                    scaling = scaling - 1f;
                    millisecondCounter2 = 0;
                    removeScoreCycles = removeScoreCycles + 1;

                    if (removeScoreCycles == 5)
                    {
                        removeScore = false;                        
                    }
                }
            }
        }


        void LowGainTime()
        {
            millisecondCounter3 = millisecondCounter3 + Time.deltaTime;
            if (millisecondCounter3 > 5000)
            {
                millisecondCounter3 = 0;
                lowGain = false;
            }
        }

        void MakeLifelyFeeling()
        {
            millisecondCounter = millisecondCounter + Time.deltaTime;
            if (millisecondCounter > 50)
            {
                scaling = scaling + Utils.Random(-0.05f, 0.05f);
                millisecondCounter = 0;
            }
        }

        void UpdateBar()
        {
            showedScaling = scaling;
            this.SetScaleXY(showedScaling, 1);
        }

        public void SetAddScore(float amount)
        {
            addScore = true;
            amountToAdd = amount;
        }

        public void SetRemoveScore()
        {
            removeScore = true;
            removeScoreCycles = 0;
        }
    }
}
