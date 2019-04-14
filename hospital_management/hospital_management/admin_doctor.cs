using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Oracle.DataAccess.Types;
//using Oracle.DataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        /*
        OracleConnection conn;
        OracleCommand comm;
        DataTable dt;
        DataRow dr;
        DataSet ds;
        */
        public Form1()
        {
            InitializeComponent();
        }

        public void Db_connect()
        {
            //copy the whole part here
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String h = comboBox1.SelectedItem.ToString();
            /*populate the datagrid view
            comm = new OracleCommand();
            comm.CommandText = "";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_instructor");
            dt = ds.Tables["Tbl_instructor"];
            int t = dt.Rows.Count;
            
            dr = dt.Rows[i];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tb1_instructor";        

 */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* insert all the details from the doctor table
            DB_Connect();
            
            OracleCommand cm = new OracleCommand(); 
            cm.Connection = conn;
            cm.CommandText = "insert into doctor values(’" + textBox1.Text + "’,
            ’" + textBox2.Text + "’,
            ’" + textBox3.Text + "’,
            ’" + textBox4.Text + "’,
            ’" + textBox5.Text + "’,
            )";
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();
            conn.Close();
            */
        }
    }
}
