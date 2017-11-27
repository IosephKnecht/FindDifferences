using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindDifferences.Data
{
    [Serializable]
    class SceneManager
    {
        /// <summary>
        /// Массив сцен...
        /// </summary>
        private List<SceneInfo> scenes;

        /// <summary>
        /// Вообще не знаю вызывается ли он...Но должен удалять сцену...
        /// </summary>
        public event Action deleteScene;
        /// <summary>
        /// Событие на восстановление сцены...
        /// </summary>
        public event Action<object, object> recoverScene;

        /// <summary>
        /// Экземпляр Singleton'a...
        /// </summary>
        static SceneManager sManager;

        protected SceneManager()
        {
            scenes = new List<SceneInfo>();//Инициализируем массив сцен...
        }

        /// <summary>
        /// Метод инстанцирования экземпляра класса...
        /// </summary>
        /// <returns>Экземпляр класса SceneManager...</returns>
        public static SceneManager Instance()
        {
            if (sManager == null) return sManager = new SceneManager();

            return sManager;
        }

        /// <summary>
        /// Костыль на обновление SceneManager после десериализации...
        /// </summary>
        /// <param name="desManager"></param>
        public static void SM(SceneManager desManager)
        {
            sManager = desManager;
        }

        /// <summary>
        /// Геттер на возврат массива сцен...
        /// </summary>
        public List<SceneInfo> Scenes { get { return scenes; } }

        /// <summary>
        /// Не помню используется ли вообще...
        /// Реализует логику удаления сцены и возврат новой по индексу...
        /// </summary>
        /// <param name="numScene">Номер сцены...</param>
        /// <returns>Сцена из массива scenes...</returns>
        public SceneInfo ChangeScene(int numScene)
        {
            deleteScene();

            return scenes[numScene];
        }

        /// <summary>
        /// Метод создающий две структуры для реализации последующей сериализации...
        /// </summary>
        /// <param name="originalImage">Оригинальный pictureBox, хранящий 
        /// оригинальное изображение...</param>
        /// <param name="changedImage">Изменненный pictureBox,хранящий изменное изображение...</param>
        public void SaveScene(System.Windows.Forms.PictureBox originalImage,
            System.Windows.Forms.PictureBox changedImage)
        {
            ImageInfo originalStruct = new ImageInfo(originalImage.Name,originalImage.Location,
                originalImage.Size, originalImage.ImageLocation,ControlsToArray(originalImage),originalImage.BackColor);
            
            ImageInfo changedStruct= new ImageInfo(changedImage.Name,changedImage.Location,
                changedImage.Size, changedImage.ImageLocation, ControlsToArray(changedImage),changedImage.BackColor);

            scenes.Add(new SceneInfo(originalStruct, changedStruct));
        }

        /// <summary>
        /// Метод реализует логику загрузки загрузку и вызов логики восстановления
        /// pictureBox'ов...
        /// </summary>
        /// <param name="numScene">Номер сцены...</param>
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

        /// <summary>
        /// Метод,реализующий логику восстановления параметров изображения и 
        /// его чекпоинтов...
        /// </summary>
        /// <param name="image"></param>
        /// <param name="info"></param>
        private void RecoverImage
            (ref System.Windows.Forms.PictureBox image,
            ImageInfo info)
        {
            image.Location = info.Location;
            image.Size = info.Size;
            image.ImageLocation = info.FilePath;
            image.Name = info.NameComponent;
            image.BackColor = info.BackColor;
            image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;

            System.Drawing.Bitmap btm = new System.Drawing.Bitmap(image.ImageLocation);
            image.Image = btm;

            foreach (CheckPointInfo checkPoint in info.CheckPoints)
            {
                System.Windows.Forms.Label label = new System.Windows.Forms.Label();

                label.Location = checkPoint.Location;
                label.Size = checkPoint.Size;
                label.Name = checkPoint.NameComponent;
                label.BackColor = System.Drawing.Color.Transparent;

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

        /// <summary>
        /// Вспомогательный метод,добывающий из PictureBox все чекпоинты...
        /// </summary>
        /// <param name="changedImage">pictureBox,хранящий изменненное изображение...</param>
        /// <returns>Массив типа CheckPointInfo...</returns>
        private CheckPointInfo[] ControlsToArray(System.Windows.Forms.PictureBox changedImage)
        {
            List<CheckPointInfo> checkPoints = new List<CheckPointInfo>();

            foreach (System.Windows.Forms.Label label in changedImage.Controls)
            {
                checkPoints.Add(new CheckPointInfo(label.Name,label.Location,label.Size));
            }

            return checkPoints.ToArray();
        }
    }
}
