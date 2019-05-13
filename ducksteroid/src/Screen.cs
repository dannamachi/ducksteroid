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
    public enum SpawnSide
    {
        Top,
        Right,
        Bottom,
        Left
    }
    public class Screen
    {
        //fields
        private ScreenType _screentype;
        private Drawing _drawing;
        private Drawing _saveddrawing;
        private Ship _ship;
        private List<Duck> _ducks;
        private bool _isdead;
        private Timer _timer;
        private bool _isQuit;
        private DrawPicture _picture;

        //constructors
        public Screen()
        {
            _isQuit = false;
            _screentype = ScreenType.Title;
            InitializeTitle();    
        }

        //properties
        public Bitmap Background { get => _drawing.Background; }
        public bool IsPlaying { get => _screentype == ScreenType.Game; }
        public bool IsDead { get => _isdead; }
        public bool IsQuit { get => _isQuit; set => _isQuit = value; }
        public Bitmap Picture { get => _picture.Image; }
        public bool IsGO { get => _screentype == ScreenType.GOver; }
        public bool IsPaused { get => _screentype == ScreenType.Pause; }
   


        //methods
        public void Draw()
        {
            _drawing.Draw();
        
            if (IsPlaying)
            {
                Text words = new Text(Color.White, "||", SwinGame.LoadFont("Arial", 20));
                words.X = 751;
                words.Y = 13;
                words.Width = 40;
                words.Height = 30;
                words.Draw();
                _drawing.AddShape(words);
                DrawPicture pause = new DrawPicture(SwinGame.LoadBitmap("Pause.png"), 750, 10);
                pause.DrawIt();
               

                Text test = new Text(Color.Red, _ship.CenterCoord, SwinGame.LoadFont("Arial", 20));
                test.X = 500;
                test.Y = 500;
                test.Draw();
                _ship.Draw();
                _ship.Shoot();
                foreach (Duck d in _ducks)
                {
                    d.DrawDuckAnimation();
                }
                if (!IsDead) {
                    _ship.Draw ();
                   
                }
                
                _ship.Shoot ();

            }
            if (IsPaused)
            {
                DrawPicture A = new DrawPicture(SwinGame.LoadBitmap("PauseScreen.png"), 175, 150);
                A.DrawIt();
            }
             
            if (IsGO)
            {
                DrawPicture A = new DrawPicture(SwinGame.LoadBitmap("GOscreen.png"), 100, 100);
                A.DrawIt();
            }
                _timer.LastCalledSec = _timer.TimeInSec;
                _timer.StartTimer ();

                //draw joke every 4s
                if (_timer.TimeInSec % 8 < 5)
                {
                    JokeEngine.DrawJoke();
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
                _isdead = CheckDead ();
                if(!_isdead){
                    _ship.Update ();
                    CheckOutobound ();
                    CheckShooting();

                    //spawn duck every 2s
                    if (_timer.TimeInSec % 2 == 0 && _timer.LastCalledSec != _timer.TimeInSec) { 
                        SpawnDuck();
                    }
                    //spawn joke every 4s
                    if (_timer.TimeInSec % 8 == 5 && _timer.LastCalledSec != _timer.TimeInSec)
                    {
                        JokeEngine.GetJoke();

                    }
                }
                else
                {
                    _screentype = ScreenType.GOver;
                    InitializeGOver();
                }   
            }
        

        }
        private void SpawnDuck()
        {
            Random random = new Random();
            int spawnrand = random.Next(1, 4);
            int R = 29;
            float X = (-1) * 2 * R;
            float Y = X;
            SpawnSide spawnside = SpawnSide.Top;
            switch (spawnrand)
            {
                case 1:
                    spawnside = SpawnSide.Top;
                    X = random.Next(0, 800);
                    Y = (-1) * R;
                    break;
                case 2:
                    spawnside = SpawnSide.Right;
                    Y = random.Next(0, 600);
                    X = 800 + R;
                    break;
                case 3:
                    spawnside = SpawnSide.Bottom;
                    X = random.Next(0, 800);
                    Y = 600 + R;
                    break;
                case 4:
                    spawnside = SpawnSide.Left;
                    Y = random.Next(0, 600);
                    X = (-1) * R;
                    break;
            }
            Duck duckie = new Duck(X, Y, R, spawnside);
            _ducks.Add(duckie);
        }

        //Check everything while playing game
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
        private void CheckOutobound ()
        {
            List<Bullet> removebullet = new List<Bullet> ();
            foreach (Bullet bu in _ship.Bullets) {
                if (!Contain (bu.Position, bu.Radius))
                    removebullet.Add (bu);
            }
            foreach (Bullet bu in removebullet) {
                _ship.Bullets.Remove (bu);
            }

            List<Duck> removeduck = new List<Duck> ();
            foreach (Duck d in _ducks) {
                d.MoveDuck ();
                if (!(d.Exist && Contain (d.Position, d.Radius)))
                    removeduck.Add (d);
            }
            foreach (Duck d in removeduck) {
                _ducks.Remove (d);
            }
        }
        private bool CheckDead ()
        {
            foreach(Duck d in _ducks) {
                foreach(Point2D p in _ship.Positions) {
                    if (d.IsAt(p)){
                        return true;
                    }
                }
            }
            return false;
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

        //Initialize everything while playing game
        private void InitializeGame()
        {

            _timer = new Timer();
            
            Drawing temp = new Drawing(SwinGame.LoadBitmap("starSky.jpg"));

            _drawing = temp;

            _saveddrawing = temp;
            _ship = new Ship(Color.White,400,300, 20);
            _ducks = new List<Duck>();
            _isdead = false;
            

            JokeEngine.LoadJokes();

        }
        private void InitializeTitle()
        {
            Drawing initial = new Drawing(SwinGame.LoadBitmap("StartGame.png"));
            initial.Draw();
            Text play = new Text(Color.Yellow, "Play", SwinGame.LoadFont("Arial", 20));
            Text exit = new Text(Color.Yellow, "Exit", SwinGame.LoadFont("Arial", 20));
            play.X = 340;
            play.Y = 290;
            play.Height = 50;
            play.Width = 170;
            exit.X = 340;
            exit.Y = 380;
            exit.Width = 170;
            exit.Height = 50;
            _drawing = initial;
            _drawing.AddShape(play);
            _drawing.AddShape(exit);
            _drawing.Draw();
            _saveddrawing = null;
            _ship = null;
            _ducks = null;


        }
        private void InitializeGOver()
        {
            Text main = new Text(Color.Yellow, "Main", SwinGame.LoadFont("Arial", 20));
            Text quit = new Text(Color.Yellow, "Quit", SwinGame.LoadFont("Arial", 20));

            main.X = 167;
            main.Y = 290;
            main.Height = 50;
            main.Width = 200;
            quit.X = 430;
            quit.Y = 290;
            quit.Width = 190;
            quit.Height = 50;
            _drawing.AddShape(main);
            _drawing.AddShape(quit);
            _saveddrawing = null;
            _ship = null;
            _ducks = null;

        }
        private void InitializePause()
        {
            Text resume = new Text(Color.Yellow, "Resume", SwinGame.LoadFont("Arial", 20));
            Text main = new Text(Color.Yellow, "Main", SwinGame.LoadFont("Arial", 20));
       
            resume.X = 220;
            resume.Y = 300;
            resume.Height = 50;
            resume.Width = 140;
            main.X = 460;
            main.Y = 300;
            main.Width = 140;
            main.Height = 50;
            Drawing filler = new Drawing();
            _drawing = filler;
            _drawing.AddShape(resume);
            _drawing.AddShape(main);
        }

        //The process of game
        private void ProcessGame()
        {
            Point2D click = new Point2D();
            click.X = SwinGame.MouseX();
            click.Y = SwinGame.MouseY();
            if (!IsDead)
            {
                //need to add condition for when ship is hit/dead
                if (SwinGame.KeyDown(KeyCode.vk_d))
                {
                    _ship.IncreaseAngle();
                }
                if (SwinGame.KeyDown(KeyCode.vk_a))
                {
                    _ship.DecreaseAngle();
                }
                if (SwinGame.KeyDown(KeyCode.vk_w))
                {
                    _ship.MoveUp();
                }
                if (SwinGame.KeyDown(KeyCode.vk_s))
                {
                    _ship.MoveDown();
                }

                _drawing.SelectShapesAt(click);
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    if (_drawing.GetButton("||").IsAt(click))
                    {
                        _saveddrawing = _drawing;
                        _screentype = ScreenType.Pause;
                        InitializePause();
                    }
                    else
                    {
                        _ship.AddBullet();
                    }
                }

            }
        }
        private void ProcessTitle()
        {
            Point2D click = new Point2D();
            click.X = SwinGame.MouseX();
            click.Y = SwinGame.MouseY();
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                _drawing.SelectShapesAt(click);
                if (_drawing.GetButton("Play").Selected)
                {
                    _screentype = ScreenType.Game;
                    InitializeGame();
                }
                else if (_drawing.GetButton("Exit").Selected)
                {
                    _isQuit = true;
                    
                }
            }
        }
        private void ProcessGOver()
        {
            Point2D click = new Point2D();
            click.X = SwinGame.MouseX();
            click.Y = SwinGame.MouseY();
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                _drawing.SelectShapesAt(click);
                if (_drawing.GetButton("Main").Selected)
                {
                    _screentype = ScreenType.Title;
                    InitializeTitle();
                }
                else if (_drawing.GetButton("Quit").Selected)
                {
                    _isQuit = true;
                }
            }
        }
        private void ProcessPause()
        {
            Point2D click = new Point2D();
            click.X = SwinGame.MouseX();
            click.Y = SwinGame.MouseY();
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                _drawing.SelectShapesAt(click);
                if (_drawing.GetButton("Resume").Selected)
                {
                    _drawing = _saveddrawing;
                    _screentype = ScreenType.Game;
                    
                }
                else if (_drawing.GetButton("Main").Selected)
                {
                    _screentype = ScreenType.Title;
                    InitializeTitle();
                }
            }
        }
    }
}
