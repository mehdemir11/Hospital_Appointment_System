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
    public partial class frmDoctorDetails : Form
    {
        public frmDoctorDetails()
        {
            InitializeComponent();
        }
        sqlConnection cnnctn = new sqlConnection();
        public string IDNO;
        private void frmDoctorDetails_Load(object sender, EventArgs e)
        {
            lblIDNO.Text = IDNO;

            //FULLNAME
            SqlCommand cmd = new SqlCommand("Select doctorNAME,doctorSECNAME from tbl_Doctors where doctorIDNO=@d1", cnnctn.connection());
            cmd.Parameters.AddWithValue("@d1", lblIDNO.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblFullName.Text = dr[0] + " " + dr[1];
            }
            cnnctn.connection().Close();

            //APPOINTMENTS
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_Appointments where appointmentDoctor='" + lblFullName.Text + "'", cnnctn.connection());
            da.Fill(dt);
            dataGridView1.DataSource=dt;
        }

        private void btnUpdInfo_Click(object sender, EventArgs e)
        {
            frmDoctorUpdateInfo frm = new frmDoctorUpdateInfo();
            frm.IDNO = lblIDNO.Text;
            frm.Show();
        }

        private void btnAnnouncements_Click(object sender, EventArgs e)
        {
            frmAnnouncements frm = new frmAnnouncements();
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;
            rchComplaint.Text = dataGridView1.Rows[chosen].Cells[7].Value.ToString();
        }
    }
}
