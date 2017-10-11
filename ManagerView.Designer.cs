namespace FindDifferences
{
    partial class ManagerView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.originalImage = new System.Windows.Forms.PictureBox();
            this.changedImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // originalImage
            // 
            this.originalImage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.originalImage.Location = new System.Drawing.Point(12, 248);
            this.originalImage.Name = "originalImage";
            this.originalImage.Size = new System.Drawing.Size(219, 267);
            this.originalImage.TabIndex = 0;
            this.originalImage.TabStop = false;
            // 
            // changedImage
            // 
            this.changedImage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.changedImage.Location = new System.Drawing.Point(262, 12);
            this.changedImage.Name = "changedImage";
            this.changedImage.Size = new System.Drawing.Size(219, 267);
            this.changedImage.TabIndex = 1;
            this.changedImage.TabStop = false;
            // 
            // ManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 291);
            this.Controls.Add(this.changedImage);
            this.Controls.Add(this.originalImage);
            this.Name = "ManagerView";
            this.Text = "ManagerView";
            this.Load += new System.EventHandler(this.ManagerView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changedImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox originalImage;
        private System.Windows.Forms.PictureBox changedImage;
    }
}

