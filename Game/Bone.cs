using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEngine
{

    public class Bone : GameObject
    {
        //this class is made to spawn the long bones and is reusable
        public Rectanglef boneLongC = new Rectanglef();       
        private Bitmap bitmap;

        public Bone(Rectanglef rect, Bitmap boneSize)
        {
            boneLongC = rect;
            bitmap = boneSize;
        }

        public override void Update()
        {
            boneLongC.X--;
        }

        public override void Paint()
        {
            GAME_ENGINE.DrawBitmap(bitmap, boneLongC.X, boneLongC.Y);
        }
    }
}

