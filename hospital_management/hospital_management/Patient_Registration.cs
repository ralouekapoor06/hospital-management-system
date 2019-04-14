using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace hospital_management
{
    public partial class Patient_Registration : Form
    {
        OracleConnection conn;
        public Patient_Registration()
        {
            InitializeComponent();
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
            comboBox1.Items.Add("Others");

            comboBox2.Items.Add("O+");
            comboBox2.Items.Add("O-");
            comboBox2.Items.Add("A+");
            comboBox2.Items.Add("A-");
            comboBox2.Items.Add("B+");
            comboBox2.Items.Add("B-");
            comboBox2.Items.Add("AB+");
            comboBox2.Items.Add("AB-");

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

        private void Patient_Registration_Load(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            DB_connect();

            OracleCommand comm = new OracleCommand();

            comm.CommandText = "select * from Patient";
            comm.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(comm.CommandText, conn);

            da.Fill(ds, "Tbl_Patient");
            DataTable dt = ds.Tables["Tbl_Patient"];
            int t = dt.Rows.Count;
            t++;

            String bpl = "no";

            if (radioButton1.Checked == true)
                bpl = "yes";
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            cm.CommandText = "Insert into Patient values(" +
                "'" + t + "'," +                                                    //ID
                "'" + textBox1.Text + "'," +                                        //fname
                "'" + textBox2.Text + "'," +                                        //lname
                "'" + int.Parse(textBox5.Text) + "'," +                             //age
                "'" + comboBox1.SelectedItem.ToString() + "'," +                    //sex
                "'" + textBox4.Text + "'," +                                        //password
                "'" + bpl + "'," +                                                  //bpl
                "'" + comboBox2.SelectedItem.ToString() + "'," +                    //blood
                "'" + textBox3.Text + "'," +                                        //email
                "'" + monthCalendar1.SelectionRange.Start.ToShortDateString()       //dob
                + "')";

            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

        }
    }
}
