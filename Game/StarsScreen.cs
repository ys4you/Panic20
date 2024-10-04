using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEngine 
{
    public class StartScreen : GameObject
    {
        private Button Start = null;
        private Button back = null;
        private Button Explanation = null;
        public bool isRunning = true;
        private bool isExplanationShowing = false;
        public StartScreen()
        {
            Start = new Button(OnButtonClick, "start", 200, 300, 125, 50);
            Explanation = new Button(OnButtonClickExplanation, "explanation", 400, 300, 125, 50);
            back = new Button(OnButtonClickBack, "back", 0, 0, 50, 50);
            back.SetActive(false);
        }

        private void OnButtonClick()
        {
            isRunning = false;
            Start.SetActive(false);
            SetActive(false);
            Explanation.SetActive(false);
        }

        private void OnButtonClickExplanation()
        {
            Start.SetActive(false);
            Explanation.SetActive(false);
            back.SetActive(true);
            isExplanationShowing = true;
        }

        private void OnButtonClickBack()
        {
            Start.SetActive(true);
            Explanation.SetActive(true);
            back.SetActive(false);
            isExplanationShowing = false;
        }

        public override void Paint()
        {
            GAME_ENGINE.SetColor(Color.Black);
            GAME_ENGINE.FillRectangle(0, 0, 800, 800);

            if(isExplanationShowing == true)
            {
                GAME_ENGINE.SetColor(Color.White);
                GAME_ENGINE.SetScale(3, 3);
                GAME_ENGINE.DrawString("Explanations:", 80, 30, 100, 100);
                GAME_ENGINE.DrawString("Keybinds:", 500, 30, 100, 100);
                GAME_ENGINE.ResetScale();
                GAME_ENGINE.SetScale(2, 2);
                GAME_ENGINE.DrawString("The goal of this game is to survive 20 seconds. It is based on an attack of Sans from Undertale.", 80, 100, 100, 200);
                GAME_ENGINE.DrawString("W   -   Jump", 500, 100, 100, 100);
                GAME_ENGINE.DrawString("A   -   Move left",500, 150, 100, 100);
                GAME_ENGINE.DrawString("D   -   Move Right",500, 200, 100, 100);
                GAME_ENGINE.DrawString("R   -   Reset", 500, 250, 200, 100);
                GAME_ENGINE.ResetScale();
                GAME_ENGINE.DrawString("You cannot do a reset when you win", 500, 280, 100, 100);
            }
            else
            {
                GAME_ENGINE.SetColor(Color.White);
                GAME_ENGINE.SetScale(5, 5);
                GAME_ENGINE.DrawString("Panic20", 235, 100, 100, 100);
                GAME_ENGINE.ResetScale();
                GAME_ENGINE.SetColor(Color.Red);
                GAME_ENGINE.DrawString("Made by: Yesse Seijnaeve", 280,350,200,100);
                GAME_ENGINE.SetColor(Color.Black);

            }
            GAME_ENGINE.SetColor(Color.Black);
        }
    }
}
