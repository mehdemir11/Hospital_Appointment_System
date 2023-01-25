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
    public partial class frmDoctor : Form
    {
        public frmDoctor()
        {
            InitializeComponent();
        }
        sqlConnection cnnctn = new sqlConnection();
        private void btnEnter_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Doctors where doctorIDNO=@d1 and doctorPASSWORD=@d2", cnnctn.connection());
            cmd.Parameters.AddWithValue("@d1", mskdID.Text);
            cmd.Parameters.AddWithValue("@d2", txtPassword.Text);
            cmd.ExecuteNonQuery();
            cnnctn.connection().Close();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                frmDoctorDetails frm = new frmDoctorDetails();
                frm.IDNO = mskdID.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kimlik No veya Sifre Hatali.", "ISLEM BASARISIZ!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cnnctn.connection().Close();
        }
    }
}
