namespace ICA11_NicW
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
            this.UI_button_Load = new System.Windows.Forms.Button();
            this.UI_button_Average = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.UI_listView_Bytes = new System.Windows.Forms.ListView();
            this.columnHeader_Byte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // UI_button_Load
            // 
            this.UI_button_Load.Location = new System.Drawing.Point(13, 13);
            this.UI_button_Load.Name = "UI_button_Load";
            this.UI_button_Load.Size = new System.Drawing.Size(154, 23);
            this.UI_button_Load.TabIndex = 0;
            this.UI_button_Load.Text = "Load File";
            this.UI_button_Load.UseVisualStyleBackColor = true;
            this.UI_button_Load.Click += new System.EventHandler(this.UI_button_Load_Click);
            // 
            // UI_button_Average
            // 
            this.UI_button_Average.Location = new System.Drawing.Point(13, 43);
            this.UI_button_Average.Name = "UI_button_Average";
            this.UI_button_Average.Size = new System.Drawing.Size(154, 23);
            this.UI_button_Average.TabIndex = 1;
            this.UI_button_Average.Text = "Average";
            this.UI_button_Average.UseVisualStyleBackColor = true;
            this.UI_button_Average.Click += new System.EventHandler(this.UI_button_Average_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // UI_listView_Bytes
            // 
            this.UI_listView_Bytes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_listView_Bytes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Byte,
            this.columnHeader_Count});
            this.UI_listView_Bytes.Location = new System.Drawing.Point(13, 73);
            this.UI_listView_Bytes.Name = "UI_listView_Bytes";
            this.UI_listView_Bytes.Size = new System.Drawing.Size(164, 376);
            this.UI_listView_Bytes.TabIndex = 2;
            this.UI_listView_Bytes.UseCompatibleStateImageBehavior = false;
            this.UI_listView_Bytes.View = System.Windows.Forms.View.Details;
            this.UI_listView_Bytes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.UI_listView_Bytes_ColumnClick);
            // 
            // columnHeader_Byte
            // 
            this.columnHeader_Byte.Text = "Byte";
            // 
            // columnHeader_Count
            // 
            this.columnHeader_Count.Text = "Count";
            this.columnHeader_Count.Width = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 461);
            this.Controls.Add(this.UI_listView_Bytes);
            this.Controls.Add(this.UI_button_Average);
            this.Controls.Add(this.UI_button_Load);
            this.MaximumSize = new System.Drawing.Size(205, 500);
            this.MinimumSize = new System.Drawing.Size(205, 500);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UI_button_Load;
        private System.Windows.Forms.Button UI_button_Average;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListView UI_listView_Bytes;
        private System.Windows.Forms.ColumnHeader columnHeader_Byte;
        private System.Windows.Forms.ColumnHeader columnHeader_Count;
    }
}

