using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmReportService : Form
    {
        String date;
        public FrmReportService(string date)
        {
            InitializeComponent();
            this.date = date;
        }

        private void FrmReportService_Load(object sender, EventArgs e)
        {
            this.dtQuantityTotalServiceTableAdapter.Fill(dsService.DtQuantityTotalService, date);
            this.dtServiceTableAdapter.Fill(dsService.DtService, date);
            this.dtQuantityServicesTableAdapter.Fill(dsService.dtQuantityServices, date);
            this.reportViewer1.RefreshReport();
        }
    }
}
