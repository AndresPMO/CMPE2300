﻿namespace Lab02_NicW
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.UI_toolStripStatus_Loaded = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_toolStripStatus_Installable = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_toolStripStatus_UnInstallble = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.UI_toolStripButton_Load = new System.Windows.Forms.ToolStripButton();
            this.UI_toolStripButton_Analyze = new System.Windows.Forms.ToolStripButton();
            this.UI_toolStripComboBox_Algorithm = new System.Windows.Forms.ToolStripComboBox();
            this.UI_toolStripComboBox_View = new System.Windows.Forms.ToolStripComboBox();
            this.UI_listView_Packages = new System.Windows.Forms.ListView();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UI_toolStripStatus_Loaded,
            this.UI_toolStripStatus_Installable,
            this.UI_toolStripStatus_UnInstallble});
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(455, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // UI_toolStripStatus_Loaded
            // 
            this.UI_toolStripStatus_Loaded.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UI_toolStripStatus_Loaded.Name = "UI_toolStripStatus_Loaded";
            this.UI_toolStripStatus_Loaded.Size = new System.Drawing.Size(107, 17);
            this.UI_toolStripStatus_Loaded.Text = "0 Packages Loaded";
            // 
            // UI_toolStripStatus_Installable
            // 
            this.UI_toolStripStatus_Installable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.UI_toolStripStatus_Installable.Name = "UI_toolStripStatus_Installable";
            this.UI_toolStripStatus_Installable.Size = new System.Drawing.Size(121, 17);
            this.UI_toolStripStatus_Installable.Text = "0 Packages Installable";
            // 
            // UI_toolStripStatus_UnInstallble
            // 
            this.UI_toolStripStatus_UnInstallble.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.UI_toolStripStatus_UnInstallble.Name = "UI_toolStripStatus_UnInstallble";
            this.UI_toolStripStatus_UnInstallble.Size = new System.Drawing.Size(136, 17);
            this.UI_toolStripStatus_UnInstallble.Text = "0 Packages UnInstallable";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UI_toolStripButton_Load,
            this.UI_toolStripButton_Analyze,
            this.UI_toolStripComboBox_Algorithm,
            this.UI_toolStripComboBox_View});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(455, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // UI_toolStripButton_Load
            // 
            this.UI_toolStripButton_Load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UI_toolStripButton_Load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UI_toolStripButton_Load.Name = "UI_toolStripButton_Load";
            this.UI_toolStripButton_Load.Size = new System.Drawing.Size(58, 22);
            this.UI_toolStripButton_Load.Text = "Load File";
            // 
            // UI_toolStripButton_Analyze
            // 
            this.UI_toolStripButton_Analyze.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UI_toolStripButton_Analyze.Image = ((System.Drawing.Image)(resources.GetObject("UI_toolStripButton_Analyze.Image")));
            this.UI_toolStripButton_Analyze.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UI_toolStripButton_Analyze.Name = "UI_toolStripButton_Analyze";
            this.UI_toolStripButton_Analyze.Size = new System.Drawing.Size(52, 22);
            this.UI_toolStripButton_Analyze.Text = "Analyze";
            // 
            // UI_toolStripComboBox_Algorithm
            // 
            this.UI_toolStripComboBox_Algorithm.Items.AddRange(new object[] {
            "Raw List Access",
            "Library Helpers",
            "Binary Search "});
            this.UI_toolStripComboBox_Algorithm.Name = "UI_toolStripComboBox_Algorithm";
            this.UI_toolStripComboBox_Algorithm.Size = new System.Drawing.Size(121, 25);
            // 
            // UI_toolStripComboBox_View
            // 
            this.UI_toolStripComboBox_View.Items.AddRange(new object[] {
            "All Packages",
            "Loadable Packages",
            "Unloadable Packages"});
            this.UI_toolStripComboBox_View.Name = "UI_toolStripComboBox_View";
            this.UI_toolStripComboBox_View.Size = new System.Drawing.Size(121, 25);
            // 
            // UI_listView_Packages
            // 
            this.UI_listView_Packages.Location = new System.Drawing.Point(0, 29);
            this.UI_listView_Packages.Name = "UI_listView_Packages";
            this.UI_listView_Packages.Size = new System.Drawing.Size(455, 485);
            this.UI_listView_Packages.TabIndex = 2;
            this.UI_listView_Packages.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 539);
            this.Controls.Add(this.UI_listView_Packages);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel UI_toolStripStatus_Loaded;
        private System.Windows.Forms.ToolStripStatusLabel UI_toolStripStatus_Installable;
        private System.Windows.Forms.ToolStripStatusLabel UI_toolStripStatus_UnInstallble;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton UI_toolStripButton_Load;
        private System.Windows.Forms.ToolStripButton UI_toolStripButton_Analyze;
        private System.Windows.Forms.ToolStripComboBox UI_toolStripComboBox_Algorithm;
        private System.Windows.Forms.ToolStripComboBox UI_toolStripComboBox_View;
        private System.Windows.Forms.ListView UI_listView_Packages;
    }
}
