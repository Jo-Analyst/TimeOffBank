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
        double totalMinutes = 0f;
        bool isPrintDirect = bool.Parse(Settings.Default["print_directory_direct"].ToString());
        Service service = new Service();

        public FrmCustomerService(int userId, string name)
        {
            InitializeComponent();
            this.employeeId = userId;
            lblName.Text = name;
        }

        private void FrmCustomerService_Load(object sender, EventArgs e)
        {
            btnPrint.Text = isPrintDirect ? "Imprimir" : "Visualizar";
            dtEntryTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtDepartureTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dgvHistory.Focus();
            cbPage.Text = "1";
            cbRows.Text = "10";
            dtHoursTaken.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

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
            
            if (dtEntryTime.Value.ToShortTimeString() == dtDepartureTime.Value.ToShortTimeString())
            {
                MessageBox.Show("A hora de saída não pode ser igual a hora da entrada", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (dtHoursTaken.Value.ToShortTimeString() == "00:00" && cbAddHoursTaken.Checked)
            {
                MessageBox.Show("Defina a quantidade de horas que serão abatidas.", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (dtAbatementDate.Value <= dtDate.Value && cbAddHoursTaken.Checked)
            {
                MessageBox.Show("A data do abatimento das horas não pode ser menor ou igual a data do serviço prestado.", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                service.id = serviceId;
                service.description = rtDescription.Text.Trim();
                service.date = dtDate.Value;
                service.departureTime = dtDepartureTime.Value;
                service.entryTime = dtEntryTime.Value;
                service.numberOfOvertimeMinutes = totalMinutes;
                service.incrementTime = cbDefine.Checked;

                if (cbAddHoursTaken.Checked)
                {
                    service.abatementDate = dtAbatementDate.Value.ToShortDateString();
                    service.numberOfMinutesTaken = ConvertHoursToMinutes(dtHoursTaken.Value);
                }
                else
                {
                    service.abatementDate = null;
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
                    dgvHistory.Rows[index].Cells["ColEdit"].Value = Resources.edit;
                    dgvHistory.Rows[index].Cells["ColDelete"].Value = Resources.delete;
                    dgvHistory.Rows[index].Cells["ColId"].Value = dr["id"].ToString();
                    dgvHistory.Rows[index].Cells["ColDescription"].Value = dr["description"].ToString();
                    dgvHistory.Rows[index].Cells["ColDate"].Value = dr["date"].ToString();
                    dgvHistory.Rows[index].Cells["ColEntryTime"].Value = dr["entry_time"].ToString();
                    dgvHistory.Rows[index].Cells["ColDepartureTime"].Value = dr["departure_time"].ToString();
                    dgvHistory.Rows[index].Cells["ColNumberOfOvertimeHours"].Value = dr["number_of_overtime_hours"].ToString();
                    dgvHistory.Rows[index].Cells["ColOvertime"].Value = GetMinutesConvertedToHours(double.Parse(dr["number_of_overtime_hours"].ToString()));
                    dgvHistory.Rows[index].Cells["ColAbatementDate"].Value = dr["abatement_date"].ToString();
                    dgvHistory.Rows[index].Cells["ColMinutesTaken"].Value = dr["number_of_hours_taken"].ToString();
                    dgvHistory.Rows[index].Cells["ColNumberOfHoursTaken"].Value = !string.IsNullOrEmpty(dr["number_of_hours_taken"].ToString()) ? GetMinutesConvertedToHours((double)dr["number_of_hours_taken"]) : string.Empty;
                    dgvHistory.Rows[index].Cells["ColDayOffCompleted"].Value = dr["day_off_completed"].ToString() == "1" ? Resources.checked_checkbox_32 : Resources.rounded_square_32;
                    dgvHistory.Rows[index].Cells["ColDayOffCompletedValue"].Value = dr["day_off_completed"].ToString();
                    dgvHistory.Rows[index].Cells["ColIncrementTime"].Value = dr["increment_time"].ToString();
                    dgvHistory.Rows[index].Selected = false;
                    dgvHistory.Rows[index].Height = 45;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro no sistema. Tente novamente mais tarde", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TimeSpan ConvertMinutesToTimeSpan(double totalMinutes)
        {
            return TimeSpan.FromMinutes(totalMinutes);
        }

        private string GetMinutesConvertedToHours(double totalMinutes)
        {
            TimeSpan time = ConvertMinutesToTimeSpan(totalMinutes);
            return $"{time.Hours}h {time.Minutes}min";
        }

        (int hours, int minutes) GetHoursAndMinutesFromTimeSpan(TimeSpan timeSpan)
        {
            return (timeSpan.Hours, timeSpan.Minutes);
        }

        private int ConvertHoursToMinutes(DateTime dateTime)
        {
            TimeSpan time = dateTime.TimeOfDay;
            int minutes = (int)time.TotalMinutes;
            return minutes;
        }

        private void DgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            dgvHistory.CurrentRow.Selected = false;

            int id = Convert.ToInt32(dgvHistory.CurrentRow.Cells[3].Value);
            ClearFields();

            if (dgvHistory.CurrentCell.ColumnIndex == 0)
            {
                if (dgvHistory.CurrentRow.Cells["ColDayOffCompletedValue"].Value.ToString() == "1")
                {
                    MessageBox.Show("Não é possível editar um registro que o processo da folga esteja concluída.", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                serviceId = int.Parse(dgvHistory.CurrentRow.Cells["ColId"].Value.ToString());
                rtDescription.Text = dgvHistory.CurrentRow.Cells["ColDescription"].Value.ToString();
                dtDate.Value = DateTime.Parse(dgvHistory.CurrentRow.Cells["ColDate"].Value.ToString());
                dtEntryTime.Value = DateTime.Parse(dgvHistory.CurrentRow.Cells["ColEntryTime"].Value.ToString());
                dtDepartureTime.Value = DateTime.Parse(dgvHistory.CurrentRow.Cells["ColDepartureTime"].Value.ToString());
                lbNumberOfOvertimeHours.Text = GetMinutesConvertedToHours(double.Parse(dgvHistory.CurrentRow.Cells["ColNumberOfOvertimeHours"].Value.ToString()));
                cbDefine.Checked = dgvHistory.CurrentRow.Cells["ColIncrementTime"].Value.ToString() == "1" ? true : false;

                if (!string.IsNullOrEmpty(dgvHistory.CurrentRow.Cells["ColAbatementDate"].Value.ToString()))
                {
                    dtAbatementDate.Value = DateTime.Parse(dgvHistory.CurrentRow.Cells["ColAbatementDate"].Value.ToString());

                    (int hours, int minutes) = GetHoursAndMinutesFromTimeSpan(ConvertMinutesToTimeSpan(double.Parse(dgvHistory.CurrentRow.Cells["ColMinutesTaken"].Value.ToString())));

                    dtHoursTaken.Value = !string.IsNullOrEmpty(dgvHistory.CurrentRow.Cells["ColMinutesTaken"].Value.ToString()) ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minutes, 0) : new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    dtAbatementDate.Enabled = true;
                    dtHoursTaken.Enabled = true;
                    cbAddHoursTaken.Checked = true;
                }

                btnSave.Text = "Editar";
                lkCancel.Visible = true;
                cbDefine.Enabled = true;
                cbAddHoursTaken.Enabled = true;
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
                {
                    try
                    {
                        Service.ChangeDayOffCompleted(id, ToggleDayOffCompleted());
                        dgvHistory.CurrentRow.Cells["ColDayOffCompletedValue"].Value = ToggleDayOffCompleted();
                        dgvHistory.CurrentRow.Cells[2].Value = (string)dgvHistory.CurrentRow.Cells["ColDayOffCompletedValue"].Value == "1" ? Resources.checked_checkbox_32 : Resources.rounded_square_32;

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                    MessageBox.Show("Não foi definido a data da folga.", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string ToggleDayOffCompleted()
        {
            if (dgvHistory.CurrentRow.Cells["ColDayOffCompletedValue"].Value.ToString() == "1")
                return "0";
            else
                return "1";
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
            lblTotalHoursTaken.Text = GetMinutesConvertedToHours(Service.GetTotalHorasInOpen(employeeId));
            btnPrint.Enabled = dgvHistory.Rows.Count > 0; btnPrint.Enabled = dgvHistory.Rows.Count > 0;
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
            dtHoursTaken.Enabled = false;
            dtHoursTaken.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtEntryTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtDepartureTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            cbAddHoursTaken.Checked = false;
        }

        private void FrmCustomerService_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BtnSave_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.Right && btnArrowRight.Enabled) BtnArrowRight_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.Left && btnArrowLeft.Enabled) BtnArrowLeft_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.P && btnPrint.Enabled)
                btnPrint_Click(sender, e);
        }

        private void LkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearFields();
        }

        private void DisabledBtnArrowLeft()
        {
            btnArrowLeft.Enabled = false;
            btnArrowLeft.Image = Properties.Resources.left_arrow_grey;
        }

        private void CbAddHoursTaken(object sender, EventArgs e)
        {
            dtAbatementDate.Enabled = cbAddHoursTaken.Checked;
            dtHoursTaken.Enabled = cbAddHoursTaken.Checked;
        }

        private void dtEntryTime_ValueChanged(object sender, EventArgs e)
        {
            CalculateJourney();
        }

        private void dtDepartureTime_ValueChanged(object sender, EventArgs e)
        {
            CalculateJourney();
        }

        private void CalculateJourney()
        {
            double timeIncrement = cbDefine.Checked ? 1.5 : 1;
            if (dtEntryTime.Value > dtDepartureTime.Value)
            {
                lbNumberOfOvertimeHours.Text = "0h 0min";
                return;
            }

            // Horário de entrada e saída
            DateTime checkInTime = dtEntryTime.Value;
            DateTime CheckOutTime = dtDepartureTime.Value;

            // Calcula a duração da jornada
            TimeSpan journey = CheckOutTime - checkInTime;

            totalMinutes = journey.TotalMinutes * timeIncrement;
            TimeSpan adjustedJourney = TimeSpan.FromMinutes(totalMinutes);

            int hours = (int)adjustedJourney.TotalHours;
            int minutes = adjustedJourney.Minutes;

            lbNumberOfOvertimeHours.Text = $"{hours}h {minutes}min";

        }

        private void cbDefine_CheckedChanged(object sender, EventArgs e)
        {
            CalculateJourney();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtService = Service.FindByEmployeeId(employeeId);
            dtService.Columns.Add("overtime_hours", typeof(string));
            dtService.Columns.Add("hours_taken", typeof(string));
            dtService.Columns.Add("day_off", typeof(string));
            dtService = FormatWorkHoursData(dtService);

            if (isPrintDirect)
            {
                new PrintDirect().Execute(dtService, lblTotalHoursTaken.Text);
                return;
            }

            new FrmReportService(dtService, lblTotalHoursTaken.Text).ShowDialog();
        }

        private DataTable FormatWorkHoursData(DataTable dataTable)
        {

            foreach (DataRow row in dataTable.Rows)
            {
                row["overtime_hours"] = GetMinutesConvertedToHours(double.Parse(row["number_of_overtime_hours"].ToString()));
                row["hours_taken"] = !string.IsNullOrEmpty(row["number_of_hours_taken"].ToString()) ? GetMinutesConvertedToHours(double.Parse(row["number_of_hours_taken"].ToString())) : string.Empty;
                row["day_off"] = row["day_off_completed"].ToString() == "1" ? "file:///" + Application.StartupPath.Replace("\\", "/") + "/check.png" : null;
            }

            return dataTable;
        }

        private void dtHoursTaken_ValueChanged(object sender, EventArgs e)
        {

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