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
    public partial class frmPatientRegistration : Form
    {
        public frmPatientRegistration()
        {
            InitializeComponent();
        }

        sqlConnection cnnctn = new sqlConnection();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into tbl_Patients (patientNAME,patientSECNAME,patientIDNO,patientPHONE,patientPASSWORD,patientGENDER) values (@p1,@p2,@p3,@p4,@p5,@p6)", cnnctn.connection());
            cmd.Parameters.AddWithValue("@p1", txtName.Text);
            cmd.Parameters.AddWithValue("@p2", txtSecName.Text);
            cmd.Parameters.AddWithValue("@p3", mskdPhoneNum.Text);
            cmd.Parameters.AddWithValue("@p4", mskdIDNO.Text);
            cmd.Parameters.AddWithValue("@p5", cmbGender.Text);
            cmd.Parameters.AddWithValue("@p6", txtPassword.Text);
            cmd.ExecuteNonQuery();
            cnnctn.connection().Close();
            MessageBox.Show("Kaydiniz Basariyla Gerceklesmistir. Sifreniz : " + txtPassword.Text , "Islem Basarili. Saglikli Gunler Dileriz.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
