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

            Screen screen = new Screen();
       
            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();


                screen.ProcessInput();
                if (screen.IsQuit) { break; }
                screen.Update();


                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0, 0);


                //Draw onto the screen
                screen.Draw();

                SwinGame.RefreshScreen(60);

            }


        }
    }
}
