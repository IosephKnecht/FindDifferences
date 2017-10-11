﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FindDifferences.Interfaces;
using System.Drawing;

namespace FindDifferences.Data
{
    class ManagerStrategy : IStrategy
    {
        private Point start = Point.Empty;
        private Point end = Point.Empty;

        private System.Windows.Forms.Form view;
        private System.Windows.Forms.PictureBox changedImage;

        public ManagerStrategy(System.Windows.Forms.Form view,
            System.Windows.Forms.PictureBox changedImage)
        {
            this.view = view;
            this.changedImage = changedImage;
        }

        public event Action<object> AddComponent;

        public void MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & System.Windows.Forms.MouseButtons.Left) != 0)
            {
                start.X = e.X;
                start.Y = e.Y;
            }
        }


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

                System.Windows.Forms.Label label = new System.Windows.Forms.Label();

                label.Parent = changedImage;
                label.BackColor = Color.Black;

                label.Location = rect.Location;
                label.Size = rect.Size;

                label.Click += Label_Click;

                AddComponent(label);
            }

            start = Point.Empty;
            end = Point.Empty;
        }

        public void Label_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("BRB");
        }

        private Rectangle getRectangleForPoints(Point beginPoint, Point endPoint)
        {
            int top = beginPoint.Y < endPoint.Y ? beginPoint.Y : endPoint.Y;
            int bottom = beginPoint.Y > endPoint.Y ? beginPoint.Y : endPoint.Y;
            int left = beginPoint.X < endPoint.X ? beginPoint.X : endPoint.X;
            int right = beginPoint.X > endPoint.X ? beginPoint.X : endPoint.X;

            Rectangle rect = new Rectangle(left, top, (right - left), (bottom - top));
            return rect;
        }
    }
}