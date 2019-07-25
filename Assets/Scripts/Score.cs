using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class Score
    {
     
        private int highScore;
        private int newScore;

        public int NewScore
        {
            get { return newScore; }
            set { newScore = value; }
        }
   

        public int HighScore
        {
            get { return highScore; }
            set { highScore = value; }
        }

    }
}
