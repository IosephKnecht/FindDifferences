using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FindDifferences.Interfaces;


namespace FindDifferences.Data
{
    class GameStrategy : IStrategy
    {

        private System.Windows.Forms.PictureBox changedImage;

        public GameStrategy(System.Windows.Forms.PictureBox changedImage)
        {
            this.changedImage = changedImage;
        }

        public PictureBox UpdateLinkChangedImage { set { this.changedImage = value; } }

        public event Action<object> AddComponent;

        public void DragDrop(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void DragEnter(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Label_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            System.Windows.Media.MediaPlayer player = new System.Windows.Media.MediaPlayer();

            player.Open(new Uri(Directory.GetCurrentDirectory() + @"/Sounds" + @"/Click.wav"));
            player.Play();

            label.BackColor = System.Drawing.Color.Green;
            System.Windows.Forms.MessageBox.Show("BRB");
            changedImage.Controls.Remove((System.Windows.Forms.Label)sender);

            player.Close();
        }

        public void MouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void MouseMove(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void MouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
