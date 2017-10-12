namespace ICA7_NicW
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
            this.UI_button_Populate = new System.Windows.Forms.Button();
            this.UI_button_Colour = new System.Windows.Forms.Button();
            this.UI_button_Width = new System.Windows.Forms.Button();
            this.UI_button_WidthDesc = new System.Windows.Forms.Button();
            this.UI_button_WidthColour = new System.Windows.Forms.Button();
            this.UI_button_Bright = new System.Windows.Forms.Button();
            this.UI_button_Length = new System.Windows.Forms.Button();
            this.UI_trackBar_Length = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.UI_trackBar_Length)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_button_Populate
            // 
            this.UI_button_Populate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_button_Populate.Location = new System.Drawing.Point(13, 13);
            this.UI_button_Populate.Name = "UI_button_Populate";
            this.UI_button_Populate.Size = new System.Drawing.Size(259, 23);
            this.UI_button_Populate.TabIndex = 0;
            this.UI_button_Populate.Text = "Populate";
            this.UI_button_Populate.UseVisualStyleBackColor = true;
            this.UI_button_Populate.Click += new System.EventHandler(this.UI_button_Populate_Click);
            // 
            // UI_button_Colour
            // 
            this.UI_button_Colour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_button_Colour.Location = new System.Drawing.Point(13, 43);
            this.UI_button_Colour.Name = "UI_button_Colour";
            this.UI_button_Colour.Size = new System.Drawing.Size(259, 23);
            this.UI_button_Colour.TabIndex = 1;
            this.UI_button_Colour.Text = "Colour";
            this.UI_button_Colour.UseVisualStyleBackColor = true;
            this.UI_button_Colour.Click += new System.EventHandler(this.UI_button_Colour_Click);
            // 
            // UI_button_Width
            // 
            this.UI_button_Width.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_button_Width.Location = new System.Drawing.Point(13, 73);
            this.UI_button_Width.Name = "UI_button_Width";
            this.UI_button_Width.Size = new System.Drawing.Size(259, 23);
            this.UI_button_Width.TabIndex = 2;
            this.UI_button_Width.Text = "Width";
            this.UI_button_Width.UseVisualStyleBackColor = true;
            this.UI_button_Width.Click += new System.EventHandler(this.UI_button_Width_Click);
            // 
            // UI_button_WidthDesc
            // 
            this.UI_button_WidthDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_button_WidthDesc.Location = new System.Drawing.Point(13, 103);
            this.UI_button_WidthDesc.Name = "UI_button_WidthDesc";
            this.UI_button_WidthDesc.Size = new System.Drawing.Size(259, 23);
            this.UI_button_WidthDesc.TabIndex = 3;
            this.UI_button_WidthDesc.Text = "Width, Desc";
            this.UI_button_WidthDesc.UseVisualStyleBackColor = true;
            this.UI_button_WidthDesc.Click += new System.EventHandler(this.UI_button_WidthDesc_Click);
            // 
            // UI_button_WidthColour
            // 
            this.UI_button_WidthColour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_button_WidthColour.Location = new System.Drawing.Point(13, 133);
            this.UI_button_WidthColour.Name = "UI_button_WidthColour";
            this.UI_button_WidthColour.Size = new System.Drawing.Size(259, 23);
            this.UI_button_WidthColour.TabIndex = 4;
            this.UI_button_WidthColour.Text = "Width, Colour";
            this.UI_button_WidthColour.UseVisualStyleBackColor = true;
            // 
            // UI_button_Bright
            // 
            this.UI_button_Bright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_button_Bright.Location = new System.Drawing.Point(13, 163);
            this.UI_button_Bright.Name = "UI_button_Bright";
            this.UI_button_Bright.Size = new System.Drawing.Size(259, 23);
            this.UI_button_Bright.TabIndex = 5;
            this.UI_button_Bright.Text = "Bright";
            this.UI_button_Bright.UseVisualStyleBackColor = true;
            // 
            // UI_button_Length
            // 
            this.UI_button_Length.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_button_Length.Location = new System.Drawing.Point(13, 193);
            this.UI_button_Length.Name = "UI_button_Length";
            this.UI_button_Length.Size = new System.Drawing.Size(259, 23);
            this.UI_button_Length.TabIndex = 6;
            this.UI_button_Length.Text = "Longer than 100";
            this.UI_button_Length.UseVisualStyleBackColor = true;
            // 
            // UI_trackBar_Length
            // 
            this.UI_trackBar_Length.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_trackBar_Length.Location = new System.Drawing.Point(13, 223);
            this.UI_trackBar_Length.Maximum = 190;
            this.UI_trackBar_Length.Minimum = 10;
            this.UI_trackBar_Length.Name = "UI_trackBar_Length";
            this.UI_trackBar_Length.Size = new System.Drawing.Size(259, 45);
            this.UI_trackBar_Length.TabIndex = 7;
            this.UI_trackBar_Length.Value = 100;
            this.UI_trackBar_Length.Scroll += new System.EventHandler(this.UI_trackBar_Length_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.UI_trackBar_Length);
            this.Controls.Add(this.UI_button_Length);
            this.Controls.Add(this.UI_button_Bright);
            this.Controls.Add(this.UI_button_WidthColour);
            this.Controls.Add(this.UI_button_WidthDesc);
            this.Controls.Add(this.UI_button_Width);
            this.Controls.Add(this.UI_button_Colour);
            this.Controls.Add(this.UI_button_Populate);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.Text = "Make some blocks!";
            ((System.ComponentModel.ISupportInitialize)(this.UI_trackBar_Length)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_button_Populate;
        private System.Windows.Forms.Button UI_button_Colour;
        private System.Windows.Forms.Button UI_button_Width;
        private System.Windows.Forms.Button UI_button_WidthDesc;
        private System.Windows.Forms.Button UI_button_WidthColour;
        private System.Windows.Forms.Button UI_button_Bright;
        private System.Windows.Forms.Button UI_button_Length;
        private System.Windows.Forms.TrackBar UI_trackBar_Length;
    }
}

