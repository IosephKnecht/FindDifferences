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
        private string nameComponent;

        public CheckPointInfo(string nameComponent,System.Drawing.Point location, System.Drawing.Size size)
        {
            this.location = location;
            this.size = size;
            this.nameComponent = nameComponent;
        }

        public System.Drawing.Point Location { get { return location; } }

        public System.Drawing.Size Size { get { return size; } }

        public string NameComponent { get { return nameComponent; } }
    }
}
