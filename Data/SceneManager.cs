using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindDifferences.Data
{
    [Serializable]
    class SceneManager
    {
        private List<SceneInfo> scenes;

        public event Action deleteScene;
        public event Action<object, object> recoverScene;

        static SceneManager sManager;

        protected SceneManager()
        {
            scenes = new List<SceneInfo>();
        }

        public static SceneManager Instance()
        {
            if (sManager == null) return sManager = new SceneManager();

            return sManager;
        }

        public SceneInfo ChangeScene(int numScene)
        {
            deleteScene();

            return scenes[numScene];
        }

        public void SaveScene(System.Windows.Forms.PictureBox originalImage,
            System.Windows.Forms.PictureBox changedImage)
        {
            ImageInfo originalStruct = new ImageInfo(originalImage.Location,
                originalImage.Size, originalImage.ImageLocation,ControlsToArray(originalImage));
            
            ImageInfo changedStruct= new ImageInfo(changedImage.Location,
                changedImage.Size, changedImage.ImageLocation, ControlsToArray(changedImage));

            scenes.Add(new SceneInfo(originalStruct, changedStruct));
        }

        public void LoadScene(int numScene)
        {
            if(numScene<scenes.Count && numScene >= 0)
            {
                SceneInfo scene = scenes[numScene];

                System.Windows.Forms.PictureBox originalImage = new System.Windows.Forms.PictureBox();
                System.Windows.Forms.PictureBox changedImage = new System.Windows.Forms.PictureBox();

                RecoverImage(ref originalImage, scene.OriginalImage);
                RecoverImage(ref changedImage, scene.ChangedImage);

                recoverScene(originalImage, changedImage);
            }
        }

        private void RecoverImage
            (ref System.Windows.Forms.PictureBox image,
            ImageInfo info)
        {
            image.Location = info.Location;
            image.Size = info.Size;
            image.ImageLocation = info.FilePath;

            foreach (CheckPointInfo checkPoint in info.CheckPoints)
            {
                System.Windows.Forms.Label label = new System.Windows.Forms.Label();

                label.Location = checkPoint.Location;
                label.Size = checkPoint.Size;

                image.Controls.Add(label);
            }
        }

        //private void RecoverCheckPoints
        //    (CheckPointInfo[] checkPoints,
        //    ref System.Windows.Forms.Control.ControlCollection Controls)
        //{
        //    foreach (CheckPointInfo checkPoint in checkPoints)
        //    {
        //        System.Windows.Forms.Label label = new System.Windows.Forms.Label();

        //        label.Location = checkPoint.Location;
        //        label.Size = checkPoint.Size;

        //        Controls.Add(label);
        //    }
        //}

        private CheckPointInfo[] ControlsToArray(System.Windows.Forms.PictureBox changedImage)
        {
            List<CheckPointInfo> checkPoints = new List<CheckPointInfo>();

            foreach (System.Windows.Forms.Label label in changedImage.Controls)
            {
                checkPoints.Add(new CheckPointInfo(label.Location,label.Size));
            }

            return checkPoints.ToArray();
        }
    }
}
