using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FindDifferences.Interfaces;
using System.Drawing;
using System.Windows.Forms;

namespace FindDifferences.Data
{
    public delegate void AddLabelDelegate(Rectangle rect,int value);

    /// <summary>
    /// Вариант стратегии для менеджера...
    /// </summary>
    class ManagerStrategy : IStrategy
    {
        /// <summary>
        /// Начальное положение нашего курсора...
        /// </summary>
        private Point start = Point.Empty;
        /// <summary>
        /// Конечное положение нашего курсора...
        /// </summary>
        private Point end = Point.Empty;

        /// <summary>
        /// Скажем нет инкапсуляции...
        /// </summary>
        private System.Windows.Forms.Form view;
        /// <summary>
        /// И еще раз нет инкапсуляции...
        /// </summary>
        private System.Windows.Forms.PictureBox changedImage;


        public ManagerStrategy(System.Windows.Forms.Form view,
            System.Windows.Forms.PictureBox changedImage)
        {
            this.view = view;
            this.changedImage = changedImage;
        }

        /// <summary>
        /// Костыль на обновление ссылки на changedImage...
        /// </summary>
        public PictureBox UpdateLinkChangedImage { set { this.changedImage = value; } }

        /// <summary>
        /// Событие на добавление компонента в форму...
        /// </summary>
        public event Action<object> AddComponent;

        /// <summary>
        /// Метод фиксирующий начальное положение нашего курсора...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & System.Windows.Forms.MouseButtons.Left) != 0)
            {
                start.X = e.X;
                start.Y = e.Y;
            }
        }

        /// <summary>
        /// Метод перестраивающий конечную точку нашего курсора по его перетаскиванию...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Point p1;
            Point p2;

            if (((e.Button & System.Windows.Forms.MouseButtons.Left) != 0) && (start != Point.Empty))
            {
                using (Graphics g = view.CreateGraphics())
                {
                    p1 = ((System.Windows.Forms.Control)changedImage).PointToScreen(start);

                    if (end != Point.Empty)
                    {
                        p2 = ((System.Windows.Forms.Control)changedImage).PointToScreen(end);
                        System.Windows.Forms.ControlPaint.DrawReversibleFrame(getRectangleForPoints(p1, p2), Color.Black, System.Windows.Forms.FrameStyle.Dashed);
                    }

                    end.X = e.X;
                    end.Y = e.Y;

                    p2 = ((System.Windows.Forms.Control)changedImage).PointToScreen(end);
                    System.Windows.Forms.ControlPaint.DrawReversibleFrame(getRectangleForPoints(p1, p2), Color.Black, System.Windows.Forms.FrameStyle.Dashed);
                }
            }
        }

        /// <summary>
        /// При отпускании клавиши,если есть команда AddCheckPointForm строим
        /// Rectangle и рисуем по нему DrawReversibleFrame...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Point p1;
            Point p2;

            Rectangle rect;

            if ((end != Point.Empty) && (start != Point.Empty))
            {
                using (Graphics g = view.CreateGraphics())
                {
                    p1 = ((System.Windows.Forms.Control)changedImage).PointToScreen(start);
                    p2 = ((System.Windows.Forms.Control)changedImage).PointToScreen(end);
                    rect = getRectangleForPoints(start, end);
                    System.Windows.Forms.ControlPaint.DrawReversibleFrame(getRectangleForPoints(p1, p2), Color.Black, System.Windows.Forms.FrameStyle.Dashed);
                }

                FindDifferences.SpecialForm.AddCheckPointForm addForm = new SpecialForm.AddCheckPointForm(new AddLabelDelegate(AddLabel), rect);
                addForm.StartPosition = FormStartPosition.CenterScreen;
                addForm.ShowDialog();
            }

            start = Point.Empty;
            end = Point.Empty;
        }

        /// <summary>
        /// Метод реализующий добавление построенного чекпоинта...
        /// </summary>
        /// <param name="rect"></param>
        private void AddLabel(Rectangle rect,int value)
        {
            Label label = new Label();

            label.Parent = changedImage;
            label.BackColor = Color.Transparent;

            label.Location = rect.Location;
            label.Size = rect.Size;

            label.Click += Label_Click;
            label.Tag = value;

            AddComponent(label);
        }

        public void Label_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("BRB");
        }

        /// <summary>
        /// Хитрый мат.метод по расчету характеристик Rectangle...
        /// </summary>
        /// <param name="beginPoint"></param>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        private Rectangle getRectangleForPoints(Point beginPoint, Point endPoint)
        {
            int top = beginPoint.Y < endPoint.Y ? beginPoint.Y : endPoint.Y;
            int bottom = beginPoint.Y > endPoint.Y ? beginPoint.Y : endPoint.Y;
            int left = beginPoint.X < endPoint.X ? beginPoint.X : endPoint.X;
            int right = beginPoint.X > endPoint.X ? beginPoint.X : endPoint.X;

            Rectangle rect = new Rectangle(left, top, (right - left), (bottom - top));
            return rect;
        }

        /// <summary>
        /// По фокусе реализует соответствующую стратегию взаимодействия с объектом(картинкой)...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// Если мы навели на pictureBox картинку и отпустили,то мы идем загружать ее
        /// в наш pictureBox...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            System.Drawing.Bitmap btm = new System.Drawing.Bitmap(files[0]);
            pb.Image = btm;
            pb.ImageLocation = files[0];
        }
    }
}
