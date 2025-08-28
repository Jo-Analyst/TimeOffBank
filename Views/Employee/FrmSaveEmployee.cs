using DataBase;
using System;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmSaveEmployee : Form
    {

        public bool isSaved { get; set; }
        bool isEditMode;
        int userId;
        public FrmSaveEmployee()
        {
            InitializeComponent();
        }

        public FrmSaveEmployee(int id, string name, string cpf, string phone, string address)
        {
            InitializeComponent();
            userId = id;
            txtName.Text = name;
            mkCPF.Text = cpf;
            mkPhone.Text = phone;
            txtAddress.Text = address;
            btnSave.Focus();
            isEditMode = true;
            this.btnSave.TabStop = true;

        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Insira o nome do Funcionário", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (mkCPF.MaskCompleted)
                {
                    if (!CPF.Validate(mkCPF.Text))
                    {
                        MessageBox.Show("CPF inválido", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    else if (Employee.FindByCpfForEmployee(Security.Cry(mkCPF.Text), userId).Rows.Count > 0)
                    {
                        MessageBox.Show("Este CPF já está cadastrado", "BANCO DE HORAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }


                int lastId = new Employee()
                {
                    id = userId,
                    name = txtName.Text.Trim(),
                    CPF = mkCPF.MaskCompleted ? Security.Cry(mkCPF.Text) : "",
                    address = txtAddress.Text.Trim(),
                    phone = mkPhone.MaskCompleted ? mkPhone.Text : "",
                }.Save();

                if (!isEditMode)
                {
                    new FrmCustomerService(lastId, txtName.Text).ShowDialog();
                    this.Visible = false;
                }

                isSaved = true;

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro no sistema ao cadastrar o Funcionário", "Notificação de aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmSaveUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave_Click(sender, e);
        }
    }
}
