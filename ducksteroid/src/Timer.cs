using System.Threading;
using SwinGameSDK;

namespace MyGame.src
{
    public class Timer
    {
        private int _lastcalled;
        private int _min, _sec, _tick;
        private Text t;

        //Constructors
        public Timer ()
        {
            _min = 2;
            _sec = 30;
            _tick = 58;
            Font font = SwinGame.LoadFont("Arial", 20);
            t = new Text (Color.White, "02:30", font);
            _lastcalled = TimeInSec;
        }

        //Properties
        public int LastCalledSec { get => _lastcalled; set => _lastcalled = value; }
        public int TimeInSec { get { return _min * 60 + _sec; } }
        public int Min { get => _min; }
        public int Sec { get => _sec; }

        //Methods
        public void StartTimer ()
        {
            t.Draw ();

            //Timer Logic
            if(_sec == 0 && _min == 0 && _tick == 1) {
                _min = _sec = _tick = 0;
            } else {
                _tick--;
                if (_tick == 0) {
                    _sec--;
                    _tick = 58;
                }
                if (_sec == 0 && _min != 0) {
                    _min--;
                    _sec = 60;
                }
            }

            //Format String of Timer
            if(_sec < 10) {
                t.Content = string.Format ("0{0}:0{1}", _min, _sec);
            } else {
                t.Content = string.Format ("0{0}:{1}", _min, _sec);
            }
            
        }
    }
}
