using CanvasEngine;
using GameEngine;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEngine
{
    public class Game : AbstractGame
    {
        #region vars
        private int levels = 1;
        Player player;
        LevelOne levelOne;
        StartScreen startScreen;
        private EndScreen EndScreen;
        private WinScreen winScreen;
        public bool isPlayerDeath = false;
        private int goToEndScreen = 0;
        public float playerHealth = 92;
        public Audio run = new Audio("Run.mp3");
        public Audio lastGoodbye = new Audio("lastGoodbye.mp3");
        private Audio gameoverMusic = new Audio("undertale_gameover.mp3");
        int endAudio = 0;
        private float timer;
        #endregion

        public override void GameStart()
        {
            startScreen = new StartScreen();
            GAME_ENGINE.SetBackgroundColor(Color.Black);
            player = new Player();
            player.SetActive(false);
        }

        public void LevelCheck()
        {
            //changing levels 
            if (GAME_ENGINE.GetKeyDown(Key.X)) levels++;
            if (levels == 1)
            {
                GAME_ENGINE.PlayAudio(run);
                levelOne = new LevelOne();
                levels = 2;
            }
        }
        
        public void WinCon()
        {
            if (goToEndScreen == 0)
            {
                timer += GAME_ENGINE.GetDeltaTime();
            }

            if (timer >= 20 && isPlayerDeath == false)
            {
                goToEndScreen = 1;
                winScreen = new WinScreen();
                endAudio++;
                GAME_ENGINE.StopAudio(run);
                player.Dispose();
                levelOne.Dispose();
                if (GAME_ENGINE.GetKeyDown(Key.R))
                {
                    GAME_ENGINE.StopAudio(lastGoodbye);
                    gameoverMusic.Dispose();
                    new Game().GameStart();
                    Dispose();
                    winScreen.Dispose();
                }
            }

            if (endAudio == 1)
            {
                GAME_ENGINE.PlayAudio(lastGoodbye);
                endAudio++;
            }
        }

        public override void Update()
        {
            if (startScreen.isRunning == false)
            {
                //damage to player
                if (levelOne != null && levelOne.HasCollisionLong(player) || levelOne != null && levelOne.HasCollisionShort(player)) playerHealth -= 0.4f;
                //if the player is death do to the end screen
                if (playerHealth <= 0 && goToEndScreen == 0)
                {
                    levelOne.Dispose();
                    player.Dispose();
                    GAME_ENGINE.PlayAudio(gameoverMusic);
                    isPlayerDeath = true;
                    EndScreen = new EndScreen();
                    GAME_ENGINE.StopAudio(run);
                    goToEndScreen++;
                }
                if (GAME_ENGINE.GetKeyDown(Key.R) && goToEndScreen == 1)
                {
                    GAME_ENGINE.StopAudio(gameoverMusic);
                    gameoverMusic.Dispose();
                    new Game().GameStart(); 
                    Dispose();
                    EndScreen.SetActive(false);

                }
                LevelCheck();
                WinCon();
                player.SetActive(true);          
            }
            //closes the window
            if (GAME_ENGINE.GetKeyDown(Key.Escape)) Environment.Exit(0);
        }

        public override void Paint()
        {
            if (startScreen.isRunning == false)
            {
                GAME_ENGINE.SetColor(Color.Red);
                GAME_ENGINE.SetScale(3, 3);
                GAME_ENGINE.DrawString("HP: " + Math.Round(playerHealth), GAME_ENGINE.GetScreenWidth() / 2 - 100, 5, 100, 100);
                GAME_ENGINE.SetColor(Color.White);
                GAME_ENGINE.DrawString("Timer: " + Math.Round(timer), 0, 0, 100, 100);
                GAME_ENGINE.ResetScale();
                GAME_ENGINE.SetColor(Color.Black);
            }
        }
    }
}
