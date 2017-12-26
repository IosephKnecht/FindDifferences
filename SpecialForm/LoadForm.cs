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
        /// <summary>
        /// Экземпляр класса хранящего сцены...
        /// </summary>
        SceneManager s_manager;

        /// <summary>
        /// Делегат ссылающийся на ManagerStrategy...
        /// </summary>
        RecoverScene rec;

        public LoadForm(RecoverScene rec)
        {
            InitializeComponent();

            this.s_manager = SceneManager.Instance();
            this.rec = rec;

            LoadList();
        }

        /// <summary>
        /// Вспомогательный метод добывающий из объекта изображения и транслирующий
        /// их на наши picterBox'ы...
        /// </summary>
        /// <param name="index">Индекс выбранной картинки...</param>
        private void LoadImage(int index)
        {
            SceneInfo inf = (SceneInfo)comboBox1.Items[index];

            Bitmap btm1 = new Bitmap(inf.OriginalImage.FilePath);
            Bitmap btm2 = new Bitmap(inf.ChangedImage.FilePath);

            originalImage.Image = btm1;
            changedImage.Image = btm2;
        }

        /// <summary>
        /// Вспомогательный метод,добавляющий все имена сцен в комбобокс...
        /// </summary>
        private void LoadList()
        {
            foreach (SceneInfo inf in s_manager.Scenes)
            {
                comboBox1.Items.Add(inf);
            }
        }

        /// <summary>
        /// Запускает логику отображения миниатюр на форме...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            LoadImage(cb.SelectedIndex);
        }

        /// <summary>
        /// Подписывается на событие восстановления сцены(в SceneManager)
        /// и запускает LoadScene...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            s_manager.recoverScene += new Action<object, object>(rec);
            s_manager.LoadScene(comboBox1.SelectedIndex);
            s_manager.recoverScene -= new Action<object, object>(rec);
            this.Dispose();
        }
    }
}
