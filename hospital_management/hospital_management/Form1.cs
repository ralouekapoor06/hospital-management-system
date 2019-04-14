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
    public partial class Form1 : Form
    {
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        public void DB_connect()
        {
            try
            {
                String oradb = "Data Source=DESKTOP-H5PIUV5;Persist Security Info=True;User ID=system;Password=student";
                conn = new OracleConnection(oradb);
                conn.Open();
                MessageBox.Show("connected");
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Patient");
            comboBox1.Items.Add("Doctor");
            comboBox1.Items.Add("Admin");
            button2.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_connect();
            if (comboBox1.SelectedItem.ToString() == "Patient" || comboBox1.SelectedItem.ToString() == "Doctor")
            {
                OracleCommand comm = new OracleCommand();
                String tb_name = comboBox1.SelectedItem.ToString();

                comm.CommandText = "select * from " + tb_name;
                comm.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);

                String tb_Stored = "Tbl_" + tb_name;

                da.Fill(ds, tb_Stored);
                DataTable dt = ds.Tables[tb_Stored];
                int t = dt.Rows.Count;
                for(int i = 0; i<t; i++)
                {
                    DataRow dr = new DataRow();
                    dr = dt.Rows[i];
                    if(dr["Email"].ToString() == textBox1.Text && dr["password"].ToString() == textBox2.Text)
                    {
                        if(comboBox1.SelectedItem.ToString() == "Patient")
                        {
                            /////////////////////////////////////////////////////////////////////
                        }
                        else if(comboBox1.SelectedItem.ToString() == "Doctor")
                        {
                            /////////////////////////////////////////////////////////////////////
                        }
                    }
                }

                //MessageBox.Show(t.ToString());
                //comboBox1.DataSource = dt.DefaultView;
                //comboBox1.DisplayMember = "deptname";
            }
            else if(comboBox1.SelectedItem.ToString() == "Admin")
            {
                if(textBox1.Text == "rass" && textBox2.Text == "root")
                {
                    ///////////////////////////////////////////////////////////////////////////Admin Page
                }
            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Patient" || comboBox1.SelectedItem.ToString() == "Doctor")
                button2.Visible = true;
            else if (comboBox1.SelectedItem.ToString() == "Admin")
                button2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Patient")
            {
                ////////////////////////////////////////////////////////////Patient Register
            }
            else if(comboBox1.SelectedItem.ToString() == "Doctor")
            {
                Doctor_register doctor_Register = new Doctor_register();
                doctor_Register.Visible = true;
                this.Visible = false;
            }
        }
    }
}
