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
using System.IO;

namespace FindDifferences
{
    public partial class ManagerView : Form
    {
        private IStrategy mStrategy;
        private SceneManager sManager;

        public ManagerView()
        {
            InitializeComponent();

            mStrategy = new ManagerStrategy(this, changedImage);
            mStrategy.AddComponent += AddComponent;
            changedImage.MouseDown += new MouseEventHandler(mStrategy.MouseDown);
            changedImage.MouseMove += new MouseEventHandler(mStrategy.MouseMove);
            changedImage.MouseUp += new MouseEventHandler(mStrategy.MouseUp);

            sManager = SceneManager.Instance();
        }

        private void recoverScene(object originalImage, object changedImage)
        {
            this.Controls.Clear();
            this.Controls.Add((PictureBox)originalImage);
            this.Controls.Add((PictureBox)changedImage);
            ((PictureBox)originalImage).BackColor = Color.Black;
        }

        private void AddComponent(object label)
        {
            this.changedImage.Controls.Add((Label)label);
        }

        private void ManagerView_Load(object sender, EventArgs e)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormat =
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            using (Stream fStream = new FileStream("user.dat",
                 FileMode.Open))
            {
                sManager = (SceneManager)binFormat.Deserialize(fStream);
            }
        }

        private void сохранитьСценуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sManager.SaveScene(originalImage, changedImage);

            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormat =
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (Stream fStream = new FileStream("user.dat",
                 FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, sManager);
            }
        }

        private void загрузитьСценуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sManager.recoverScene += recoverScene;
            sManager.LoadScene(0);
        }
    }
}
