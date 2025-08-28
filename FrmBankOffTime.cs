using System.Windows.Forms;

namespace Interface
{
    public partial class FrmBankOffTime : Form
    {
        public FrmBankOffTime()
        {
            InitializeComponent();
        }

        private void FuncionárioToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FrmEmployees frnEmploees = new FrmEmployees();
            frnEmploees.ShowDialog();
        }

        private void FrmBankOffTime_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void atendimentoToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            new FrmServicesPerformed().ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new FrmBackupAndRestore().ShowDialog();
        }

        private void ajustarToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new FrmSetting().ShowDialog();
        }
    }
}
