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
        private double score;

        private Timer timer;

        private int time;

        public event Action timerOff;

        private bool newRecord = false;

        private bool resultSession = false;

        private int point_counter;

        private readonly int cnst;

        public GameController(Tick new_tick)
        {
            timer = new Timer();
            timer.Tick += new EventHandler(new_tick);
            this.time = 60;
            this.cnst = time;
            timer.Interval = 1000;
            point_counter = SceneManager.Instance().getCurrentScene().Point_Count;
            timer.Enabled = true;
        }

        public int getPointCounter { get { return point_counter; } }

        public int getTime
        {
            get
            {
                if (time > 0)
                {
                    return time--;
                }
                else
                {
                    timer.Enabled = false;
                    timerOff();
                    if (point_counter == 0) resultSession = true;
                    return time = 0;
                }
            }
        }

        public void findDifference(int value)
        {
            point_counter--;
            score += value* time/(double)cnst;
            if (point_counter == 0)
            {
                timer.Enabled = false;
                resultSession = true;
                if (score > SceneManager.Instance().getCurrentScene().getBestScore)
                {
                    SceneManager.Instance().getCurrentScene().setBestScore = score;
                    newRecord = true;
                }
                timerOff();
            }
        }

        public double getScore
        {
            get { return score; }
        }

        public bool getResultSession { get { return resultSession; } }

        public bool getNewRecord { get { return newRecord; } }
    }
}
