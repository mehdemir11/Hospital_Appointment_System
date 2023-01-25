using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Appointment_System
{
    public partial class frmAnaForm : Form
    {
        public frmAnaForm()
        {
            InitializeComponent();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            frmPatient frm = new frmPatient();
            frm.Show();
            this.Hide();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            frmDoctor frm1 = new frmDoctor();
            frm1.Show();
            this.Hide();
        }

        private void btnAsistant_Click(object sender, EventArgs e)
        {
            frmAsistants frm2 = new frmAsistants();
            frm2.Show();
            this.Hide();
        }
    }
}
