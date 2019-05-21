using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MyGame
{
    public class Score
    {
        private Counter _value;   
        public int Value { get => _value.Value;}
        
        public Score(int number)
        {
            Counter something = new Counter();
            _value = something;
            for(int i = 0; i < number; i++)
            {
                _value.Increment();
            }
            
        }
    
    }
}
