namespace ICA06_NicW
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
            this.UI_button_AddBalls = new System.Windows.Forms.Button();
            this.groupBox_SortType = new System.Windows.Forms.GroupBox();
            this.UI_radioButton_Colour = new System.Windows.Forms.RadioButton();
            this.UI_radioButton_Distance = new System.Windows.Forms.RadioButton();
            this.UI_radioButton_Radius = new System.Windows.Forms.RadioButton();
            this.progressBar_Discards = new System.Windows.Forms.ProgressBar();
            this.groupBox_SortType.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_button_AddBalls
            // 
            this.UI_button_AddBalls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_button_AddBalls.Location = new System.Drawing.Point(13, 13);
            this.UI_button_AddBalls.Name = "UI_button_AddBalls";
            this.UI_button_AddBalls.Size = new System.Drawing.Size(209, 23);
            this.UI_button_AddBalls.TabIndex = 0;
            this.UI_button_AddBalls.Text = "Add exclusive balls (-50)";
            this.UI_button_AddBalls.UseVisualStyleBackColor = true;
            this.UI_button_AddBalls.Click += new System.EventHandler(this.UI_button_AddBalls_Click);
            // 
            // groupBox_SortType
            // 
            this.groupBox_SortType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_SortType.Controls.Add(this.UI_radioButton_Colour);
            this.groupBox_SortType.Controls.Add(this.UI_radioButton_Distance);
            this.groupBox_SortType.Controls.Add(this.UI_radioButton_Radius);
            this.groupBox_SortType.Location = new System.Drawing.Point(13, 43);
            this.groupBox_SortType.Name = "groupBox_SortType";
            this.groupBox_SortType.Size = new System.Drawing.Size(209, 49);
            this.groupBox_SortType.TabIndex = 1;
            this.groupBox_SortType.TabStop = false;
            this.groupBox_SortType.Text = "Sort Type";
            // 
            // UI_radioButton_Colour
            // 
            this.UI_radioButton_Colour.AutoSize = true;
            this.UI_radioButton_Colour.Location = new System.Drawing.Point(144, 20);
            this.UI_radioButton_Colour.Name = "UI_radioButton_Colour";
            this.UI_radioButton_Colour.Size = new System.Drawing.Size(55, 17);
            this.UI_radioButton_Colour.TabIndex = 2;
            this.UI_radioButton_Colour.TabStop = true;
            this.UI_radioButton_Colour.Text = "Colour";
            this.UI_radioButton_Colour.UseVisualStyleBackColor = true;
            this.UI_radioButton_Colour.Click += new System.EventHandler(this.UI_radioButton_Radius_Click);
            // 
            // UI_radioButton_Distance
            // 
            this.UI_radioButton_Distance.AutoSize = true;
            this.UI_radioButton_Distance.Location = new System.Drawing.Point(71, 20);
            this.UI_radioButton_Distance.Name = "UI_radioButton_Distance";
            this.UI_radioButton_Distance.Size = new System.Drawing.Size(67, 17);
            this.UI_radioButton_Distance.TabIndex = 1;
            this.UI_radioButton_Distance.TabStop = true;
            this.UI_radioButton_Distance.Text = "Distance";
            this.UI_radioButton_Distance.UseVisualStyleBackColor = true;
            this.UI_radioButton_Distance.Click += new System.EventHandler(this.UI_radioButton_Radius_Click);
            // 
            // UI_radioButton_Radius
            // 
            this.UI_radioButton_Radius.AutoSize = true;
            this.UI_radioButton_Radius.Location = new System.Drawing.Point(7, 20);
            this.UI_radioButton_Radius.Name = "UI_radioButton_Radius";
            this.UI_radioButton_Radius.Size = new System.Drawing.Size(58, 17);
            this.UI_radioButton_Radius.TabIndex = 0;
            this.UI_radioButton_Radius.TabStop = true;
            this.UI_radioButton_Radius.Text = "Radius";
            this.UI_radioButton_Radius.UseVisualStyleBackColor = true;
            this.UI_radioButton_Radius.Click += new System.EventHandler(this.UI_radioButton_Radius_Click);
            // 
            // progressBar_Discards
            // 
            this.progressBar_Discards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Discards.Location = new System.Drawing.Point(12, 98);
            this.progressBar_Discards.Maximum = 1000;
            this.progressBar_Discards.Name = "progressBar_Discards";
            this.progressBar_Discards.Size = new System.Drawing.Size(210, 23);
            this.progressBar_Discards.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 131);
            this.Controls.Add(this.progressBar_Discards);
            this.Controls.Add(this.groupBox_SortType);
            this.Controls.Add(this.UI_button_AddBalls);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(250, 170);
            this.Name = "Form1";
            this.Text = "No balls";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBox_SortType.ResumeLayout(false);
            this.groupBox_SortType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UI_button_AddBalls;
        private System.Windows.Forms.GroupBox groupBox_SortType;
        private System.Windows.Forms.RadioButton UI_radioButton_Colour;
        private System.Windows.Forms.RadioButton UI_radioButton_Distance;
        private System.Windows.Forms.RadioButton UI_radioButton_Radius;
        private System.Windows.Forms.ProgressBar progressBar_Discards;
    }
}

