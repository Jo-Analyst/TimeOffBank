using Interface.Views.Report.Data;
using Interface.Views.Report.Data.DsServiceTableAdapters;

namespace Interface
{
    partial class FrmReportService
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportService));
            this.dtServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsService = new Interface.Views.Report.Data.DsService();
            this.dtQuantityServicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtServiceTableAdapter = new Interface.Views.Report.Data.DsServiceTableAdapters.DtServiceTableAdapter();
            this.dtQuantityServicesTableAdapter = new Interface.Views.Report.Data.DsServiceTableAdapters.dtQuantityServicesTableAdapter();
            this.dtQuantityTotalServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtQuantityTotalServiceTableAdapter = new Interface.Views.Report.Data.DsServiceTableAdapters.DtQuantityTotalServiceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtQuantityServicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtQuantityTotalServiceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dtServiceBindingSource
            // 
            this.dtServiceBindingSource.DataMember = "DtService";
            this.dtServiceBindingSource.DataSource = this.dsService;
            // 
            // dsService
            // 
            this.dsService.DataSetName = "DsService";
            this.dsService.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtQuantityServicesBindingSource
            // 
            this.dtQuantityServicesBindingSource.DataMember = "dtQuantityServices";
            this.dtQuantityServicesBindingSource.DataSource = this.dsService;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsService";
            reportDataSource1.Value = this.dtServiceBindingSource;
            reportDataSource2.Name = "dsQuantityServices";
            reportDataSource2.Value = this.dtQuantityServicesBindingSource;
            reportDataSource3.Name = "dsQuantityTotalServices";
            reportDataSource3.Value = this.dtQuantityTotalServiceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Interface.Views.Report.Relatório do Atendimento Diário.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtServiceTableAdapter
            // 
            this.dtServiceTableAdapter.ClearBeforeFill = true;
            // 
            // dtQuantityServicesTableAdapter
            // 
            this.dtQuantityServicesTableAdapter.ClearBeforeFill = true;
            // 
            // dtQuantityTotalServiceBindingSource
            // 
            this.dtQuantityTotalServiceBindingSource.DataMember = "DtQuantityTotalService";
            this.dtQuantityTotalServiceBindingSource.DataSource = this.dsService;
            // 
            // dtQuantityTotalServiceTableAdapter
            // 
            this.dtQuantityTotalServiceTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReportService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Atendimentos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReportService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtQuantityServicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtQuantityTotalServiceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dtServiceBindingSource;
        private DsService dsService;
        private System.Windows.Forms.BindingSource dtQuantityServicesBindingSource;
        private DtServiceTableAdapter dtServiceTableAdapter;
        private dtQuantityServicesTableAdapter dtQuantityServicesTableAdapter;
        private System.Windows.Forms.BindingSource dtQuantityTotalServiceBindingSource;
        private DtQuantityTotalServiceTableAdapter dtQuantityTotalServiceTableAdapter;
    }
}