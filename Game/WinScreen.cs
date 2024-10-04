using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEngine
{
    public class WinScreen : GameObject
    {
        public WinScreen()
        {
            
        }

        public override void Paint()
        {
            GAME_ENGINE.SetColor(Color.White);
            GAME_ENGINE.SetScale(2, 2);
            GAME_ENGINE.DrawString("Congratulations!", 290, 250, 100, 100);
            GAME_ENGINE.DrawString("You have survived", 290, 300, 100, 100);
            GAME_ENGINE.ResetScale();
            GAME_ENGINE.SetColor(Color.Black);
        }
    }
}
