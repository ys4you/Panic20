using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEngine.Game
{
    public class BoneShort : GameObject
    {
        //this class is made to spawn the short bones and is reusable
        public Rectanglef boneShortC = new Rectanglef();
        Bitmap bitmap; 

        public BoneShort(Rectanglef rect, Bitmap boneSize)
        {
            boneShortC = rect;
            bitmap = boneSize;
        }

        public override void Update()
        {
            boneShortC.X++;
        }

        public override void Paint()
        {
            GAME_ENGINE.DrawBitmap(bitmap, boneShortC.X, boneShortC.Y);
        }
    }
}
