using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Hospital_Appointment_System
{
    public partial class frmAppointmentList : Form
    {
        public frmAppointmentList()
        {
            InitializeComponent();
        }
        sqlConnection cnnctn = new sqlConnection();
        private void frmAppointmentList_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select appointmentID as 'ID', appointmentDATE as 'Tarih',appointmentTime as 'Saat',appointmentBranch as 'Brans',appointmentDoctor as 'Doktor',appointmentActive as 'Durum' From tbl_Appointments", cnnctn.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
