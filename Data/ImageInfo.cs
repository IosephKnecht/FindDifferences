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

        public ImageInfo(System.Drawing.Point location, System.Drawing.Size size,
            string filePath, CheckPointInfo[] checkPoints)
        {
            this.location = location;
            this.size = size;
            this.filePath = filePath;
            this.checkPoints = checkPoints;
        }

        public System.Drawing.Point Location { get { return location; } }

        public System.Drawing.Size Size { get { return size; } }

        public string FilePath { get { return filePath; } }

        public CheckPointInfo[] CheckPoints { get { return checkPoints; } }
    }
}
