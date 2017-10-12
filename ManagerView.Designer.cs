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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьСценуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьСценуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьСценуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьСценуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changedImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // originalImage
            // 
            this.originalImage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.originalImage.Location = new System.Drawing.Point(12, 40);
            this.originalImage.Name = "originalImage";
            this.originalImage.Size = new System.Drawing.Size(423, 535);
            this.originalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.originalImage.TabIndex = 0;
            this.originalImage.TabStop = false;
            // 
            // changedImage
            // 
            this.changedImage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.changedImage.Location = new System.Drawing.Point(461, 40);
            this.changedImage.Name = "changedImage";
            this.changedImage.Size = new System.Drawing.Size(415, 535);
            this.changedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.changedImage.TabIndex = 1;
            this.changedImage.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьСценуToolStripMenuItem,
            this.загрузитьСценуToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(899, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьСценуToolStripMenuItem
            // 
            this.сохранитьСценуToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьСценуToolStripMenuItem1,
            this.сохранитьСценуToolStripMenuItem1});
            this.сохранитьСценуToolStripMenuItem.Name = "сохранитьСценуToolStripMenuItem";
            this.сохранитьСценуToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.сохранитьСценуToolStripMenuItem.Text = "Сцена";
            // 
            // загрузитьСценуToolStripMenuItem1
            // 
            this.загрузитьСценуToolStripMenuItem1.Name = "загрузитьСценуToolStripMenuItem1";
            this.загрузитьСценуToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.загрузитьСценуToolStripMenuItem1.Text = "Загрузить сцену";
            this.загрузитьСценуToolStripMenuItem1.Click += new System.EventHandler(this.загрузитьСценуToolStripMenuItem_Click);
            // 
            // сохранитьСценуToolStripMenuItem1
            // 
            this.сохранитьСценуToolStripMenuItem1.Name = "сохранитьСценуToolStripMenuItem1";
            this.сохранитьСценуToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.сохранитьСценуToolStripMenuItem1.Text = "Сохранить сцену";
            this.сохранитьСценуToolStripMenuItem1.Click += new System.EventHandler(this.сохранитьСценуToolStripMenuItem_Click);
            // 
            // загрузитьСценуToolStripMenuItem
            // 
            this.загрузитьСценуToolStripMenuItem.Name = "загрузитьСценуToolStripMenuItem";
            this.загрузитьСценуToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            this.загрузитьСценуToolStripMenuItem.Click += new System.EventHandler(this.загрузитьСценуToolStripMenuItem_Click);
            // 
            // ManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 586);
            this.Controls.Add(this.changedImage);
            this.Controls.Add(this.originalImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManagerView";
            this.Text = "ManagerView";
            this.Load += new System.EventHandler(this.ManagerView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changedImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalImage;
        private System.Windows.Forms.PictureBox changedImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьСценуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьСценуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьСценуToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьСценуToolStripMenuItem1;
    }
}

