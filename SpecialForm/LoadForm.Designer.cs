namespace FindDifferences.SpecialForm
{
    partial class LoadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.originalImage = new System.Windows.Forms.PictureBox();
            this.changedImage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(141, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // originalImage
            // 
            this.originalImage.Location = new System.Drawing.Point(171, 23);
            this.originalImage.Name = "originalImage";
            this.originalImage.Size = new System.Drawing.Size(129, 130);
            this.originalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalImage.TabIndex = 1;
            this.originalImage.TabStop = false;
            // 
            // changedImage
            // 
            this.changedImage.Location = new System.Drawing.Point(320, 23);
            this.changedImage.Name = "changedImage";
            this.changedImage.Size = new System.Drawing.Size(129, 130);
            this.changedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.changedImage.TabIndex = 2;
            this.changedImage.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 167);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.changedImage);
            this.Controls.Add(this.originalImage);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoadForm";
            this.Text = "LoadForm";
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changedImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox originalImage;
        private System.Windows.Forms.PictureBox changedImage;
        private System.Windows.Forms.Button button1;
    }
}