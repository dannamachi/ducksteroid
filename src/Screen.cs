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
            _screentype = ScreenType.Game;
            InitializeGame();
        }
        //properties
        public Bitmap Background { get => _drawing.Background; }
        public bool IsPlaying { get => _screentype == ScreenType.Game; }
        //methods
        public void Draw()
        {
            _drawing.Draw();
            if (IsPlaying)
            {
                _ship.Draw();
                _ship.Shoot();
                foreach (Duck d in _ducks)
                {
                    d.DrawDuckAnimation();
                }
            }
        }
        public void ProcessInput()
        {
            switch (_screentype)
            {
                case ScreenType.Game:
                    ProcessGame();
                    break;
                case ScreenType.Title:
                    ProcessTitle();
                    break;
                case ScreenType.GOver:
                    ProcessGOver();
                    break;
                case ScreenType.Pause:
                    ProcessPause();
                    break;
            }
        }
        private void InitializeGame()
        {
            Drawing temp = new Drawing(SwinGame.LoadBitmap("starSky.jpg"));
            _drawing = temp;
            _saveddrawing = temp;
            _ship = new Ship();
            _ducks = new List<Duck>();

            _ducks.Add(new Duck(100, 100, 50));
        }
        private void InitializeTitle()
        {
            _drawing = new Drawing(SwinGame.LoadBitmap("StartGame.png"));
            _saveddrawing = null;
            _ship = null;
            _ducks = null;
        }
        private void InitializeGOver()
        {

        }
        private void InitializePause()
        {

        }
        private void ProcessGame()
        {
            //need to add condition for when ship is hit/dead
            if (SwinGame.KeyDown(KeyCode.vk_RIGHT))
            {
                _ship.X += 1;
                _ship.TriangleShip = SwinGame.CreateTriangle(_ship.X, _ship.Y, _ship.X - 15, _ship.Y + 20, _ship.X + 15, _ship.Y + 20);
            }
            if (SwinGame.KeyDown(KeyCode.vk_LEFT))
            {
                _ship.X -= 1;
                _ship.TriangleShip = SwinGame.CreateTriangle(_ship.X, _ship.Y, _ship.X - 15, _ship.Y + 20, _ship.X + 15, _ship.Y + 20);
            }
            if (SwinGame.KeyDown(KeyCode.vk_UP))
            {
                _ship.Y -= 1;
                _ship.TriangleShip = SwinGame.CreateTriangle(_ship.X, _ship.Y, _ship.X - 15, _ship.Y + 20, _ship.X + 15, _ship.Y + 20);
            }
            if (SwinGame.KeyDown(KeyCode.vk_DOWN))
            {
                _ship.Y += 1;
                _ship.TriangleShip = SwinGame.CreateTriangle(_ship.X, _ship.Y, _ship.X - 15, _ship.Y + 20, _ship.X + 15, _ship.Y + 20);
            }
            if (SwinGame.MouseClicked(MouseButton.LeftButton)) { _ship.AddBullet(); }
        }
        private void ProcessTitle()
        {

        }
        private void ProcessGOver()
        {

        }
        private void ProcessPause()
        {

        }
    }
}
