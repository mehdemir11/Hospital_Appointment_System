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
    public partial class frmBranchPanel : Form
    {
        public frmBranchPanel()
        {
            InitializeComponent();
        }
        sqlConnection cnnctn = new sqlConnection();
        private void frmBranchPanel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select branchID as 'ID', branchTITLE as 'Branslar' from tbl_Branchs",cnnctn.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert Into tbl_Branchs (branchTITLE) values (@b1)", cnnctn.connection());
            cmd.Parameters.AddWithValue("@b1", txtBransTitle.Text);
            cmd.ExecuteNonQuery();
            cnnctn.connection().Close();
            MessageBox.Show("Brans Ekleme Islemı Basariyla Gerceklestirilmistir.", "ISLEM BASARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;
            txtBransId.Text = dataGridView1.Rows[chosen].Cells[0].Value.ToString();
            txtBransTitle.Text = dataGridView1.Rows[chosen].Cells[1].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from tbl_Branchs where branchID=@b1", cnnctn.connection());
            cmd.Parameters.AddWithValue("@b1", txtBransId.Text);
            cmd.ExecuteNonQuery();
            cnnctn.connection().Close();
            MessageBox.Show("Brans Silme Islemi Basariyla Gerceklestirilmistir.", "ISLEM BASARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update tbl_Branchs set branchTITLE=@b1 where branchID=@b2", cnnctn.connection());
            cmd.Parameters.AddWithValue("@b1", txtBransTitle.Text);
            cmd.Parameters.AddWithValue("@b2", txtBransId.Text);
            cmd.ExecuteNonQuery();
            cnnctn.connection().Close();
            MessageBox.Show("Bılgı Guncelleme Islemı Basariyla Gerceklestirilmistir.", "ISLEM BASARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
