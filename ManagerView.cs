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
            this.Controls.Remove(this.originalImage);
            this.Controls.Remove(this.changedImage);

            this.originalImage = (PictureBox)originalImage;
            this.changedImage = (PictureBox)changedImage;

            //SubscribeImage((PictureBox)originalImage, (PictureBox)changedImage);
            SubscribeCheckPoint(((PictureBox)changedImage).Controls);

            this.Controls.Add((PictureBox)originalImage);
            this.Controls.Add((PictureBox)changedImage);

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
                }
            }
            catch
            {
                MessageBox.Show("Файл сохранений не найден или же он пуст...");
            }
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
        }

        /// <summary>
        /// Реализует логику передачи управления загрузочной форме...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void загрузитьСценуToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SpecialForm.LoadForm lf = new SpecialForm.LoadForm(new RecoverScene(recoverScene));
            lf.ShowDialog();
        }

        /// <summary>
        /// Реализует механизм сериализации класса SceneManager...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
