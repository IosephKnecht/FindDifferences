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

        public SceneInfo(ImageInfo originalImage,
            ImageInfo changedImage)
        {
            this.originalImage = originalImage;
            this.changedImage = changedImage;
        }

        public ImageInfo OriginalImage { get { return originalImage; } }

        public ImageInfo ChangedImage { get { return changedImage; } }
    }
}
