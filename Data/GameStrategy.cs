using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FindDifferences.Interfaces;
using System.Threading;


namespace FindDifferences.Data
{
    class GameStrategy : IStrategy
    {

        private System.Windows.Forms.PictureBox changedImage;

        private GameController gameController;

        public GameStrategy(System.Windows.Forms.PictureBox changedImage)
        {
            this.changedImage = changedImage;
        }

        public GameController setGameController { set { this.gameController = value; } }

        /// <summary>
        /// Костыль на обновление ссылки на changedImage...
        /// </summary>
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

        /// <summary>
        /// Реализация логики нажатия на чекпоинт игроком(проигрывание звучка,смена цвета,
        /// удаление из Control'a компонента)...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Label_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            Thread thread = new Thread(PlaySound);
            thread.Start();

            label.ForeColor = System.Drawing.Color.Red;
            label.BorderStyle = BorderStyle.FixedSingle;
            //label.Dock = DockStyle.Fill;

            changedImage.BorderStyle = BorderStyle.None;
            changedImage.Dock = DockStyle.None;

            label.Click -= Label_Click;
            //System.Windows.Forms.MessageBox.Show("BRB");
            //changedImage.Controls.Remove((System.Windows.Forms.Label)sender);
            gameController.findDifference((int)label.Tag);

        }

        private void PlaySound()
        {
            System.Windows.Media.MediaPlayer player = new System.Windows.Media.MediaPlayer();
            player.Open(new Uri(Directory.GetCurrentDirectory() + @"/Sounds" + @"/Click.wav"));
            player.Play();
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
