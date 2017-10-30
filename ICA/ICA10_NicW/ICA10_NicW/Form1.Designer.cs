namespace ICA10_NicW
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
            this.UI_numericUpDown_Divisor = new System.Windows.Forms.NumericUpDown();
            this.UI_button_MakeList = new System.Windows.Forms.Button();
            this.UI_button_Shuffle = new System.Windows.Forms.Button();
            this.UI_button_LinkedList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UI_numericUpDown_Divisor)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_numericUpDown_Divisor
            // 
            this.UI_numericUpDown_Divisor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_numericUpDown_Divisor.Location = new System.Drawing.Point(13, 13);
            this.UI_numericUpDown_Divisor.Name = "UI_numericUpDown_Divisor";
            this.UI_numericUpDown_Divisor.Size = new System.Drawing.Size(219, 20);
            this.UI_numericUpDown_Divisor.TabIndex = 0;
            // 
            // UI_button_MakeList
            // 
            this.UI_button_MakeList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_button_MakeList.Location = new System.Drawing.Point(13, 40);
            this.UI_button_MakeList.Name = "UI_button_MakeList";
            this.UI_button_MakeList.Size = new System.Drawing.Size(219, 23);
            this.UI_button_MakeList.TabIndex = 1;
            this.UI_button_MakeList.Text = "Make List";
            this.UI_button_MakeList.UseVisualStyleBackColor = true;
            // 
            // UI_button_Shuffle
            // 
            this.UI_button_Shuffle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_button_Shuffle.Location = new System.Drawing.Point(13, 70);
            this.UI_button_Shuffle.Name = "UI_button_Shuffle";
            this.UI_button_Shuffle.Size = new System.Drawing.Size(219, 23);
            this.UI_button_Shuffle.TabIndex = 2;
            this.UI_button_Shuffle.Text = "Shuffle";
            this.UI_button_Shuffle.UseVisualStyleBackColor = true;
            // 
            // UI_button_LinkedList
            // 
            this.UI_button_LinkedList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_button_LinkedList.Location = new System.Drawing.Point(13, 100);
            this.UI_button_LinkedList.Name = "UI_button_LinkedList";
            this.UI_button_LinkedList.Size = new System.Drawing.Size(219, 23);
            this.UI_button_LinkedList.TabIndex = 3;
            this.UI_button_LinkedList.Text = "Populate Linked List";
            this.UI_button_LinkedList.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 139);
            this.Controls.Add(this.UI_button_LinkedList);
            this.Controls.Add(this.UI_button_Shuffle);
            this.Controls.Add(this.UI_button_MakeList);
            this.Controls.Add(this.UI_numericUpDown_Divisor);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.UI_numericUpDown_Divisor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown UI_numericUpDown_Divisor;
        private System.Windows.Forms.Button UI_button_MakeList;
        private System.Windows.Forms.Button UI_button_Shuffle;
        private System.Windows.Forms.Button UI_button_LinkedList;
    }
}

