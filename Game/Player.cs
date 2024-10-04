using GameEngine;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Player : GameObject
    {
        #region vars
        private Bitmap _blueSoul;
        private float gravityY = 1;
        private float ground = 570;
        public Rectanglef playerR = new Rectanglef(300, 570, 30, 30);
        #endregion
        public Player()
        {
            _blueSoul = new Bitmap("\\BlueSoul.png");
        }

        public override void GameEnd()
        {
            _blueSoul.Dispose();
        }

        public override void Update()
        {
            playerR.Y += gravityY;

            if (playerR.Y < ground)
            {
                gravityY += 0.15f;
            }
            else gravityY = 0;

            if (GAME_ENGINE.GetKey(Key.A)) playerR.X -= 1.8f;

            if (GAME_ENGINE.GetKey(Key.D)) playerR.X += 1.8f;

            if (playerR.X <= 0) playerR.X = 0;

            if (playerR.X >= 750 - playerR.Width) playerR.X = 750 - playerR.Width;

            if (playerR.X >= GAME_ENGINE.GetScreenHeight() + 170) playerR.X -= 1.8f;

            if (playerR.Y >= 570)
            {
                if (GAME_ENGINE.GetKey(Key.W))
                {
                    gravityY = -6;
                    playerR.Y += -1;
                }
            }
        }

        public override void Paint()
        {
            GAME_ENGINE.DrawBitmap(_blueSoul, playerR.X, playerR.Y);
        }
    }

}
