using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindDifferences.Data
{
    /// <summary>
    /// Сериализуемая версия нашего чекпоинта...
    /// </summary>
    [Serializable]
    struct CheckPointInfo
    {
        /// <summary>
        /// Расположение чекпоинта...
        /// </summary>
        private System.Drawing.Point location;
        /// <summary>
        /// Размер чекпоинта...
        /// </summary>
        private System.Drawing.Size size;
        /// <summary>
        /// Имя чекпоинта....
        /// </summary>
        private string nameComponent;

        private int value;

        public CheckPointInfo(string nameComponent,System.Drawing.Point location, System.Drawing.Size size,
            int value)
        {
            this.location = location;
            this.size = size;
            this.nameComponent = nameComponent;
            this.value = value;
        }

        /// <summary>
        /// Геттер на возврат расположения чекпоинта...
        /// </summary>
        public System.Drawing.Point Location { get { return location; } }

        /// <summary>
        /// Геттер на возврат размера чекпоинта...
        /// </summary>
        public System.Drawing.Size Size { get { return size; } }

        /// <summary>
        /// Геттер на возврат имени чекпоинта...
        /// </summary>
        public string NameComponent { get { return nameComponent; } }

        public int getValue { get { return value; } }
    }
}
