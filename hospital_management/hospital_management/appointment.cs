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
    
    public partial class appointment : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public appointment()
        {
            InitializeComponent();
            DB_connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from symptoms";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_instructor");
            dt = ds.Tables["Tbl_instructor"];
            int t = dt.Rows.Count;
            //
            for (i=0;i<t;i++)
            {
                dr = dt.Rows[i];
                comboBox1.Items.Add(dr["symptom_name"]); ;
            }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            DB_connect();
            String symptom = comboBox1.SelectedItem.ToString();      
            comm = new OracleCommand();
            comm.CommandText = "select fname,position,department,shift,fees,room_number,waiting_number from doctor natural join doctor_details where dept_name in (select dept_name from symptoms where symptom_name = )";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_instructor");
            dt = ds.Tables["Tbl_instructor"];
            int t = dt.Rows.Count;
            MessageBox.Show(t.ToString());
            dr = dt.Rows[i];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "instructor";
            conn.Close();
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            payment1 p = new payment1();
            p.Show();
        }
    }
}
