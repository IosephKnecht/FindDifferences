using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindDifferences.Data
{
    /// <summary>
    /// Сериализуемая версия pictureBox'a...
    /// </summary>
    [Serializable]
    struct ImageInfo
    {
        /// <summary>
        /// Расположение pictureBox'a...
        /// </summary>
        private System.Drawing.Point location;
        /// <summary>
        /// Размер pictureBox'a...
        /// </summary>
        private System.Drawing.Size size;
        /// <summary>
        /// Путь до картинки pictureBox'a...
        /// </summary>
        private string filePath;
        /// <summary>
        /// Все чекпоинты pictureBox'a...
        /// </summary>
        private CheckPointInfo[] checkPoints;
        /// <summary>
        /// Имя pictureBox'a...
        /// </summary>
        private string nameComponent;
        /// <summary>
        /// Фоновый цвет pictureBox'a...
        /// </summary>
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

        /// <summary>
        /// Геттер расположения pictureBox'a...
        /// </summary>
        public System.Drawing.Point Location { get { return location; } }

        /// <summary>
        /// Геттер размера pictureBox'a...
        /// </summary>
        public System.Drawing.Size Size { get { return size; } }

        /// <summary>
        /// Геттер пути до картинки pictureBox'a...
        /// </summary>
        public string FilePath { get { return filePath; } }

        /// <summary>
        /// Геттер массива чекпоинтов pictureBox'a...
        /// </summary>
        public CheckPointInfo[] CheckPoints { get { return checkPoints; } }

        /// <summary>
        /// Геттер имени pictureBox'a...
        /// </summary>
        public string NameComponent { get { return nameComponent; } }

        /// <summary>
        /// Геттер фонового цвета pictureBox'a...
        /// </summary>
        public System.Drawing.Color BackColor { get { return backColor; } }
    }
}
