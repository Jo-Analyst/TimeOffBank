using Interface.Properties;
using Interface.Views.Report;
using Interface.Views.Report.Data;
using Interface.Views.Report.Data.DsServiceTableAdapters;
using DataBase;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interface
{
    public partial class FrmServicesPerformed : Form
    {
        string month;
        int page = 1, pageMaximum = 1;
        bool isPrintDirect = bool.Parse(Settings.Default["print_directory_direct"].ToString());

        public FrmServicesPerformed()
        {
            InitializeComponent();
        }

        private void FrmServicesPerformed_Load(object sender, EventArgs e)
        {
            btnPrint.Text = isPrintDirect ? "Imprimir" : "Visualizar";

            for (int i = DateTime.Now.Year; i >= 2023; i--)
            {
                cbYear.Items.Add(i.ToString());
            }

            cbYear.SelectedIndex = 0;
            cbMonth.SelectedIndex = 0;
            cbPage.Text = "1";
            cbRows.Text = "10";
            LoadEvents();
            this.cbRows.SelectedIndexChanged += cbRows_SelectedIndexChanged;
            this.cbPage.SelectedIndexChanged += new EventHandler(this.cbPage_SelectedIndexChanged);
            this.cbYear.SelectedIndexChanged += new EventHandler(this.cbYear_SelectedIndexChanged);
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
        }

        private void cbRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEvents();
            if (page == pageMaximum)
            {
                DisabledBtnArrowLeft();
                DisabledBtnArrowRight();
            }
        }

        private void LoadEvents()
        {
            CheckNumberOfPages(int.Parse(cbRows.SelectedItem.ToString()));
            UpdateComboBoxItems();
            LoadData();
            btnPrint.Enabled = dgvData.Rows.Count > 0;
        }

        private void UpdateComboBoxItems()
        {
            cbPage.Items.Clear();
            for (int i = 1; i <= pageMaximum; i++)
            {
                cbPage.Items.Add(i);
            }

            cbPage.Text = (page > pageMaximum ? pageMaximum : page).ToString();
        }

        private void LoadData()
        {
            try
            {
                dgvData.Rows.Clear();

                int quantRows = int.Parse(cbRows.Text);
                int pageSelected = (page - 1) * quantRows;

                DataTable dtEntranceDoor = cbMonth.SelectedIndex > 0 ? Service.FindByYearAndMonth(int.Parse(cbYear.Text), month, pageSelected, quantRows) : Service.FindByYear(int.Parse(cbYear.Text), pageSelected, quantRows);

                foreach (DataRow dr in dtEntranceDoor.Rows)
                {
                    int i = dgvData.Rows.Add();
                    dgvData.Rows[i].Cells["ColDate"].Value = dr["date_service"].ToString();
                    dgvData.Rows[i].Cells["ColDescription"].Value = dr["description"].ToString();
                    dgvData.Rows[i].Cells["ColNameUser"].Value = dr["name"].ToString();
                    dgvData.Rows[i].Cells["ColDescription"].Value = dr["description"].ToString();
                    dgvData.Rows[i].Cells["ColTimeOfService"].Value = dr["time_of_service"].ToString() == string.Empty ? "---" : dr["time_of_service"].ToString();
                    dgvData.Rows[i].Cells["ColDepartureTime"].Value = dr["departure_time"].ToString() == string.Empty ? "---" : dr["departure_time"].ToString();
                    dgvData.Rows[i].Cells["ColSector"].Value = dr["sector"].ToString();

                    dgvData.Rows[i].Height = 45;
                    dgvData.Rows[i].Selected = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GetMonthByIndex()
        {
            switch (cbMonth.SelectedIndex)
            {
                case 1:
                    month = "01"; break;
                case 2:
                    month = "02"; break;
                case 3:
                    month = "03"; break;
                case 4:
                    month = "04"; break;
                case 5:
                    month = "05"; break;
                case 6:
                    month = "06"; break;
                case 7:
                    month = "07"; break;
                case 8:
                    month = "08"; break;
                case 9:
                    month = "09"; break;
                case 10:
                    month = "10"; break;
                case 11:
                    month = "11"; break;
                case 12:
                    month = "12"; break;
                default:
                    month = string.Empty; break;
            }
        }

        private void dgvReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvData.CurrentRow.Selected = false;
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMonthByIndex();
            LoadEvents();
            DisabledButtonPages();
        }

        private void DisabledButtonPages()
        {
            if (pageMaximum <= 1)
            {
                DisabledBtnArrowLeft();
                DisabledBtnArrowRight();
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEvents();
            DisabledButtonPages();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
               isPrintDirect =  bool.Parse(Settings.Default["print_directory_direct"].ToString());

                if (isPrintDirect)
                {
                    PrintReport();
                }
                else
                {
                new FrmReportService(cbMonth.SelectedIndex == 0 ? $"%{cbYear.Text}%" : $"%{GetSelectedMonthDescription()}/{cbYear.Text}%").ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Houve um erro ao tentar imprimir o relatório. Detalhes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReport()
        {
            DtServiceTableAdapter dtServiceTableAdapter = new DtServiceTableAdapter();
            dtQuantityServicesTableAdapter dtQuantityServicesTableAdapter = new dtQuantityServicesTableAdapter();
            DtQuantityTotalServiceTableAdapter dtQuantityTotalServiceTableAdapter = new DtQuantityTotalServiceTableAdapter();
            DsService dsService = new DsService();

            dtServiceTableAdapter.Fill(dsService.DtService, cbMonth.SelectedIndex == 0 ? $"%{cbYear.Text}%" : $"%{GetSelectedMonthDescription()}/{cbYear.Text}%");
            dtQuantityServicesTableAdapter.Fill(dsService.dtQuantityServices, cbMonth.SelectedIndex == 0 ? $"%{cbYear.Text}%" : $"%{GetSelectedMonthDescription()}/{cbYear.Text}%");
            dtQuantityTotalServiceTableAdapter.Fill(dsService.DtQuantityTotalService, cbMonth.SelectedIndex == 0 ? $"%{cbYear.Text}%" : $"%{GetSelectedMonthDescription()}/{cbYear.Text}%");

            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "Interface.Views.Report.Relatório do Atendimento Diário.rdlc";
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("dsService", (DataTable)dsService.DtService));
            localReport.DataSources.Add(new ReportDataSource("dsQuantityServices", (DataTable)dsService.dtQuantityServices));
            localReport.DataSources.Add(new ReportDataSource("dsQuantityTotalServices", (DataTable)dsService.DtQuantityTotalService));
            localReport.PrintToPrinter();
        }

        private void FrmServicePerfomed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P && btnPrint.Enabled)
                btnPrint_Click(sender, e);
        }

        private string GetSelectedMonthDescription()
        {
            switch (cbMonth.SelectedIndex)
            {
                case 1:
                    return "01";
                case 2:
                    return "02";
                case 3:
                    return "03";
                case 4:
                    return "04";
                case 5:
                    return "05";
                case 6:
                    return "06";
                case 7:
                    return "07";
                case 8:
                    return "08";
                case 9:
                    return "09";
                case 10:
                    return "10";
                case 11:
                    return "11";
                case 12:
                    return "12";
                default:
                    return string.Empty;
            }

        }

        private void CheckNumberOfPages(int numberRows)
        {
            PageData.quantityRowsSelected = numberRows;
            pageMaximum = PageData.SetPageQuantityServicesByDate(cbMonth.SelectedIndex == 0 ? cbYear.Text : $"{month}/{cbYear.SelectedItem.ToString()}");
            if (pageMaximum > 1)
                EnabledBtnArrowRight();

        }

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = int.Parse(cbPage.Text);
            if (pageMaximum == 1) return;

            LoadData();

            if (page == 1)
            {
                DisabledBtnArrowLeft();
                EnabledBtnArrowRight();
            }
            else if (page == pageMaximum)
            {
                DisabledBtnArrowRight();
                EnabledBtnArrowLeft();
            }

            else
            {
                EnabledBtnArrowLeft();
                EnabledBtnArrowRight();
            }
        }

        private void DisabledBtnArrowLeft()
        {
            btnArrowLeft.Enabled = false;
            btnArrowLeft.Image = Properties.Resources.left_arrow_grey;
        }

        private void EnabledBtnArrowRight()
        {
            btnArrowRight.Enabled = true;
            btnArrowRight.Image = Properties.Resources.right_arrow_white;
        }

        private void EnabledBtnArrowLeft()
        {
            btnArrowLeft.Enabled = true;
            btnArrowLeft.Image = Properties.Resources.left_arrow_white;
        }

        private void btnArrowLeft_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
            }

            cbPage.Text = page.ToString();

            if (page == 1)
            {
                DisabledBtnArrowLeft();
                EnabledBtnArrowRight();
            }
            else
            {
                EnabledBtnArrowLeft();
            }

            dgvData.Focus();
            LoadData();
        }

        private void btnArrowRight_Click(object sender, EventArgs e)
        {
            if (page < pageMaximum)
            {
                page++;
            }

            cbPage.Text = page.ToString();

            if (page == pageMaximum)
            {

                DisabledBtnArrowRight();

            }

            else
            {
                btnArrowLeft.Enabled = true;
                btnArrowLeft.Image = Properties.Resources.left_arrow_white;

            }

            EnabledBtnArrowLeft();
            dgvData.Focus();
            LoadData();
        }

        private void DisabledBtnArrowRight()
        {
            btnArrowRight.Enabled = false;
            btnArrowRight.Image = Properties.Resources.right_arrow_grey;
        }
    }
}