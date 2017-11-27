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
        /// <summary>
        /// Делегат ссылающийся на логику добавления чекпоинта в классе ManagerStrategy...
        /// </summary>
        AddLabelDelegate addLabel;

        /// <summary>
        /// Примитив прямоугольника...
        /// </summary>
        Rectangle rect;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addLabel">Экземпляр делегата AddLabelDelegate... </param>
        /// <param name="rect">Примитив прямоугольника...</param>
        public AddCheckPointForm(AddLabelDelegate addLabel, Rectangle rect)
        {
            InitializeComponent();

            this.addLabel = addLabel;
            this.rect = rect;
        }

        private void AddCheckPointForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Кнопка "Да", по клику передает управление в ManagerStartegy...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            addLabel(rect);

            this.Dispose();
        }

        /// <summary>
        /// Кнопка "Нет", разрушает форму...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
