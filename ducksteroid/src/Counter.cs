using System;
namespace MyGame
{
    public class Counter
    {
        //Field
        private int _value;

        //Constructor
        public Counter ()
        {
            _value = 0;
        }

        //Property
        public int Value { get => _value; }

        //Method
        public void Increment () => _value++;
        public void Reset () => _value = 0;
    }
}
