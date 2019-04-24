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
        public void Update()
        {
            if (IsPlaying)
            {
                List<Bullet> removebullet = new List<Bullet>();
                foreach (Bullet bu in _ship.Bullets)
                {
                    if (!Contain(bu.Position, bu.Radius))
                        removebullet.Add(bu);
                }
                foreach (Bullet bu in removebullet)
                {
                    _ship.Bullets.Remove(bu);
                }

                List<Duck> removeduck = new List<Duck>();
                foreach (Duck d in _ducks)
                {
                    d.MoveDuck();
                    if (!(d.Exist && Contain(d.Position, d.Radius)))
                        removeduck.Add(d);
                }
                foreach (Duck d in removeduck)
                {
                    _ducks.Remove(d);
                }

                CheckShooting();
            }
        }
        private void SpawnDuck()
        {
            Random random = new Random();
            int spawnrand = random.Next(1, 4);
            int R = random.Next(10, 30);
            float X = (-1) * 2 * R;
            float Y = X;
            switch (spawnrand)
            {
                case 1:
                    X = random.Next(0, 800);
                    Y = (-1) * R;
                    break;
                case 2:
                    Y = random.Next(0, 600);
                    X = 800 + R;
                    break;
                case 3:
                    X = random.Next(0, 800);
                    Y = 600 + R;
                    break;
                case 4:
                    Y = random.Next(0, 600);
                    X = (-1) * R;
                    break;
            }
            Duck duckie = new Duck(X, Y, R);
            _ducks.Add(duckie);
        }
        private void CheckShooting()
        {
            List<Bullet> removebullet = new List<Bullet>();
            foreach (Bullet bu in _ship.Bullets)
            {
                foreach (Duck d in _ducks)
                {
                    if (d.IsAt(bu.Position))
                    {
                        d.Killed();
                        removebullet.Add(bu);
                    }
                }
            }
            foreach (Bullet bu in removebullet)
            {
                _ship.Bullets.Remove(bu);
            }
        }
        private bool Contain(Point2D pt, int rad)
        {
            float X = pt.X;
            float Y = pt.Y;
            float R = rad;

            if (X + 2*R < 0 || Y + 2*R < 0)
                return false;
            if (X - 2*R > 800 || Y - 2*R > 600)
                return false;
            return true;
        }
        private void InitializeGame()
        {
            Drawing temp = new Drawing(SwinGame.LoadBitmap("starSky.jpg"));
            _drawing = temp;
            _saveddrawing = temp;
            _ship = new Ship(Color.White,400,300);
            _ducks = new List<Duck>();
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
                Point2D shipcenter = _ship.TriangleShip.Barycenter();
                shipcenter.X += 1;
                if (Contain(shipcenter, 7))
                    _ship.X += 1;
                _ship.TriangleShip = SwinGame.CreateTriangle(_ship.X, _ship.Y, _ship.X - 15, _ship.Y + 20, _ship.X + 15, _ship.Y + 20);
            }
            if (SwinGame.KeyDown(KeyCode.vk_LEFT))
            {
                Point2D shipcenter = _ship.TriangleShip.Barycenter();
                shipcenter.X -= 1;
                if (Contain(shipcenter, 7))
                    _ship.X -= 1;
                _ship.TriangleShip = SwinGame.CreateTriangle(_ship.X, _ship.Y, _ship.X - 15, _ship.Y + 20, _ship.X + 15, _ship.Y + 20);
            }
            if (SwinGame.KeyDown(KeyCode.vk_UP))
            {
                Point2D shipcenter = _ship.TriangleShip.Barycenter();
                shipcenter.Y -= 1;
                if (Contain(shipcenter, 7))
                    _ship.Y -= 1;
                _ship.TriangleShip = SwinGame.CreateTriangle(_ship.X, _ship.Y, _ship.X - 15, _ship.Y + 20, _ship.X + 15, _ship.Y + 20);
            }
            if (SwinGame.KeyDown(KeyCode.vk_DOWN))
            {
                Point2D shipcenter = _ship.TriangleShip.Barycenter();
                shipcenter.Y += 1;
                if (Contain(shipcenter, 7))
                    _ship.Y += 1;
                _ship.TriangleShip = SwinGame.CreateTriangle(_ship.X, _ship.Y, _ship.X - 15, _ship.Y + 20, _ship.X + 15, _ship.Y + 20);
            }
            if (SwinGame.MouseClicked(MouseButton.LeftButton)) { _ship.AddBullet(); }

            if (SwinGame.KeyTyped(KeyCode.vk_SPACE)) { SpawnDuck(); }
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
