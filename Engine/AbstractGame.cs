using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    /// <summary>
    /// Hides the basic setup from the XYZ class.
    /// </summary>
    public class AbstractGame : GameObject
    {
        /// <summary>
        /// Sets up several default values for the gameview.
        /// </summary>
        public override void GameInitialize()
        {
            // Set the required values
            GAME_ENGINE.SetTitle("Panic20");
            GAME_ENGINE.SetIcon("icon.ico");

            // Set the optional values
            GAME_ENGINE.SetScreenWidth(750);
            GAME_ENGINE.SetScreenHeight(600);
            GAME_ENGINE.SetBackgroundColor(0, 167, 141); //Appelblauwzeegroen
            //GAME_ENGINE.SetBackgroundColor(49, 77, 121); //The Unity background color
        }
    }
}
