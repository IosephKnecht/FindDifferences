using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FindDifferences.Interfaces;
using FindDifferences.Data;

namespace FindDifferences
{
    public partial class ManagerView : Form
    {
        IStrategy strategy;

        public ManagerView()
        {
            InitializeComponent();
            strategy = new ManagerStrategy(this, changedImage);
            strategy.AddComponent += AddComponent;
            changedImage.MouseDown += new MouseEventHandler(strategy.MouseDown);
            changedImage.MouseMove += new MouseEventHandler(strategy.MouseMove);
            changedImage.MouseUp += new MouseEventHandler(strategy.MouseUp);
        }

        private void AddComponent(object label)
        {
            this.changedImage.Controls.Add((Label)label);
        }

        private void ManagerView_Load(object sender, EventArgs e)
        {

        }
    }
}
