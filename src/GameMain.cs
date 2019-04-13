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
     
            Screen background = new Screen();
       
            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

           

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0, 0);

                //Draw Background
                background.DrawBackground();

                //Draw onto the screen
              
                SwinGame.RefreshScreen(60);

            }
            SwinGame.FreeBitmap(background.GameScreen);

        }
    }
}
