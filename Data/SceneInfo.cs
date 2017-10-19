using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindDifferences.Data
{
    [Serializable]
    class SceneInfo
    {
        private ImageInfo originalImage, changedImage;

        private readonly int point_count;

        public SceneInfo(ImageInfo originalImage,
            ImageInfo changedImage)
        {
            this.originalImage = originalImage;
            this.changedImage = changedImage;

            this.point_count = changedImage.CheckPoints.Length;
        }

        public ImageInfo OriginalImage { get { return originalImage; } }

        public ImageInfo ChangedImage { get { return changedImage; } }

        public int Point_Count { get { return point_count; } }
    }
}
