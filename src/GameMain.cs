using System;
using SwinGameSDK;
using MyGame.src;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("DuckSteroids", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            Duck sarah = new Duck(200, 200, 7);
            Ship peter = new Ship(Color.White, 50, 50);
     
            Screen background = new Screen();
       
            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();


                if (SwinGame.KeyDown(KeyCode.vk_RIGHT))
                {
                    peter.X += 1;
                    peter.TriangleShip = SwinGame.CreateTriangle(peter.X, peter.Y, peter.X - 15, peter.Y + 20, peter.X + 15, peter.Y + 20);
                }
                if (SwinGame.KeyDown(KeyCode.vk_LEFT))
                {
                    peter.X -= 1;
                    peter.TriangleShip = SwinGame.CreateTriangle(peter.X, peter.Y, peter.X - 15, peter.Y + 20, peter.X + 15, peter.Y + 20);
                }
                if (SwinGame.KeyDown(KeyCode.vk_UP))
                {
                    peter.Y -= 1;
                    peter.TriangleShip = SwinGame.CreateTriangle(peter.X, peter.Y, peter.X - 15, peter.Y + 20, peter.X + 15, peter.Y + 20);
                }
                if (SwinGame.KeyDown(KeyCode.vk_DOWN))
                {
                    peter.Y += 1;
                    peter.TriangleShip = SwinGame.CreateTriangle(peter.X, peter.Y, peter.X - 15, peter.Y + 20, peter.X + 15, peter.Y + 20);
                }
                if (SwinGame.KeyTyped(KeyCode.vk_SPACE))
                    sarah.FlipDuck();
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                    peter.AddBullet();
                foreach (Bullet bu in peter.Bullets)
                {
                    if (sarah.IsAt(bu.Position))
                    {
                        sarah.Killed();
                    }
                }

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0, 0);

                //Draw Background
                background.DrawBackground();

                //Draw onto the screen

                if (sarah.Exist)
                    sarah.DrawDuckAnimation();
                peter.Draw();
                peter.Shoot();
                SwinGame.RefreshScreen(60);

            }
            SwinGame.FreeBitmap(background.GameScreen);

        }
    }
}
