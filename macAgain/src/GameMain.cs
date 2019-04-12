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
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            Shape thing = new Shape("Hello will this work?");
            
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0,0);

                //Draw onto the screen
                SwinGame.DrawText(thing.Thing, Color.Black, 50, 50);
                SwinGame.RefreshScreen(60);

            }
        }
    }
}