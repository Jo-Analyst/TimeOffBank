//using DataBase;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Interface
//{
//    public partial class FrmService : Form
//    {    
//        public int id { get; set; }
//        public string description { get; set; }
//        public DateTime dateService { get; set; }
//        public string timeOfService { get; set; }
//        public string departureTime { get; set; }
//        public int userId { get; set; }
//        public bool thereWasEdition { get; set; }
//        Service service = new Service();
        
//        public FrmService(int personId, string name)
//        {
//            InitializeComponent();

//            this.userId = personId;
//        } 
        
//        public FrmService(int id, string description, DateTime dateService, int personId, string timeOfService, string departureTime)
//        {
//            InitializeComponent();

//            this.userId = personId;
//            rtDescription.Text = description;
//            dtDateService.Value = dateService;
//            dtTimeOfService.Value = !string.IsNullOrEmpty(timeOfService)? DateTime.Parse(timeOfService) : DateTime.Now;
//            dtDepartureTime.Value = !string.IsNullOrEmpty(departureTime) ? DateTime.Parse(departureTime) : DateTime.Now;
//            this.id = id;
//        }


//        private void btnADD_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(rtDescription.Text))
//            {
//                MessageBox.Show("Faça a descrição do atendimento", "TIME-BANK OFF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//                return;
            
//            }

//            if(dtTimeOfService.Value > dtDepartureTime.Value)
//            {
//                MessageBox.Show("A hora de saída não pode ser menor que a hora do atendimento", "TIME-BANK OFF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//                return;
//            }
//            else if (dtTimeOfService.Value == dtDepartureTime.Value)
//            {
//                MessageBox.Show("A hora de saída não pode ser igual a hora do atendimento", "TIME-BANK OFF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//                return;
//            }

//            service.id = id;
//            service.description = rtDescription.Text;
//            service.dateService = dtDateService.Value;  
//            service.timeOfService = dtTimeOfService.Value.ToLongTimeString();
//            service.departureTime = dtDepartureTime.Value.ToLongTimeString();
//            service.userId = userId;

//            service.Save();

//            description = rtDescription.Text;
//            dateService = dtDateService.Value;
//            id = service.id;
//            timeOfService = dtTimeOfService.Value.ToLongTimeString();
//            departureTime = dtDepartureTime.Value.ToLongTimeString();
//            thereWasEdition = true;

//           Close();
//        }

//        private void FrmService_Load(object sender, EventArgs e)
//        {
//           dtDateService.MaxDate = DateTime.Now;
//        }
//    }
//}
