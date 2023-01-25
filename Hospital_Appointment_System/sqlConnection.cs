using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hospital_Appointment_System
{
    class sqlConnection
    {
        public SqlConnection connection()
        {
            SqlConnection connect = new SqlConnection("Data Source=MEHMETCAN-PC\\SQLEXPRESS;Initial Catalog=hospitalAppointmentSystem;Integrated Security=True");
            connect.Open();
            return connect;
        }
    }
}
