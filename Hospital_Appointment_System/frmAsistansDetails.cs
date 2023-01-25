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
    public partial class frmAsistansDetails : Form
    {
        public frmAsistansDetails()
        {
            InitializeComponent();
        }
        public string IDNO;

        sqlConnection cnnctn = new sqlConnection();

        private void frmAsistansDetails_Load(object sender, EventArgs e)
        {
            lblIDNO.Text = IDNO;

            //FULLNAME
            SqlCommand cmd = new SqlCommand("Select asistantFULLNAME From tbl_Asistants where asistantIDNO=@a1", cnnctn.connection());
            cmd.Parameters.AddWithValue("@a1", lblIDNO.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblFullName.Text = dr[0].ToString();
            }
            cnnctn.connection().Close();

            //BRANCHS to DataGridView
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select branchID as ID,branchTITLE as Branslar from tbl_Branchs", cnnctn.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Everything about doctors
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select (doctorNAME + ' ' + doctorSECNAME) as 'Doktorlar', doctorBRANCH as 'Branslari' from tbl_Doctors", cnnctn.connection());
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;

            //Branch to Combobox
            SqlCommand cmd2 = new SqlCommand("Select branchTITLE from tbl_Branchs", cnnctn.connection());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBranch.Items.Add(dr2[0]);
            }
            cnnctn.connection().Close();
        }

        private void btnCreateAppo_Click(object sender, EventArgs e)
        {
            SqlCommand cmdcreate = new SqlCommand("Insert into tbl_Appointments (appointmentDate,appointmentTime,appointmentBranch,appointmentDoctor) values (@a1,@a2,@a3,@a4)", cnnctn.connection());
            cmdcreate.Parameters.AddWithValue("@a1", mskdDate.Text);
            cmdcreate.Parameters.AddWithValue("@a2", mskdTime.Text);
            cmdcreate.Parameters.AddWithValue("@a3", cmbBranch.Text);
            cmdcreate.Parameters.AddWithValue("@a4", cmbDoctor.Text);
            cmdcreate.ExecuteNonQuery();
            cnnctn.connection().Close();
            MessageBox.Show("Randevu Olusturma Islemı Basari Ile Gerceklestirilmistir.", "ISLEM BASARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoctor.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select doctorNAME,doctorSECNAME from tbl_Doctors where doctorBranch=@d1", cnnctn.connection());
            cmd.Parameters.AddWithValue("@d1", cmbBranch.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbDoctor.Items.Add(dr[0] + " " + dr[1]);
            }
            cnnctn.connection().Close();
        }

        private void btnAnnouncement_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into tbl_Announcements (announcement) values (@an1)", cnnctn.connection());
            cmd.Parameters.AddWithValue("@an1", rchAnnouncements.Text);
            cmd.ExecuteNonQuery();
            cnnctn.connection().Close();
            MessageBox.Show("Duyuru Olusturma Islemi Basari Ile Gerceklestirilmistir.", "ISLEM BASARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDoctorPanel_Click(object sender, EventArgs e)
        {
            frmAdd_Remove_Doctor frm = new frmAdd_Remove_Doctor();
            frm.Show();

        }

        private void btnBranchPanel_Click(object sender, EventArgs e)
        {
            frmBranchPanel frm = new frmBranchPanel();
            frm.Show();
        }

        private void btnAppoList_Click(object sender, EventArgs e)
        {
            frmAppointmentList frm = new frmAppointmentList();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAnnouncements frm = new frmAnnouncements();
            frm.Show();
        }
    }
}
