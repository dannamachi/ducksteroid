using System.Threading;
using SwinGameSDK;

namespace MyGame.src
{
    public class Timer
    {
        private int _lastcalled;
        private Counter _min, _sec, _hr, _tick;
        private Text _text;

        //Constructors
        public Timer ()
        {

            _tick = new Counter ();
            _sec = new Counter ();
            _min = new Counter ();
            _hr = new Counter ();
            Font font = SwinGame.LoadFont("arial.ttf", 20);
            _text = new Text (Color.White, "00:00", font);
            _lastcalled = TimeInSec;
        }

        //Properties
        public int LastCalledSec { get => _lastcalled; set => _lastcalled = value; }
        public int TimeInSec { get { return _min.Value * 60 + _sec.Value; } }
        private Counter Hr { get => _hr; }
        private Counter Min { get => _min; }
        private Counter Sec { get => _sec; }

        //Methods
        public void StartTimer ()
        {
            _text.Draw ();
            Tick ();
            _text.Content = TimeToString ();
        }

        public void Tick ()
        {
            _tick.Increment ();
            if (_tick.Value == 60) {    
                //This aims to make timer sleep exactly 1 second
                _tick.Reset ();
                Sec.Increment ();
            }
            if (Sec.Value == 60) {
                Sec.Reset ();
                Min.Increment ();
            }
            if (Min.Value == 60) {
                Min.Reset ();
                Hr.Increment ();
            }
        }

        public string TimeToString()
        {
            string time = "00:00";
            string second, minute, hour;

            //Logic String
            second = (Sec.Value < 10) ? "0" + Sec.Value.ToString () : Sec.Value.ToString ();
            minute = (Min.Value < 10) ? "0" + Min.Value.ToString () : Min.Value.ToString ();
            hour = (Hr.Value < 10) ? "0" + Hr.Value.ToString () : Hr.Value.ToString ();

            //Merge String
            if (hour == "00") {
                time = minute + ":" + second;
            } else {
                time = hour + ":" + minute + ":" + second;
            }

            return time;
        }
    }
}
