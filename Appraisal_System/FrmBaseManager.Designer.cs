﻿namespace Appraisal_System
{
    partial class FrmBaseManager
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
            this.dgvBase = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBase
            // 
            this.dgvBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBase.Location = new System.Drawing.Point(0, 0);
            this.dgvBase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvBase.Name = "dgvBase";
            this.dgvBase.RowHeadersWidth = 62;
            this.dgvBase.RowTemplate.Height = 23;
            this.dgvBase.Size = new System.Drawing.Size(1077, 683);
            this.dgvBase.TabIndex = 0;
            this.dgvBase.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBase_CellValueChanged);
            // 
            // FrmBaseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 683);
            this.Controls.Add(this.dgvBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmBaseManager";
            this.Text = "FrmBaseManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBaseManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBase;
    }
}