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
    public partial class frmPatientDetails : Form
    {
        public frmPatientDetails()
        {
            InitializeComponent();
        }
        sqlConnection cnnctn = new sqlConnection();
        public string idno;
        private void frmPatientDetails_Load(object sender, EventArgs e)
        {
            lblIDNO.Text = idno;
            //AD SOYAD CEKME
            SqlCommand cmd = new SqlCommand("Select patientNAME,patientSECNAME from tbl_Patients where patientIDNO=@p1", cnnctn.connection());
            cmd.Parameters.AddWithValue("@p1", lblIDNO.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblFullName.Text = dr[0] + " " + dr[1];
            }
            cnnctn.connection().Close();

            //RANDEVU GECMISI
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select appointmentID as 'ID',appointmentDate as 'Tarih',appointmentTime as 'Saat',appointmentBranch as 'Brans',appointmentDoctor as 'Doktor',appointmentActive as 'Durum',patientIDNO as 'Hasta No' from tbl_Appointments where patientIDNO=" + idno, cnnctn.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            

            //BRANSLARI CEKME
            SqlCommand cmd2 = new SqlCommand("Select branchTITLE from tbl_Branchs", cnnctn.connection());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBranch.Items.Add(dr2[0]);
            }
            cnnctn.connection().Close();
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoctor.Items.Clear();
            SqlCommand cmd3 = new SqlCommand("Select doctorNAME,doctorSECNAME From tbl_Doctors where doctorBRANCH=@d1", cnnctn.connection());
            cmd3.Parameters.AddWithValue("@d1", cmbBranch.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoctor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            cnnctn.connection().Close();
        }

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select appointmentID as 'ID',appointmentDate as 'Tarih',appointmentTime as 'Saat',appointmentBranch as 'Brans',appointmentDoctor as 'Doktor',appointmentActive as 'Durum',patientIDNO as 'Hasta No' From tbl_Appointments where appointmentBRANCH='" + cmbBranch.Text + "'" + " and appointmentDoctor='" + cmbDoctor.Text + "' and appointmentActive=0", cnnctn.connection());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void lnkUpdInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPatientUpdateInformation frm = new frmPatientUpdateInformation();
            frm.IDno = lblIDNO.Text;
            frm.Show();
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update tbl_Appointments set appointmentActive=1,patientIDNO=@a1,patientComplaint=@a2 where appointmentID=@a3", cnnctn.connection());
            cmd.Parameters.AddWithValue("@a1", lblIDNO.Text);
            cmd.Parameters.AddWithValue("@a2", rchComplaint.Text);
            cmd.Parameters.AddWithValue("@a3", txtID.Text);
            cmd.ExecuteNonQuery();
            cnnctn.connection().Close();
            MessageBox.Show("Randevu Olusturma Islemı Basarıyla Gerceklesmistir.", "ISLEM BASARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView2.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView2.Rows[chosen].Cells[0].Value.ToString();
        }
    }
}
