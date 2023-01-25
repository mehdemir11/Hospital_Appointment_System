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
    public partial class frmPatientUpdateInformation : Form
    {
        public frmPatientUpdateInformation()
        {
            InitializeComponent();
        }
        public string IDno;
        sqlConnection cnnctn = new sqlConnection();
        private void frmPatientUpdateInformation_Load(object sender, EventArgs e)
        {
            mskdIDNO.Text = IDno;
            SqlCommand cmd = new SqlCommand("Select * From tbl_Patients where patientIDNO=@p1", cnnctn.connection());
            cmd.Parameters.AddWithValue("@p1", mskdIDNO.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtName.Text = dr[1].ToString();
                txtSecName.Text = dr[2].ToString();
                mskdPhoneNum.Text = dr[4].ToString();
                txtPassword.Text = dr[5].ToString();
                cmbGender.Text = dr[6].ToString();
            }
            cnnctn.connection().Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Update tbl_Patients set patientNAME=@p1,patientSECNAME=@p2,patientPHONE=@p3,patientGENDER=@p4,patientPASSWORD=@p5 where patientIDNO=@p6", cnnctn.connection());
            cmd2.Parameters.AddWithValue("@p1", txtName.Text);
            cmd2.Parameters.AddWithValue("@p2", txtSecName.Text);
            cmd2.Parameters.AddWithValue("@p3", mskdPhoneNum.Text);
            cmd2.Parameters.AddWithValue("@p4", cmbGender.Text);
            cmd2.Parameters.AddWithValue("@p5", txtPassword.Text);
            cmd2.Parameters.AddWithValue("@p6", mskdIDNO.Text);
            cmd2.ExecuteNonQuery();
            cnnctn.connection().Close();
            MessageBox.Show("Bilgi Guncelleme Islemi Basariyla Gerceklestirilmistir.", "ISLEM BASARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
