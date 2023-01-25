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
    public partial class frmAnnouncements : Form
    {
        public frmAnnouncements()
        {
            InitializeComponent();
        }
        sqlConnection cnnctn = new sqlConnection();
        private void frmAnnouncements_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select announcementID as 'ID', announcements as 'Duyuru' from tbl_Announcements", cnnctn.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
