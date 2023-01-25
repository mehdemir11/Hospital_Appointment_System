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
    public partial class frmAdd_Remove_Doctor : Form
    {
        public frmAdd_Remove_Doctor()
        {
            InitializeComponent();
        }
        sqlConnection cnnctn = new sqlConnection();

        private void frmAdd_Remove_Doctor_Load(object sender, EventArgs e)
        {
            //Branch to combobox
            SqlCommand cmd2 = new SqlCommand("Select branchTITLE from tbl_Branchs", cnnctn.connection());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBranch.Items.Add(dr2[0]);
            }
            cnnctn.connection().Close();

            //Everything about doctors
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select doctorNAME as 'Ad', doctorSECNAME as 'Soyad', doctorBRANCH as 'Bransi',doctorIDNO as 'Kimlik Numarasi', doctorPASSWORD as 'Sifre' from tbl_Doctors", cnnctn.connection());
            da3.Fill(dt3);
            dataGridView1.DataSource = dt3;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into tbl_Doctors (doctorNAME,doctorSECNAME,doctorBRANCH,doctorIDNO,doctorPASSWORD) values (@d1,@d2,@d3,@d4,@d5)", cnnctn.connection());
            cmd.Parameters.AddWithValue("@d1", txtName.Text);
            cmd.Parameters.AddWithValue("@d2", txtSecName.Text);
            cmd.Parameters.AddWithValue("@d3", cmbBranch.Text);
            cmd.Parameters.AddWithValue("@d4", mskdIDNO.Text);
            cmd.Parameters.AddWithValue("@d5", txtPassword.Text);
            cmd.ExecuteNonQuery();
            cnnctn.connection().Close();
            MessageBox.Show("Ekleme Islemi Basariyla Gerceklestirilmistir.", "ISLEM BASARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;
            txtName.Text = dataGridView1.Rows[chosen].Cells[0].Value.ToString();
            txtSecName.Text = dataGridView1.Rows[chosen].Cells[1].Value.ToString();
            cmbBranch.Text = dataGridView1.Rows[chosen].Cells[2].Value.ToString();
            mskdIDNO.Text = dataGridView1.Rows[chosen].Cells[3].Value.ToString();
            txtPassword.Text = dataGridView1.Rows[chosen].Cells[4].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from tbl_Doctors where doctorIDNO=@d1", cnnctn.connection());
            cmd.Parameters.AddWithValue("@d1", mskdIDNO.Text);
            cmd.ExecuteNonQuery();
            cnnctn.connection().Close();
            MessageBox.Show("Kayit Silme Islemi Basariyla Gerceklestirilmistir.", "ISLEM BASARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update tbl_Doctors set doctorNAME=@d1,doctorSECNAME=@d2,doctorBRANCH=@d3,doctorPASSWORD=@d5 where doctorIDNO=@d4", cnnctn.connection());
            cmd.Parameters.AddWithValue("@d1", txtName.Text);
            cmd.Parameters.AddWithValue("@d2", txtSecName.Text);
            cmd.Parameters.AddWithValue("@d3", cmbBranch.Text);
            cmd.Parameters.AddWithValue("@d4", mskdIDNO.Text);
            cmd.Parameters.AddWithValue("@d5", txtPassword.Text);
            cmd.ExecuteNonQuery();
            cnnctn.connection().Close();
            MessageBox.Show("Bilgi Guncelleme Islemi Basariyla Gerceklestirilmistir.", "ISLEM BASARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
