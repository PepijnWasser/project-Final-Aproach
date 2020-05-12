using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GXPEngine
{
    class SatisfactionBar : Sprite
    {
        public float scaling = 0;
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
            this.SetXY(0, 10);
        }

        void Update()
        {
            LowGainTime();
            AddScore();  
            RemoveScore();
            MakeLifelyFeeling();
            UpdateBar();
        }

        // if score needs to be added add it
        //decrease the amount added when a mistake was made recently
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

        // remove score and indicate a mistake was made
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

        //if a mistake was made set LowGain to true for 5000 milliseconds
        void LowGainTime()
        {
            millisecondCounter3 = millisecondCounter3 + Time.deltaTime;
            if (millisecondCounter3 > 5000)
            {
                millisecondCounter3 = 0;
                lowGain = false;
            }
        }

        //add random spasms to the bar
        //overal these spasms do not add/remove anything
        void MakeLifelyFeeling()
        {
            millisecondCounter = millisecondCounter + Time.deltaTime;
            if (millisecondCounter > 50)
            {
                scaling = scaling + Utils.Random(-0.05f, 0.05f);
                millisecondCounter = 0;
            }
        }

        // update the size of the bar
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
