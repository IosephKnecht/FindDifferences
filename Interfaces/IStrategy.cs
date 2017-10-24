using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindDifferences.Interfaces
{
    interface IStrategy
    {
        void MouseDown(object sender, System.Windows.Forms.MouseEventArgs e);
        void MouseMove(object sender, System.Windows.Forms.MouseEventArgs e);
        void MouseUp(object sender, System.Windows.Forms.MouseEventArgs e);
        void Label_Click(object sender, EventArgs e);
        void DragEnter(object sender, System.Windows.Forms.DragEventArgs e);
        void DragDrop(object sender, System.Windows.Forms.DragEventArgs e);
        event Action<object> AddComponent;
        System.Windows.Forms.PictureBox UpdateLinkChangedImage { set; }
    }
}
