using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindDifferences.Data
{
    /// <summary>
    /// Класс представляющий сериализованную версию сцены...
    /// </summary>
    [Serializable]
    class SceneInfo
    {
        /// <summary>
        /// Сериализуемые версии наших pictureBox'ов...
        /// </summary>
        private ImageInfo originalImage, changedImage;

        private double bestScore = 0;

        /// <summary>
        /// Количество чекпоинтов в сцене...
        /// </summary>
        private readonly int point_count;

        private int timeValue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalImage">Сериализуемая версия originalImage...</param>
        /// <param name="changedImage">Сериализуема версия changedImage...</param>
        public SceneInfo(ImageInfo originalImage,
            ImageInfo changedImage, int timeValue)
        {
            this.originalImage = originalImage;
            this.changedImage = changedImage;
            this.timeValue = timeValue;

            this.point_count = changedImage.CheckPoints.Length;
        }

        /// <summary>
        /// Геттер на возврат originalImage...
        /// </summary>
        public ImageInfo OriginalImage { get { return originalImage; } }

        /// <summary>
        /// Геттер на возврат changedImage...
        /// </summary>
        public ImageInfo ChangedImage { get { return changedImage; } }

        /// <summary>
        /// Геттер на возврат количества чепоинтов в сцене...
        /// </summary>
        public int Point_Count { get { return point_count; } }

        public double getBestScore { get { return bestScore; } }

        public double setBestScore { set { bestScore = value; } }

        public int getTimeValue { get { return timeValue; } }
    }
}
