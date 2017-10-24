using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FindDifferences.Interfaces;
using FindDifferences.Data;

namespace FindDifferences
{
    public partial class ManagerView : Form
    {
        private IStrategy strategy;
        private SceneManager sManager;

        public ManagerView()
        {
            InitializeComponent();

            originalImage.AllowDrop = true;
            changedImage.AllowDrop = true;

            strategy = new ManagerStrategy(this, changedImage);
            strategy.AddComponent += AddComponent;
            changedImage.MouseDown += new MouseEventHandler(strategy.MouseDown);
            changedImage.MouseMove += new MouseEventHandler(strategy.MouseMove);
            changedImage.MouseUp += new MouseEventHandler(strategy.MouseUp);

            originalImage.DragEnter += new DragEventHandler(strategy.DragEnter);
            originalImage.DragDrop += new DragEventHandler(strategy.DragDrop);

            changedImage.DragEnter += new DragEventHandler(strategy.DragEnter);
            changedImage.DragDrop += new DragEventHandler(strategy.DragDrop);

            sManager = SceneManager.Instance();
        }

        private void recoverScene(object originalImage, object changedImage)
        {
            this.Controls.Remove(this.originalImage);
            this.Controls.Remove(this.changedImage);

            this.originalImage = (PictureBox)originalImage;
            this.changedImage = (PictureBox)changedImage;

            SubscribeImage((PictureBox)originalImage, (PictureBox)changedImage);
            SubscribeCheckPoint(((PictureBox)changedImage).Controls);

            this.Controls.Add((PictureBox)originalImage);
            this.Controls.Add((PictureBox)changedImage);
        }

        private void AddComponent(object label)
        {
            this.changedImage.Controls.Add((Label)label);
        }

        private void ManagerView_Load(object sender, EventArgs e)
        {
            //System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormat =
            //    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            //using (Stream fStream = new FileStream("user.dat",
            //     FileMode.Open))
            //{
            //    sManager = (SceneManager)binFormat.Deserialize(fStream);
            //}
        }

        private void новаяСценаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SubscribeImage(PictureBox originalImage, PictureBox changedImage)
        {
            changedImage.MouseDown += new MouseEventHandler(strategy.MouseDown);
            changedImage.MouseMove += new MouseEventHandler(strategy.MouseMove);
            changedImage.MouseUp += new MouseEventHandler(strategy.MouseUp);

            originalImage.DragEnter += new DragEventHandler(strategy.DragEnter);
            originalImage.DragDrop += new DragEventHandler(strategy.DragDrop);

            changedImage.DragEnter += new DragEventHandler(strategy.DragEnter);
            changedImage.DragDrop += new DragEventHandler(strategy.DragDrop);
        }

        private void SubscribeCheckPoint(Control.ControlCollection Controls)
        {
            foreach (Label label in Controls)
            {
                label.Click += new EventHandler(strategy.Label_Click);
            }
        }

        private void режимИгрыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            strategy = new GameStrategy(changedImage);
            SubscribeCheckPoint(changedImage.Controls);

            сохранитьСценуToolStripMenuItem.Enabled = false;
            режимИгрыToolStripMenuItem.Enabled = false;

            режимМенеджераToolStripMenuItem.Enabled = true;
        }

        private void режимМенеджераToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            сохранитьСценуToolStripMenuItem.Enabled = true;
            режимИгрыToolStripMenuItem.Enabled = true;

            режимМенеджераToolStripMenuItem.Enabled = false;
        }

        private void загрузитьСценуToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            sManager.recoverScene += recoverScene;
            sManager.LoadScene(0);
        }

        private void сохранитьСценуToolStripMenuItem_Click_1(object sender, EventArgs e)
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
    }
}
