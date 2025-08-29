using DataBase;
using Interface.Properties;
using System;
using System.Data;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmCustomerService : Form
    {
        int employeeId; int page = 1, pageMaximum = 1, serviceId;
        public FrmCustomerService(int userId, string name)
        {
            InitializeComponent();
            this.employeeId = userId;
            lblName.Text = name;
        }

        private void FrmCustomerService_Load(object sender, EventArgs e)
        {
            dgvHistory.Focus();
            cbPage.Text = "1";
            cbRows.Text = "10";

            dtDate.MaxDate = DateTime.Now;

            LoadEvents();
            this.cbRows.SelectedIndexChanged += CbRows_SelectedIndexChanged;
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.CbPage_SelectedIndexChanged);
            btnArrowLeft.Image = Resources.left_arrow_grey;
            btnArrowLeft.Visible = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool isValid = !string.IsNullOrWhiteSpace(rtDescription.Text);

            if (!isValid)
            {
                MessageBox.Show("Descreva o motivo.", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (dtEntryTime.Value > dtDepartureTime.Value)
            {
                MessageBox.Show("A hora de saída não pode ser menor que a hora da entrada", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (dtEntryTime.Value.ToShortTimeString() == dtDepartureTime.Value.ToShortTimeString())
            {
                MessageBox.Show("A hora de saída não pode ser igual a hora da entrada", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Service service = new Service();
            try
            {
                service.id = serviceId;
                service.description = rtDescription.Text.Trim();
                service.date = dtDate.Value;
                service.departureTime = dtDepartureTime.Value;
                service.entryTime = dtEntryTime.Value;
                service.numberOfOvertimeHours = 0;
             
                if (cbAddHoursTaken.Checked)
                {
                    service.abatementDate = dtAbatementDate.Value.ToShortDateString();
                    service.numberOfHoursTaken = int.Parse(ndNumberOfHoursTaken.Value.ToString());
                }
             
                service.dayOffCompleted = false;
                service.employeesId = employeeId;

                service.Save();
                LoadEvents();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadDgvHistory()
        {
            try
            {
                dgvHistory.Rows.Clear();

                int quantRows = int.Parse(cbRows.Text);
                int pageSelected = (page - 1) * quantRows;

                DataTable services = Service.FindByEmployeeId(employeeId, pageSelected, quantRows);

                foreach (DataRow dr in services.Rows)
                {
                    int index = dgvHistory.Rows.Add();
                    dgvHistory.Rows[index].Cells["ColEdit"].Value = Properties.Resources.edit;
                    dgvHistory.Rows[index].Cells["ColDelete"].Value = Properties.Resources.delete;
                    dgvHistory.Rows[index].Cells["ColId"].Value = dr["id"].ToString();
                    dgvHistory.Rows[index].Cells["ColDescription"].Value = dr["description"].ToString();
                    dgvHistory.Rows[index].Cells["ColDate"].Value = dr["date"].ToString();
                    dgvHistory.Rows[index].Cells["ColEntryTime"].Value = dr["entry_time"].ToString();
                    dgvHistory.Rows[index].Cells["ColDepartureTime"].Value = dr["departure_time"].ToString();
                    dgvHistory.Rows[index].Cells["ColNumberOfOvertimeHours"].Value = dr["number_of_overtime_hours"].ToString();
                    dgvHistory.Rows[index].Cells["ColAbatementDate"].Value = dr["abatement_date"].ToString();
                    dgvHistory.Rows[index].Cells["ColNumberOfHoursTaken"].Value = dr["number_of_hours_taken"].ToString();
                    dgvHistory.Rows[index].Cells["ColDayOffCompleted"].Value = dr["day_off_completed"].ToString() == "1" ? Properties.Resources.checked_checkbox_32 : Resources.rounded_square_32;
                    dgvHistory.Rows[index].Cells["ColDayOffCompletedValue"].Value = dr["day_off_completed"].ToString();
                    dgvHistory.Rows[index].Selected = false;
                    dgvHistory.Rows[index].Height = 45;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro no sistema. Tente novamente mais tarde", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            dgvHistory.CurrentRow.Selected = false;

            int id = Convert.ToInt32(dgvHistory.CurrentRow.Cells[3].Value);
            if (dgvHistory.CurrentCell.ColumnIndex == 0)
            {
                ClearFields();
                serviceId = int.Parse(dgvHistory.CurrentRow.Cells["ColId"].Value.ToString());
                rtDescription.Text = dgvHistory.CurrentRow.Cells["ColDescription"].Value.ToString();
                dtDate.Value = DateTime.Parse(dgvHistory.CurrentRow.Cells["ColDate"].Value.ToString());
                dtEntryTime.Value = DateTime.Parse(dgvHistory.CurrentRow.Cells["ColEntryTime"].Value.ToString());
                dtDepartureTime.Value =DateTime.Parse(dgvHistory.CurrentRow.Cells["ColDepartureTime"].Value.ToString());
                lbNumberOfOvertimeHours.Text = dgvHistory.CurrentRow.Cells["ColNumberOfOvertimeHours"].Value.ToString();

                if (!string.IsNullOrEmpty(dgvHistory.CurrentRow.Cells["ColAbatementDate"].Value.ToString()))
                {
                    dtAbatementDate.Value = DateTime.Parse(dgvHistory.CurrentRow.Cells["ColAbatementDate"].Value.ToString());
                    ndNumberOfHoursTaken.Value = int.Parse(dgvHistory.CurrentRow.Cells["ColNumberOfHoursTaken"].Value.ToString());
                    dtAbatementDate.Enabled = true;
                    ndNumberOfHoursTaken.Enabled = true;
                    cbAddHoursTaken.Checked = true;
                }

                btnSave.Text = "Editar";
                lkCancel.Visible = true;
                cbDefine.Enabled = true;
                cbAddHoursTaken.Enabled = true;

                if (dgvHistory.CurrentRow.Cells["ColDepartureTime"].Value.ToString() == "---")
                {
                    CbDefine_CheckedChanged(sender, e);
                }
                else
                {
                    dtDepartureTime.Enabled = true;
                    cbDefine.Checked = true;
                }

            }

            if (dgvHistory.CurrentCell.ColumnIndex == 1)
            {
                DialogResult dr = MessageBox.Show($"Deseja mesmo excluir?", "BANCO DE HORAS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        Service.Delete(id);
                        ClearFields();
                        LoadEvents();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


            if (dgvHistory.CurrentCell.ColumnIndex == 2)
            {
                if (!string.IsNullOrEmpty(dgvHistory.CurrentRow.Cells["ColAbatementDate"].Value.ToString()))
                    dgvHistory.CurrentRow.Cells[2].Value = dgvHistory.CurrentRow.Cells["ColDayOffCompletedValue"].Value.ToString() == "0" ? Resources.checked_checkbox_32 : Resources.rounded_square_32;
                else
                    MessageBox.Show("Não foi definido a data da folga.", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool ToggleCheckbox()
        {
            bool isChecked = false;
            return !isChecked;
        }

        private void CbRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEvents();
            if (page == pageMaximum)
            {
                DisabledBtnArrowLeft();
                DisabledBtnArrowRight();
            }
        }

        private void CbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = int.Parse(cbPage.Text);
            if (pageMaximum == 1) return;

            LoadDgvHistory();

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

        private void LoadEvents()
        {
            CheckNumberOfPages(int.Parse(cbRows.SelectedItem.ToString()));
            UpdateComboBoxItems();
            LoadDgvHistory();

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

        private void CheckNumberOfPages(int numberRows)
        {
            PageData.quantityRowsSelected = numberRows;
            pageMaximum = PageData.SetPageQuantityServices(employeeId);
            if (pageMaximum > 1)
                EnabledBtnArrowRight();

        }

        private void BtnArrowRight_Click(object sender, EventArgs e)
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
            dgvHistory.Focus();
            LoadDgvHistory();
        }

        private void EnabledBtnArrowLeft()
        {
            btnArrowLeft.Enabled = true;
            btnArrowLeft.Image = Properties.Resources.left_arrow_white;
        }

        private void DisabledBtnArrowRight()
        {
            btnArrowRight.Enabled = false;
            btnArrowRight.Image = Properties.Resources.right_arrow_grey;
        }

        private void BtnArrowLeft_Click(object sender, EventArgs e)
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

            dgvHistory.Focus();
            LoadDgvHistory();
        }

        private void ClearFields()
        {
            serviceId = 0;
            btnSave.Text = "Salvar";
            rtDescription.Clear();
            dtDate.MaxDate = DateTime.Now;
            dtDate.Value = dtDate.MaxDate;
            dtEntryTime.Value = DateTime.Now;
            dtDepartureTime.Value = DateTime.Now;
            lkCancel.Visible = false;
            cbDefine.Checked = false;
            dtAbatementDate.Enabled = false;
            dtAbatementDate.Value = DateTime.Now;
            ndNumberOfHoursTaken.Enabled = false;
            ndNumberOfHoursTaken.Value = 1;
            cbAddHoursTaken.Checked = false;
        }

        private void FrmCustomerService_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnSave_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.Right && btnArrowRight.Enabled) BtnArrowRight_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.Left && btnArrowLeft.Enabled) BtnArrowLeft_Click(sender, e);
        }

        private void LkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearFields();
        }

        private void CbDefine_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void DisabledBtnArrowLeft()
        {
            btnArrowLeft.Enabled = false;
            btnArrowLeft.Image = Properties.Resources.left_arrow_grey;
        }

        private void CbAddHoursTaken(object sender, EventArgs e)
        {
            dtAbatementDate.Enabled = cbAddHoursTaken.Checked;
            ndNumberOfHoursTaken.Enabled = cbAddHoursTaken.Checked;
        }

        private void DgvHistory_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvHistory.Cursor = e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 ? Cursors.Hand : Cursors.Arrow;
        }

        private void EnabledBtnArrowRight()
        {
            btnArrowRight.Enabled = true;
            btnArrowRight.Image = Properties.Resources.right_arrow_white;
        }
    }
}