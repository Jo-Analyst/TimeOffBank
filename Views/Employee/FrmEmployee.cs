using Interface.Properties;
using DataBase;
using System;
using System.Data;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmEmployee : Form
    {

        int page = 1, pageMaximum = 1;

        public FrmEmployee()
        {
            InitializeComponent();
        }


        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            FrmSaveEmployee frmSaveEmployee = new FrmSaveEmployee();
            frmSaveEmployee.ShowDialog();
            if (frmSaveEmployee.isSaved)
            {
                FrmEmployees_Load(sender, e);
                LoadEvents();
            }
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
            LoadEmployees();
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
                btnArrowLeft.Image = Resources.left_arrow_white;

            }

            EnabledBtnArrowLeft();
            LoadEmployees();
        }

        private void DisabledBtnArrowLeft()
        {
            btnArrowLeft.Enabled = false;
            btnArrowLeft.Image = Resources.left_arrow_grey;
        }

        private void DisabledBtnArrowRight()
        {
            btnArrowRight.Enabled = false;
            btnArrowRight.Image = Resources.right_arrow_grey;
        }

        private void EnabledBtnArrowLeft()
        {
            btnArrowLeft.Enabled = true;
            btnArrowLeft.Image = Resources.left_arrow_white;
        }

        private void EnabledBtnArrowRight()
        {
            btnArrowRight.Enabled = true;
            btnArrowRight.Image = Resources.right_arrow_white;
        }

        private void FrmEmployees_Load(object sender, EventArgs e)
        {
            cbPage.Text = "1";
            cbRows.Text = "10";
            LoadEvents();
            this.cbRows.SelectedIndexChanged += cbRows_SelectedIndexChanged;
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.cbPage_SelectedIndexChanged);
        }

        private void CheckNumberOfPages(int numberRows)
        {
            PageData.quantityRowsSelected = numberRows;
            pageMaximum = string.IsNullOrWhiteSpace(txtName.Text) ? PageData.SetPageQuantityEmployees() : PageData.SetPageQuantityEmployeesByName(txtName.Text);

            if (pageMaximum > 1)
                EnabledBtnArrowRight();

        }

        private void LoadEmployees()
        {
            try
            {
                dgvUsers.Rows.Clear();

                int quantRows = int.Parse(cbRows.Text);
                int pageSelected = (page - 1) * quantRows;

                DataTable dtEmployees = string.IsNullOrWhiteSpace(txtName.Text) ? Employee.FindAll(pageSelected, quantRows) : Employee.FindByName(txtName.Text.Trim(), pageSelected, quantRows);

                foreach (DataRow Employee in dtEmployees.Rows)
                {
                    int index = dgvUsers.Rows.Add();
                    dgvUsers.Rows[index].Cells["ColADD"].Value = Resources.add_post;
                    dgvUsers.Rows[index].Cells["ColEdit"].Value = Resources.user_avatar;
                    dgvUsers.Rows[index].Cells["ColDelete"].Value = Resources.delete;
                    dgvUsers.Rows[index].Cells["ColId"].Value = Employee["id"].ToString();
                    dgvUsers.Rows[index].Cells["ColName"].Value = Employee["name"].ToString();
                    dgvUsers.Rows[index].Cells["ColCPF"].Value = string.IsNullOrEmpty(Employee["CPF"].ToString()) ? "" : Security.Dry(Employee["CPF"].ToString());
                    dgvUsers.Rows[index].Cells["ColAddress"].Value = Employee["Address"].ToString();
                    dgvUsers.Rows[index].Cells["ColPhone"].Value = Employee["phone"].ToString();
                    dgvUsers.Rows[index].Height = 45;
                }

                UpdateEmployeeDescription();
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateEmployeeDescription()
        {
            lblDescriptionRow.Text = $"Exibindo {dgvUsers.Rows.Count} de {PageData.quantity} Funcionários cadastrados";
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

        private void FrmEmployees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
                btnNewEmployee_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.Right && btnArrowRight.Enabled) btnArrowRight_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.Left && btnArrowLeft.Enabled) btnArrowLeft_Click(sender, e);
        }

        private void LoadEvents()
        {
            CheckNumberOfPages(int.Parse(cbRows.Text));
            UpdateComboBoxItems();
            LoadEmployees();
            UpdateEmployeeDescription();
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

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = int.Parse(cbPage.Text);
            if (pageMaximum == 1) return;

            LoadEmployees();

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

        private void dgvUsers_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvUsers.Cursor = e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 ? Cursors.Hand : Cursors.Arrow;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            bool isConfirmed = false;

            if (e.RowIndex == -1) return;

            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["ColId"].Value);
            string name = dgvUsers.CurrentRow.Cells["ColName"].Value.ToString();
            string CPF = dgvUsers.CurrentRow.Cells["ColCpf"].Value.ToString();
            string address = dgvUsers.CurrentRow.Cells["ColAddress"].Value.ToString();
            string phone = dgvUsers.CurrentRow.Cells["ColPhone"].Value.ToString();

            if (dgvUsers.CurrentCell.ColumnIndex == 0)
            {
                new FrmCustomerService(id, name).ShowDialog();
            }
            else if (dgvUsers.CurrentCell.ColumnIndex == 1)
            {

                FrmSaveEmployee frmEmployee = new FrmSaveEmployee(id, name, CPF, phone, address);
                frmEmployee.ShowDialog();
                if (frmEmployee.isSaved)
                    isConfirmed = true;
            }
            else if (dgvUsers.CurrentCell.ColumnIndex == 2)
            {
                DialogResult dr = MessageBox.Show($"Deseja mesmo excluir o(a) Funcionário(a) {name} do sistema?", "Central Serviços", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        Employee.Delete(id);
                        isConfirmed = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Houve um erro no sistema. Tente novamente", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (isConfirmed) LoadEvents();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            LoadEvents();
            if (pageMaximum == 1)
            {
                DisabledBtnArrowLeft();
                DisabledBtnArrowRight();
            }
        }
    }
}