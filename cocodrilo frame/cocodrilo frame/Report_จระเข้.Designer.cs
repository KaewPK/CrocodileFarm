﻿namespace cocodrilo_frame
{
    partial class Report_จระเข้
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bt_ดูรายงาน = new System.Windows.Forms.Button();
            this.bt_ออก = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_จระเข_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_จระเข_BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_ดูรายงาน
            // 
            this.bt_ดูรายงาน.BackColor = System.Drawing.Color.DimGray;
            this.bt_ดูรายงาน.Font = new System.Drawing.Font("CS ChatThai", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.bt_ดูรายงาน.ForeColor = System.Drawing.Color.White;
            this.bt_ดูรายงาน.Location = new System.Drawing.Point(524, 408);
            this.bt_ดูรายงาน.Name = "bt_ดูรายงาน";
            this.bt_ดูรายงาน.Size = new System.Drawing.Size(129, 30);
            this.bt_ดูรายงาน.TabIndex = 32;
            this.bt_ดูรายงาน.Text = "ดูรายงาน";
            this.bt_ดูรายงาน.UseVisualStyleBackColor = false;
            this.bt_ดูรายงาน.Click += new System.EventHandler(this.bt_ดูรายงาน_Click);
            // 
            // bt_ออก
            // 
            this.bt_ออก.BackColor = System.Drawing.Color.Red;
            this.bt_ออก.Font = new System.Drawing.Font("CS ChatThai", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.bt_ออก.ForeColor = System.Drawing.Color.White;
            this.bt_ออก.Location = new System.Drawing.Point(659, 408);
            this.bt_ออก.Name = "bt_ออก";
            this.bt_ออก.Size = new System.Drawing.Size(129, 30);
            this.bt_ออก.TabIndex = 31;
            this.bt_ออก.Text = "ออก";
            this.bt_ออก.UseVisualStyleBackColor = false;
            this.bt_ออก.Click += new System.EventHandler(this.bt_ออก_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "จระเข้";
            reportDataSource2.Value = this.tbl_จระเข_BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "cocodrilo_frame.Report_จระเข้.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 381);
            this.reportViewer1.TabIndex = 30;
            // 
            // tbl_จระเข_BindingSource
            // 
            this.tbl_จระเข_BindingSource.DataSource = typeof(cocodrilo_frame.tbl_จระเข_);
            // 
            // Report_จระเข้
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bt_ดูรายงาน);
            this.Controls.Add(this.bt_ออก);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_จระเข้";
            this.Text = "Report_จระเข้";
            this.Load += new System.EventHandler(this.Report_จระเข้_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_จระเข_BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_ดูรายงาน;
        private System.Windows.Forms.Button bt_ออก;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_จระเข_BindingSource;
    }
}