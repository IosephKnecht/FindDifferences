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
    public delegate void RecoverScene(object originalImage, object changedImage); 

    /// <summary>
    /// Главная форма приложения...
    /// </summary>
    public partial class ManagerView : Form
    {
        /// <summary>
        /// Экземпляр класса стратегия...
        /// </summary>
        private IStrategy strategy;
        /// <summary>
        /// Экземпляр класса менеджера сцен...
        /// </summary>
        private SceneManager sManager;

        private GameController gameController;

        private string nameForm;

        public ManagerView()
        {
            InitializeComponent();

            sManager = SceneManager.Instance();

            //Запускаем режим игры...
            режимИгрыToolStripMenuItem_Click_1(this.menuStrip1, new EventArgs());
        }

        /// <summary>
        /// Реализация события с класса SceneManager...
        /// Удаляет старые компоненты,подписывает новые компоненты и добавляет
        /// их в нужные Conrols...
        /// </summary>
        /// <param name="originalImage">Восстановленное ориганильное изображение...</param>
        /// <param name="changedImage">Востанновленное изменное изображение...</param>
        private void recoverScene(object originalImage, object changedImage)
        {
            this.originalImage.Controls.Clear();
            this.changedImage.Controls.Clear();

            this.Controls.Remove(this.originalImage);
            this.Controls.Remove(this.changedImage);

            this.originalImage = (PictureBox)originalImage;
            this.changedImage = (PictureBox)changedImage;

            //SubscribeImage((PictureBox)originalImage, (PictureBox)changedImage);
            SubscribeCheckPoint(((PictureBox)changedImage).Controls);

            this.Controls.Add((PictureBox)originalImage);
            this.Controls.Add((PictureBox)changedImage);

            SizeChanged(originalImage, null);

            strategy.UpdateLinkChangedImage = this.changedImage;
        }

        private void AddComponent(object label)
        {
            this.changedImage.Controls.Add((Label)label);
        }

        /// <summary>
        /// Десериализуем класс SceneManager,чтобы получить
        /// сохранненные сцены...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManagerView_Load(object sender, EventArgs e)
        {
            try
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormat =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                using (Stream fStream = new FileStream("user.dat",
                     FileMode.Open))
                {
                    sManager = (SceneManager)binFormat.Deserialize(fStream);
                    SceneManager.SM(sManager);
                    fStream.Close();
                }
            }
            catch
            {
                MessageBox.Show("Файл сохранений не найден или же он пуст...");
            }

            nameForm = this.Text;
        }

        private void новаяСценаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Вспомогательный метод подписывающий изображения на события стратегии...
        /// </summary>
        /// <param name="originalImage">Оригинальное изображение...</param>
        /// <param name="changedImage">Изменненое изображение...</param>
        private void SubscribeImage(PictureBox originalImage, PictureBox changedImage)
        {
            strategy.AddComponent += AddComponent;

            changedImage.MouseDown += new MouseEventHandler(strategy.MouseDown);
            changedImage.MouseMove += new MouseEventHandler(strategy.MouseMove);
            changedImage.MouseUp += new MouseEventHandler(strategy.MouseUp);

            originalImage.DragEnter += new DragEventHandler(strategy.DragEnter);
            originalImage.DragDrop += new DragEventHandler(strategy.DragDrop);

            changedImage.DragEnter += new DragEventHandler(strategy.DragEnter);
            changedImage.DragDrop += new DragEventHandler(strategy.DragDrop);
        }

        /// <summary>
        /// Вспомогательный метод по подписки чекпоинтов на событие стратегии...
        /// </summary>
        /// <param name="Controls">Коллекция чекпоинтов компонента...</param>
        private void SubscribeCheckPoint(Control.ControlCollection Controls)
        {
            foreach (Label label in Controls)
            {
                label.Click += new EventHandler(strategy.Label_Click);
            }
        }

        /// <summary>
        /// Запуск логики переопределения стратегии...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void режимИгрыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            strategy = new GameStrategy(changedImage);

            SubscribeCheckPoint(changedImage.Controls);

            сохранитьСценуToolStripMenuItem.Enabled = false;
            режимИгрыToolStripMenuItem.Enabled = false;

            режимМенеджераToolStripMenuItem.Enabled = true;

            originalImage.AllowDrop = false;
            changedImage.AllowDrop = false;

            originalImage.Enabled = false;
            changedImage.Enabled = false;

            стартToolStripMenuItem.Enabled = true;

            changedImage.Visible = false;

            originalImage.Image = null;
            changedImage.Image = null;

            changedImage.Controls.Clear();

            загрузитьСценуToolStripMenuItem.Enabled = true;

            this.Activated += this.ManagerView_Activated;
            this.Deactivate += this.ManagerView_Deactivate;
        }

        /// <summary>
        /// Запуск логики переопределения стратегии...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void режимМенеджераToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            strategy = new ManagerStrategy(this, changedImage);

            SubscribeImage(this.originalImage, this.changedImage);

            сохранитьСценуToolStripMenuItem.Enabled = true;
            режимИгрыToolStripMenuItem.Enabled = true;

            режимМенеджераToolStripMenuItem.Enabled = false;

            originalImage.AllowDrop = true;
            changedImage.AllowDrop = true;

            originalImage.Enabled = true;
            changedImage.Enabled = true;

            originalImage.Image = null;
            changedImage.Image = null;

            changedImage.Controls.Clear();

            стартToolStripMenuItem.Enabled = false;

            загрузитьСценуToolStripMenuItem.Enabled = false;

            changedImage.Visible = true;

            this.Activated -= this.ManagerView_Activated;
            this.Deactivate -= this.ManagerView_Deactivate;
        }

        /// <summary>
        /// Реализует логику передачи управления загрузочной форме...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void загрузитьСценуToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SpecialForm.LoadForm lf = new SpecialForm.LoadForm(new RecoverScene(recoverScene));
            lf.StartPosition = FormStartPosition.CenterScreen;
            lf.ShowDialog();
            lf.Dispose();

            MessageBox.Show("Сцена успешно загружена...");

            originalImage.Enabled = false;
            changedImage.Enabled = false;

            changedImage.Visible = false;
        }

        /// <summary>
        /// Реализует механизм сериализации класса SceneManager...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьСценуToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FindDifferences.SpecialForm.AddSceneForm addSceneForm = new SpecialForm.AddSceneForm();
            addSceneForm.StartPosition = FormStartPosition.CenterScreen;
            addSceneForm.ShowDialog();

            if (addSceneForm != null)
            {
                if (changedImage.Controls.Count != 0)
                {
                    sManager.SaveScene(originalImage, changedImage, addSceneForm.getTimeValue);

                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormat =
                        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    using (Stream fStream = new FileStream("user.dat",
                         FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        lock (sManager)
                        {
                            binFormat.Serialize(fStream, sManager);
                        }
                        fStream.Close();
                    }

                    originalImage.Image = null;
                    changedImage.Image = null;
                    changedImage.Controls.Clear();
                }
            }
            else
            {
                MessageBox.Show("Вы не отметили ни одного чекпоинта...");
            }
        }

        private void updateRecord()
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormat =
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (Stream fStream = new FileStream("user.dat",
                 FileMode.Create, FileAccess.Write, FileShare.None))
            {
                lock (SceneManager.Instance())
                {
                    binFormat.Serialize(fStream, SceneManager.Instance());
                }
            }
        }

        private void Tick(object sender,EventArgs e)
        {
            this.Text = nameForm +" Осталось времени:"+
                gameController.getTime+ " Осталось найти различий: "+ gameController.getPointCounter
                + " Счет: "+ gameController.getScore +" Рекорд: "+ SceneManager.Instance().getCurrentScene().getBestScore;
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameController = new GameController(this.Tick);
        }

        private void стартToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (SceneManager.Instance().Current_Scene >= 0&&
                originalImage.Image!=null&&changedImage.Image!=null)
            {
                changedImage.Visible = true;

                gameController = new GameController(this.Tick);
                gameController.timerOff += GameController_timerOff;

                ((GameStrategy)strategy).setGameController = gameController;

                стартToolStripMenuItem.Enabled = false;

                originalImage.Enabled = true;
                changedImage.Enabled = true;

                menuStrip1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Сцена не загружена");
            }
        }

        private void GameController_timerOff()
        {
            this.Text = nameForm + " Осталось времени:" +
                gameController.getTime + " Осталось найти различий: " + 0
                + " Счет: " + gameController.getScore + " Рекорд: " + SceneManager.Instance().getCurrentScene().getBestScore;

            стартToolStripMenuItem.Enabled = true;
            if(gameController.getNewRecord&&gameController.getResultSession)
            {
                MessageBox.Show("Аве,чемпиону! Ты установил новый рекорд: " +
                    gameController.getScore);
                Invoke(new Action(updateRecord));
            }
            else
            {
                if (gameController.getResultSession)
                    MessageBox.Show("Аве,победителю!");
                else
                {
                    MessageBox.Show("Возможно,для Вас это пока слишком сложная игра.");
                }
            }

            menuStrip1.Enabled = true;

            originalImage.Image = null;
            changedImage.Image = null;

            changedImage.Controls.Clear();
        }

        private void ManagerView_Activated(object sender, EventArgs e)
        {
            originalImage.Visible = true;
            changedImage.Visible = true;
        }

        private void ManagerView_Deactivate(object sender, EventArgs e)
        {
            originalImage.Visible = false;
            changedImage.Visible = false;
        }

        private void SizeChanged(object sender,EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            int x = pictureBox.Location.X;
            x += pictureBox.Size.Width + 10;
            int y = originalImage.Location.Y;
            changedImage.Location = new Point(x, y);
            this.Size = new Size(2*pictureBox.Width+50, pictureBox.Height+100);
        }
    }
}
