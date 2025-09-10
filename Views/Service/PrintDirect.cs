using Microsoft.Reporting.WinForms;
using System.Data;

namespace Interface
{
    public class PrintDirect
    {
        public void Execute(DataTable dtService, string totalHours)
        {
            ReportDataSource reportDataSource = new ReportDataSource("dsService", dtService);
            LocalReport localReport = new LocalReport();
            localReport.DataSources.Clear();
            localReport.DataSources.Add(reportDataSource);
            localReport.EnableExternalImages = true;
            localReport.ReportEmbeddedResource = "Interface.Views.Report.Data.Banco de horas.rdlc";
            localReport.SetParameters(new ReportParameter("TotalHours", totalHours));
            localReport.PrintToPrinter();
        }
    }
}