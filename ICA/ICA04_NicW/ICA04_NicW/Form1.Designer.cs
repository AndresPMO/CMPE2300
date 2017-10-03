namespace ICA04_NicW
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
            this.UI_button_Add = new System.Windows.Forms.Button();
            this.UI_progressBar_Discard = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // UI_button_Add
            // 
            this.UI_button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_button_Add.Location = new System.Drawing.Point(13, 13);
            this.UI_button_Add.Name = "UI_button_Add";
            this.UI_button_Add.Size = new System.Drawing.Size(331, 64);
            this.UI_button_Add.TabIndex = 0;
            this.UI_button_Add.Text = "Add Blocks: Size - 80";
            this.UI_button_Add.UseVisualStyleBackColor = true;
            this.UI_button_Add.Click += new System.EventHandler(this.UI_button_Add_Click);
            // 
            // UI_progressBar_Discard
            // 
            this.UI_progressBar_Discard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_progressBar_Discard.Location = new System.Drawing.Point(13, 84);
            this.UI_progressBar_Discard.Maximum = 1000;
            this.UI_progressBar_Discard.Name = "UI_progressBar_Discard";
            this.UI_progressBar_Discard.Size = new System.Drawing.Size(331, 23);
            this.UI_progressBar_Discard.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 114);
            this.Controls.Add(this.UI_progressBar_Discard);
            this.Controls.Add(this.UI_button_Add);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UI_button_Add;
        private System.Windows.Forms.ProgressBar UI_progressBar_Discard;
    }
}

