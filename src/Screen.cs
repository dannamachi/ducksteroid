using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame.src
{
    public enum ScreenType
    {
        Game,
        Title,
        GOver,
        Pause
    }
    public class Screen
    {
        //fields
        private ScreenType _screentype;
        private Drawing _drawing;
        private Drawing _saveddrawing;
        private Ship _ship;
        private List<Duck> _ducks;

        //constructors
        public Screen()
        {
            _screentype = ScreenType.Title;
            _drawing = new Drawing(SwinGame.LoadBitmap("starSky.jpg"));
            _saveddrawing = null;
            _ship = null;
            _ducks = null;
        }
        //properties
        public Bitmap Background { get => _drawing.Background; }
        public bool IsPlaying { get => _screentype == ScreenType.Game; }
        //methods
        public void Draw()
        {

        }
        public void InitializeGame()
        {

        }
        public void InitializeTitle()
        {

        }
        public void InitializeGOver()
        {

        }
        public void InitializePause()
        {

        }
        public void ProcessInput()
        {

        }
        public void ProcessGame()
        {

        }
        public void ProcessTitle()
        {

        }
        public void ProcessGOver()
        {

        }
        public void ProcessPause()
        {

        }
    }
}
