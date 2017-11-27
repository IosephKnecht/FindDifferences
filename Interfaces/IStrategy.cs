using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindDifferences.Interfaces
{
    interface IStrategy
    {
        /// <summary>
        /// Метод на нажатие по левой клавише...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MouseDown(object sender, System.Windows.Forms.MouseEventArgs e);
        /// <summary>
        /// Метод на перемещение указателя мыши...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MouseMove(object sender, System.Windows.Forms.MouseEventArgs e);
        /// <summary>
        /// Метод на отпускание левой клавиши мыши...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MouseUp(object sender, System.Windows.Forms.MouseEventArgs e);
        /// <summary>
        /// Метод на клик по чекпоинту...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Label_Click(object sender, EventArgs e);
        /// <summary>
        /// Метод на реализацию загрузки изображения...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DragEnter(object sender, System.Windows.Forms.DragEventArgs e);
        /// <summary>
        /// Метод на логику перетаскивания изображения...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DragDrop(object sender, System.Windows.Forms.DragEventArgs e);
        /// <summary>
        /// Событие на добавление компонента в форму...
        /// </summary>
        event Action<object> AddComponent;
        /// <summary>
        /// Костыльный сеттер на обновление ссылки у стратегии...
        /// </summary>
        System.Windows.Forms.PictureBox UpdateLinkChangedImage { set; }
    }
}
