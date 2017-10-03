namespace ICA02_NicW
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
            this.components = new System.ComponentModel.Container();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.UI_label_Opacity = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.UI_label_X = new System.Windows.Forms.Label();
            this.UI_labelY = new System.Windows.Forms.Label();
            this.UI_label_Y = new System.Windows.Forms.Label();
            this.UI_trackBar_Opacity = new System.Windows.Forms.TrackBar();
            this.UI_trackBar_X = new System.Windows.Forms.TrackBar();
            this.UI_trackBar_Y = new System.Windows.Forms.TrackBar();
            this.UI_checkBox_All = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UI_trackBar_Opacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_trackBar_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_trackBar_Y)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Location = new System.Drawing.Point(13, 13);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(46, 13);
            this.labelOpacity.TabIndex = 0;
            this.labelOpacity.Text = "Opacity:";
            // 
            // UI_label_Opacity
            // 
            this.UI_label_Opacity.AutoSize = true;
            this.UI_label_Opacity.Location = new System.Drawing.Point(66, 13);
            this.UI_label_Opacity.Name = "UI_label_Opacity";
            this.UI_label_Opacity.Size = new System.Drawing.Size(25, 13);
            this.UI_label_Opacity.TabIndex = 1;
            this.UI_label_Opacity.Text = "128";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(13, 60);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(17, 13);
            this.labelX.TabIndex = 2;
            this.labelX.Text = "X:";
            // 
            // UI_label_X
            // 
            this.UI_label_X.AutoSize = true;
            this.UI_label_X.Location = new System.Drawing.Point(37, 60);
            this.UI_label_X.Name = "UI_label_X";
            this.UI_label_X.Size = new System.Drawing.Size(13, 13);
            this.UI_label_X.TabIndex = 3;
            this.UI_label_X.Text = "0";
            // 
            // UI_labelY
            // 
            this.UI_labelY.AutoSize = true;
            this.UI_labelY.Location = new System.Drawing.Point(13, 111);
            this.UI_labelY.Name = "UI_labelY";
            this.UI_labelY.Size = new System.Drawing.Size(17, 13);
            this.UI_labelY.TabIndex = 4;
            this.UI_labelY.Text = "Y:";
            // 
            // UI_label_Y
            // 
            this.UI_label_Y.AutoSize = true;
            this.UI_label_Y.Location = new System.Drawing.Point(37, 111);
            this.UI_label_Y.Name = "UI_label_Y";
            this.UI_label_Y.Size = new System.Drawing.Size(13, 13);
            this.UI_label_Y.TabIndex = 5;
            this.UI_label_Y.Text = "0";
            // 
            // UI_trackBar_Opacity
            // 
            this.UI_trackBar_Opacity.Location = new System.Drawing.Point(102, 13);
            this.UI_trackBar_Opacity.Maximum = 255;
            this.UI_trackBar_Opacity.Name = "UI_trackBar_Opacity";
            this.UI_trackBar_Opacity.Size = new System.Drawing.Size(477, 45);
            this.UI_trackBar_Opacity.TabIndex = 10;
            this.UI_trackBar_Opacity.TickFrequency = 10;
            this.UI_trackBar_Opacity.Value = 128;
            this.UI_trackBar_Opacity.Scroll += new System.EventHandler(this.UI_trackBar_Opacity_Scroll);
            // 
            // UI_trackBar_X
            // 
            this.UI_trackBar_X.Location = new System.Drawing.Point(73, 60);
            this.UI_trackBar_X.Maximum = 15;
            this.UI_trackBar_X.Minimum = -15;
            this.UI_trackBar_X.Name = "UI_trackBar_X";
            this.UI_trackBar_X.Size = new System.Drawing.Size(506, 45);
            this.UI_trackBar_X.TabIndex = 11;
            this.UI_trackBar_X.Scroll += new System.EventHandler(this.UI_trackBar_X_Scroll);
            // 
            // UI_trackBar_Y
            // 
            this.UI_trackBar_Y.Location = new System.Drawing.Point(73, 111);
            this.UI_trackBar_Y.Maximum = 15;
            this.UI_trackBar_Y.Minimum = -15;
            this.UI_trackBar_Y.Name = "UI_trackBar_Y";
            this.UI_trackBar_Y.Size = new System.Drawing.Size(506, 45);
            this.UI_trackBar_Y.TabIndex = 12;
            this.UI_trackBar_Y.Scroll += new System.EventHandler(this.UI_trackBar_Y_Scroll);
            // 
            // UI_checkBox_All
            // 
            this.UI_checkBox_All.AutoSize = true;
            this.UI_checkBox_All.Location = new System.Drawing.Point(263, 163);
            this.UI_checkBox_All.Name = "UI_checkBox_All";
            this.UI_checkBox_All.Size = new System.Drawing.Size(37, 17);
            this.UI_checkBox_All.TabIndex = 13;
            this.UI_checkBox_All.Text = "All";
            this.UI_checkBox_All.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 199);
            this.Controls.Add(this.UI_checkBox_All);
            this.Controls.Add(this.UI_trackBar_Y);
            this.Controls.Add(this.UI_trackBar_X);
            this.Controls.Add(this.UI_trackBar_Opacity);
            this.Controls.Add(this.UI_label_Y);
            this.Controls.Add(this.UI_labelY);
            this.Controls.Add(this.UI_label_X);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.UI_label_Opacity);
            this.Controls.Add(this.labelOpacity);
            this.Name = "Form1";
            this.Text = "Balls!";
            ((System.ComponentModel.ISupportInitialize)(this.UI_trackBar_Opacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_trackBar_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_trackBar_Y)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.Label UI_label_Opacity;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label UI_label_X;
        private System.Windows.Forms.Label UI_labelY;
        private System.Windows.Forms.Label UI_label_Y;
        private System.Windows.Forms.TrackBar UI_trackBar_Opacity;
        private System.Windows.Forms.TrackBar UI_trackBar_X;
        private System.Windows.Forms.TrackBar UI_trackBar_Y;
        private System.Windows.Forms.CheckBox UI_checkBox_All;
        private System.Windows.Forms.Timer timer;
    }
}

