using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FindDifferences.Data;

namespace FindDifferences.SpecialForm
{
    public partial class AddCheckPointForm : Form
    {

        AddLabelDelegate addLabel;

        Rectangle rect;

        public AddCheckPointForm(AddLabelDelegate addLabel, Rectangle rect)
        {
            InitializeComponent();

            this.addLabel = addLabel;
            this.rect = rect;
        }

        private void AddCheckPointForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addLabel(rect);

            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
