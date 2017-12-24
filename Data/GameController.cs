using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FindDifferences.Data
{
    delegate void Tick(object sender, EventArgs e);
    /// <summary>
    /// Когда-нибудь он будет управлять процессом игры...
    /// </summary>
    /// 
    class GameController
    {
        private int score;

        private Timer timer;

        private int time;

        public event Action timerOff;

        private int point_counter;

        public GameController(Tick new_tick)
        {
            timer = new Timer();
            timer.Tick += new EventHandler(new_tick);
            this.time = 60;
            timer.Interval = 1000;
            point_counter = SceneManager.Instance().getCurrentScene().Point_Count;
            timer.Enabled = true;
        }

        public int getPointCounter { get { return point_counter; } }

        public int getTime
        {
            get
            {
                time -= 1;
                if (time > 0) return time;
                else
                {
                    timer.Enabled = false;
                    timerOff();
                    return time = 0;
                }
            }
        }

        public void findDifference(int value)
        {
            point_counter--;
            score += value;
            if (point_counter == 0)
            {
                timer.Enabled = false;
                timerOff();
            }
        }

        public int getScore
        {
            get { return score; }
        }
    }
}
