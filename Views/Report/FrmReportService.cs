using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmReportService : Form
    {
        String date, totalHours;
        dynamic dtService;
        public FrmReportService(DataTable dt, string totalHours)
        {
            InitializeComponent();
            dtService = dt;
            this.totalHours = totalHours;
        }

        private void FrmReportService_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("dsService", dtService);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.SetParameters(new ReportParameter("TotalHours", totalHours));
            reportViewer1.LocalReport.ReportEmbeddedResource = "Interface.Views.Report.Data.Banca de horas.rdlc";
            reportViewer1.RefreshReport();
        }
    }
}
