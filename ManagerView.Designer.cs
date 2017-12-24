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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.режимToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стартToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимИгрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимМенеджераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сценаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьСценуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьСценуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changedImage = new System.Windows.Forms.PictureBox();
            this.originalImage = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.режимToolStripMenuItem,
            this.сценаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(898, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // режимToolStripMenuItem
            // 
            this.режимToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стартToolStripMenuItem,
            this.режимИгрыToolStripMenuItem,
            this.режимМенеджераToolStripMenuItem});
            this.режимToolStripMenuItem.Name = "режимToolStripMenuItem";
            this.режимToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.режимToolStripMenuItem.Text = "Режим";
            // 
            // стартToolStripMenuItem
            // 
            this.стартToolStripMenuItem.Name = "стартToolStripMenuItem";
            this.стартToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.стартToolStripMenuItem.Text = "Старт";
            this.стартToolStripMenuItem.Click += new System.EventHandler(this.стартToolStripMenuItem_Click_1);
            // 
            // режимИгрыToolStripMenuItem
            // 
            this.режимИгрыToolStripMenuItem.Name = "режимИгрыToolStripMenuItem";
            this.режимИгрыToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.режимИгрыToolStripMenuItem.Text = "Режим игры";
            this.режимИгрыToolStripMenuItem.Click += new System.EventHandler(this.режимИгрыToolStripMenuItem_Click_1);
            // 
            // режимМенеджераToolStripMenuItem
            // 
            this.режимМенеджераToolStripMenuItem.Name = "режимМенеджераToolStripMenuItem";
            this.режимМенеджераToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.режимМенеджераToolStripMenuItem.Text = "Режим менеджера";
            this.режимМенеджераToolStripMenuItem.Click += new System.EventHandler(this.режимМенеджераToolStripMenuItem_Click_1);
            // 
            // сценаToolStripMenuItem
            // 
            this.сценаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьСценуToolStripMenuItem,
            this.сохранитьСценуToolStripMenuItem});
            this.сценаToolStripMenuItem.Name = "сценаToolStripMenuItem";
            this.сценаToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.сценаToolStripMenuItem.Text = "Сцена";
            // 
            // загрузитьСценуToolStripMenuItem
            // 
            this.загрузитьСценуToolStripMenuItem.Name = "загрузитьСценуToolStripMenuItem";
            this.загрузитьСценуToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.загрузитьСценуToolStripMenuItem.Text = "Загрузить сцену";
            this.загрузитьСценуToolStripMenuItem.Click += new System.EventHandler(this.загрузитьСценуToolStripMenuItem_Click_1);
            // 
            // сохранитьСценуToolStripMenuItem
            // 
            this.сохранитьСценуToolStripMenuItem.Name = "сохранитьСценуToolStripMenuItem";
            this.сохранитьСценуToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.сохранитьСценуToolStripMenuItem.Text = "Сохранить сцену";
            this.сохранитьСценуToolStripMenuItem.Click += new System.EventHandler(this.сохранитьСценуToolStripMenuItem_Click_1);
            // 
            // changedImage
            // 
            this.changedImage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.changedImage.Location = new System.Drawing.Point(451, 34);
            this.changedImage.Name = "changedImage";
            this.changedImage.Size = new System.Drawing.Size(423, 535);
            this.changedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.changedImage.TabIndex = 3;
            this.changedImage.TabStop = false;
            // 
            // originalImage
            // 
            this.originalImage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.originalImage.Location = new System.Drawing.Point(12, 34);
            this.originalImage.Name = "originalImage";
            this.originalImage.Size = new System.Drawing.Size(423, 535);
            this.originalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.originalImage.TabIndex = 2;
            this.originalImage.TabStop = false;
            // 
            // ManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 581);
            this.Controls.Add(this.changedImage);
            this.Controls.Add(this.originalImage);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManagerView";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.ManagerView_Activated);
            this.Load += new System.EventHandler(this.ManagerView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem режимToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem режимИгрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem режимМенеджераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сценаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьСценуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьСценуToolStripMenuItem;
        private System.Windows.Forms.PictureBox changedImage;
        private System.Windows.Forms.PictureBox originalImage;
        private System.Windows.Forms.ToolStripMenuItem стартToolStripMenuItem;
    }
}

