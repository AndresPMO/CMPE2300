namespace ICA09_NicW
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
            this.UI_button_Simulate = new System.Windows.Forms.Button();
            this.UI_numericUpDown_Queues = new System.Windows.Forms.NumericUpDown();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.UI_label_Sheeple = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UI_numericUpDown_Queues)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_button_Simulate
            // 
            this.UI_button_Simulate.Location = new System.Drawing.Point(13, 13);
            this.UI_button_Simulate.Name = "UI_button_Simulate";
            this.UI_button_Simulate.Size = new System.Drawing.Size(168, 20);
            this.UI_button_Simulate.TabIndex = 0;
            this.UI_button_Simulate.Text = "Simulate";
            this.UI_button_Simulate.UseVisualStyleBackColor = true;
            // 
            // UI_numericUpDown_Queues
            // 
            this.UI_numericUpDown_Queues.Location = new System.Drawing.Point(188, 13);
            this.UI_numericUpDown_Queues.Name = "UI_numericUpDown_Queues";
            this.UI_numericUpDown_Queues.Size = new System.Drawing.Size(84, 20);
            this.UI_numericUpDown_Queues.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 20;
            // 
            // UI_label_Sheeple
            // 
            this.UI_label_Sheeple.AutoSize = true;
            this.UI_label_Sheeple.Location = new System.Drawing.Point(13, 40);
            this.UI_label_Sheeple.MinimumSize = new System.Drawing.Size(260, 30);
            this.UI_label_Sheeple.Name = "UI_label_Sheeple";
            this.UI_label_Sheeple.Size = new System.Drawing.Size(260, 30);
            this.UI_label_Sheeple.TabIndex = 2;
            this.UI_label_Sheeple.Text = "The next Sheeple to be added";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 89);
            this.Controls.Add(this.UI_label_Sheeple);
            this.Controls.Add(this.UI_numericUpDown_Queues);
            this.Controls.Add(this.UI_button_Simulate);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.UI_numericUpDown_Queues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_button_Simulate;
        private System.Windows.Forms.NumericUpDown UI_numericUpDown_Queues;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label UI_label_Sheeple;
    }
}

