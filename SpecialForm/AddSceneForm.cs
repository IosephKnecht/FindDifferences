using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FindDifferences.SpecialForm
{
    public partial class AddSceneForm : Form
    {
        private int timeValue = -1;

        public AddSceneForm()
        {
            InitializeComponent();
        }

        public int getTimeValue { get { return timeValue; } }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сцена не сохранена");
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = 0;
            int.TryParse(textBox1.Text, out value);

            if (value > 0)
            {
                timeValue = value;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Некорректное значение времени");
            }
        }
    }
}
