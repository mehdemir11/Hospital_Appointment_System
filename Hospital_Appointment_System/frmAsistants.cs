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
    public partial class frmAsistants : Form
    {
        public frmAsistants()
        {
            InitializeComponent();
        }
        sqlConnection cnnctn = new sqlConnection();
        private void btnEnter_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From tbl_Asistants where asistantIDNO=@a1 and asistantPASSWORD=@a2", cnnctn.connection());
            cmd.Parameters.AddWithValue("@a1", mskdIDNO.Text);
            cmd.Parameters.AddWithValue("@a2", txtPassword.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                frmAsistansDetails frm = new frmAsistansDetails();
                frm.IDNO = mskdIDNO.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatali Kimlik Numarasi veya Sifre.", "ISLEM BASARISIZ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cnnctn.connection().Close();
        }
    }
}
