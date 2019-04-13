using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame.src
{
    public class Screen
    {
        private Bitmap gameScreen;

      
        public void DrawBackground()
        {
            SwinGame.DrawBitmap(gameScreen, 0, 0);
        }
        public Screen()
        {
            gameScreen = SwinGame.LoadBitmap("starSky.jpg");
        }
        public Bitmap GameScreen { get => gameScreen; }
    }
}
