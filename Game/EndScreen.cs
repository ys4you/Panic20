using GameEngine;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEngine
{
    public class EndScreen : GameObject
    {
        private Bitmap gameOver = null;
        private Audio gameoverMusic = new Audio("undertale_gameover.mp3");

        public EndScreen()
        {
            gameOver = new Bitmap("\\game-over.png");
        }

        public override void GameStart()
        {
            
        }


        public override void GameEnd()
        {

        }

        public override void Update()
        {
            
        }

        public override void Paint()
        {
            GAME_ENGINE.DrawBitmap(gameOver,0,0);
            GAME_ENGINE.SetColor(Color.Red);
            GAME_ENGINE.DrawString("Please wait 15 seconds or restart the game... game is rebooting",200,5,1000,200);
        }
    }
}
