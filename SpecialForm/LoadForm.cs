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
    public partial class LoadForm : Form
    {
        SceneManager s_manager;
        RecoverScene rec;

        public LoadForm(RecoverScene rec)
        {
            InitializeComponent();

            this.s_manager = SceneManager.Instance();
            this.rec = rec;

            LoadList();
        }

        private void LoadImage(int index)
        {
            SceneInfo inf = (SceneInfo)comboBox1.Items[index];

            Bitmap btm1 = new Bitmap(inf.OriginalImage.FilePath);
            Bitmap btm2 = new Bitmap(inf.ChangedImage.FilePath);

            originalImage.Image = btm1;
            changedImage.Image = btm2;
        }

        private void LoadList()
        {
            foreach (SceneInfo inf in s_manager.Scenes)
            {
                comboBox1.Items.Add(inf);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            LoadImage(cb.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s_manager.recoverScene += new Action<object, object>(rec);
            s_manager.LoadScene(comboBox1.SelectedIndex);

            this.Dispose();
        }
    }
}
