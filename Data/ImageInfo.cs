using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindDifferences.Data
{
    [Serializable]
    struct ImageInfo
    {
        private System.Drawing.Point location;
        private System.Drawing.Size size;
        private string filePath;
        private CheckPointInfo[] checkPoints;
        private string nameComponent;
        private System.Drawing.Color backColor;

        public ImageInfo(string nameComponent,System.Drawing.Point location, System.Drawing.Size size,
            string filePath, CheckPointInfo[] checkPoints, System.Drawing.Color backColor)
        {
            this.location = location;
            this.size = size;
            this.filePath = filePath;
            this.checkPoints = checkPoints;
            this.nameComponent = nameComponent;
            this.backColor = backColor;
        }

        public System.Drawing.Point Location { get { return location; } }

        public System.Drawing.Size Size { get { return size; } }

        public string FilePath { get { return filePath; } }

        public CheckPointInfo[] CheckPoints { get { return checkPoints; } }

        public string NameComponent { get { return nameComponent; } }

        public System.Drawing.Color BackColor { get { return backColor; } }
    }
}
