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
    public partial class frmDoctorUpdateInfo : Form
    {
        public frmDoctorUpdateInfo()
        {
            InitializeComponent();
        }
        sqlConnection cnnctn = new sqlConnection();
        public string IDNO;
        private void frmDoctorUpdateInfo_Load(object sender, EventArgs e)
        {
            mskdID.Text = IDNO;

            SqlCommand cmd = new SqlCommand("Select * from tbl_Doctors where doctorIDNO=@d1", cnnctn.connection());
            cmd.Parameters.AddWithValue("@d1", mskdID.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtName.Text = dr[1].ToString();
                txtSecName.Text = dr[2].ToString();
                cmbBranch.Text = dr[3].ToString();
                txtPassword.Text = dr[5].ToString();
            }
            cnnctn.connection().Close();
            //MessageBox.Show("Bilgi Guncelleme Islemi Basariyla Gerceklestirilmistir.", "ISLEM BASARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update tbl_Doctors set doctorNAME=@d1,doctorSECNAME=@d2,doctorBRANCH=@d3,doctorPASSWORD=@d4 where doctorIDNO=@d5", cnnctn.connection());
            cmd.Parameters.AddWithValue("@d1", txtName.Text);
            cmd.Parameters.AddWithValue("@d2", txtSecName.Text);
            cmd.Parameters.AddWithValue("@d3", cmbBranch.Text);
            cmd.Parameters.AddWithValue("@d4", txtPassword.Text);
            cmd.Parameters.AddWithValue("@d5", mskdID.Text);
            cmd.ExecuteNonQuery();
            cnnctn.connection().Close();
            MessageBox.Show("Bilgi Guncelleme Islemi Basariyla Gerceklestirilmistir.", "ISLEM BASARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
