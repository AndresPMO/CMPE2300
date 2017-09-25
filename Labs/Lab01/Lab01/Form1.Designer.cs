namespace Lab01
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.UI_pictureBox_Display = new System.Windows.Forms.PictureBox();
            this.UI_richTextBox_Display = new System.Windows.Forms.RichTextBox();
            this.UI_openFileDialog_PicSelector = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.UI_toolStripButton_LoadImage = new System.Windows.Forms.ToolStripButton();
            this.UI_toolStrip_TextColorPick = new System.Windows.Forms.ToolStripComboBox();
            this.UI_toolStrip_SelectColor = new System.Windows.Forms.ToolStripComboBox();
            this.UI_toolStripButton_Go = new System.Windows.Forms.ToolStripButton();
            this.UI_progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.UI_pictureBox_Display)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_pictureBox_Display
            // 
            this.UI_pictureBox_Display.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_pictureBox_Display.InitialImage = null;
            this.UI_pictureBox_Display.Location = new System.Drawing.Point(12, 28);
            this.UI_pictureBox_Display.Name = "UI_pictureBox_Display";
            this.UI_pictureBox_Display.Size = new System.Drawing.Size(517, 312);
            this.UI_pictureBox_Display.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UI_pictureBox_Display.TabIndex = 1;
            this.UI_pictureBox_Display.TabStop = false;
            // 
            // UI_richTextBox_Display
            // 
            this.UI_richTextBox_Display.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_richTextBox_Display.Location = new System.Drawing.Point(13, 346);
            this.UI_richTextBox_Display.Name = "UI_richTextBox_Display";
            this.UI_richTextBox_Display.Size = new System.Drawing.Size(517, 203);
            this.UI_richTextBox_Display.TabIndex = 2;
            this.UI_richTextBox_Display.Text = "";
            // 
            // UI_openFileDialog_PicSelector
            // 
            this.UI_openFileDialog_PicSelector.Filter = "Bitmap|*.bmp";
            this.UI_openFileDialog_PicSelector.Tag = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UI_toolStripButton_LoadImage,
            this.UI_toolStrip_TextColorPick,
            this.UI_toolStrip_SelectColor,
            this.UI_toolStripButton_Go});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(542, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // UI_toolStripButton_LoadImage
            // 
            this.UI_toolStripButton_LoadImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UI_toolStripButton_LoadImage.Image = ((System.Drawing.Image)(resources.GetObject("UI_toolStripButton_LoadImage.Image")));
            this.UI_toolStripButton_LoadImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UI_toolStripButton_LoadImage.Name = "UI_toolStripButton_LoadImage";
            this.UI_toolStripButton_LoadImage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UI_toolStripButton_LoadImage.Size = new System.Drawing.Size(23, 22);
            this.UI_toolStripButton_LoadImage.Text = "Load Image...";
            this.UI_toolStripButton_LoadImage.Click += new System.EventHandler(this.UI_toolStripButton_LoadImage_Click);
            // 
            // UI_toolStrip_TextColorPick
            // 
            this.UI_toolStrip_TextColorPick.Items.AddRange(new object[] {
            "Decode colour",
            "Decode text"});
            this.UI_toolStrip_TextColorPick.Name = "UI_toolStrip_TextColorPick";
            this.UI_toolStrip_TextColorPick.Size = new System.Drawing.Size(121, 25);
            // 
            // UI_toolStrip_SelectColor
            // 
            this.UI_toolStrip_SelectColor.Items.AddRange(new object[] {
            "R",
            "G",
            "B",
            "A"});
            this.UI_toolStrip_SelectColor.Name = "UI_toolStrip_SelectColor";
            this.UI_toolStrip_SelectColor.Size = new System.Drawing.Size(121, 25);
            // 
            // UI_toolStripButton_Go
            // 
            this.UI_toolStripButton_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UI_toolStripButton_Go.Enabled = false;
            this.UI_toolStripButton_Go.Image = ((System.Drawing.Image)(resources.GetObject("UI_toolStripButton_Go.Image")));
            this.UI_toolStripButton_Go.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UI_toolStripButton_Go.Name = "UI_toolStripButton_Go";
            this.UI_toolStripButton_Go.Size = new System.Drawing.Size(23, 22);
            this.UI_toolStripButton_Go.Text = "Go!";
            this.UI_toolStripButton_Go.Click += new System.EventHandler(this.UI_toolStripButton_Go_Click);
            // 
            // UI_progressBar
            // 
            this.UI_progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_progressBar.Location = new System.Drawing.Point(430, 2);
            this.UI_progressBar.Name = "UI_progressBar";
            this.UI_progressBar.Size = new System.Drawing.Size(100, 23);
            this.UI_progressBar.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 561);
            this.Controls.Add(this.UI_progressBar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.UI_richTextBox_Display);
            this.Controls.Add(this.UI_pictureBox_Display);
            this.MinimumSize = new System.Drawing.Size(430, 400);
            this.Name = "Form1";
            this.Text = "Decodatron";
            ((System.ComponentModel.ISupportInitialize)(this.UI_pictureBox_Display)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox UI_pictureBox_Display;
        private System.Windows.Forms.RichTextBox UI_richTextBox_Display;
        private System.Windows.Forms.OpenFileDialog UI_openFileDialog_PicSelector;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ProgressBar UI_progressBar;
        private System.Windows.Forms.ToolStripComboBox UI_toolStrip_TextColorPick;
        private System.Windows.Forms.ToolStripButton UI_toolStripButton_LoadImage;
        private System.Windows.Forms.ToolStripButton UI_toolStripButton_Go;
        private System.Windows.Forms.ToolStripComboBox UI_toolStrip_SelectColor;
    }
}

