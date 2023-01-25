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
    public partial class frmPatient : Form
    {
        public frmPatient()
        {
            InitializeComponent();
        }
        sqlConnection cnnctn = new sqlConnection();
        private void llRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPatientRegistration frm = new frmPatientRegistration();
            frm.Show();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Patients where patientIDNO=@p1 and patientPASSWORD=@p2", cnnctn.connection());
            cmd.Parameters.AddWithValue("@p1", mskdIDNO.Text);
            cmd.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                frmPatientDetails frm = new frmPatientDetails();
                frm.idno = mskdIDNO.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatali ID No veya Sifre.", "GIRIS ISLEMI BASARISIZ.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            cnnctn.connection().Close();
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {

        }
    }
}
