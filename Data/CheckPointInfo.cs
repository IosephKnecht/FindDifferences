using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindDifferences.Data
{
    [Serializable]
    struct CheckPointInfo
    {
        private System.Drawing.Point location;
        private System.Drawing.Size size;

        public CheckPointInfo(System.Drawing.Point location, System.Drawing.Size size)
        {
            this.location = location;
            this.size = size;
        }

        public System.Drawing.Point Location { get { return location; } }

        public System.Drawing.Size Size { get { return size; } }
    }
}
