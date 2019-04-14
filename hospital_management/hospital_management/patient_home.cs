using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace hospital_management
{
    public partial class patient_home : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public patient_home()
        {
            InitializeComponent();
            //select query
            DB_connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from patient where p_id = 2";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_instructor");
            dt = ds.Tables["Tbl_instructor"];
            //int t = dt.Rows.Count;
            //MessageBox.Show(t.ToString());
            dr = dt.Rows[i];
            label5.Text = dr["fname"].ToString();
            label6.Text = dr["e_mail"].ToString();
            label7.Text = dr["age"].ToString();
            label8.Text = dr["sex"].ToString();
            conn.Close();
        }

        public void DB_connect()
        {
            try
            {
                String oradb = "Data Source=DESKTOP-H5PIUV5;Persist Security Info=True;User ID=system;Password=student";
                conn = new OracleConnection(oradb);
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Check Connection");
            }

        }

        private void patient_home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            appointment app = new appointment();
            app.Show();
        }
    }
}
