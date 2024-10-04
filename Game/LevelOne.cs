using CanvasEngine;
using CanvasEngine.Game;
using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class LevelOne : AbstractGame
    {
        #region vars
        private int boneMovementShort;
        private int boneMovementLong;
        private Bitmap boneShort;
        private Bitmap boneLong;
        private List<Bone> longBones = new List<Bone>();
        private List<BoneShort> shortBones = new List<BoneShort>();
        #endregion
        public LevelOne()  
        {
            boneShort = new Bitmap("\\boneShort.png");
            boneLong = new Bitmap("\\boneLong.png");
            for (int i = 0; i < 13; i++)
            {
                longBones.Add(new Bone(new Rectanglef(800 + (150 * i + boneMovementLong), 150, 50, 400), boneLong));
                shortBones.Add(new BoneShort(new Rectanglef(-1850 + (150 * i + boneMovementShort), 560, 23, 40), boneShort));
            }
        }

        public override void GameEnd()
        {
            boneLong.Dispose();
            boneShort.Dispose();
        }

        public bool HasCollisionLong(Player player) // checking collisions for player and longbones
        {
            for (int i = 0; i < longBones.Count; i++)
            {
                if (player.playerR.X < longBones[i].boneLongC.X + longBones[i].boneLongC.Width &&
                    player.playerR.X + player.playerR.Width > longBones[i].boneLongC.X &&
                    player.playerR.Y < longBones[i].boneLongC.Y + longBones[i].boneLongC.Height &&
                    player.playerR.Y + player.playerR.Height > longBones[i].boneLongC.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasCollisionShort(Player player) // checking collisions for player and shortbones
        {
            for (int i = 0; i < shortBones.Count; i++)
            {
                if (player.playerR.X < shortBones[i].boneShortC.X + shortBones[i].boneShortC.Width &&
                    player.playerR.X + player.playerR.Width > shortBones[i].boneShortC.X &&
                    player.playerR.Y < shortBones[i].boneShortC.Y + shortBones[i].boneShortC.Height &&
                    player.playerR.Y + player.playerR.Height > shortBones[i].boneShortC.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public override void Update()
        {
            boneMovementShort--;
            boneMovementLong--;
        }
    }
}
