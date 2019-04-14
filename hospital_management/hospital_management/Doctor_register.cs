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
    public partial class Doctor_register : Form
    {
        OracleConnection conn;
        public Doctor_register()
        {
            InitializeComponent();

            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
            comboBox1.Items.Add("Others");

            comboBox2.Items.Add("Neurology");
            comboBox2.Items.Add("Dermatology");
            comboBox2.Items.Add("Pediatrics");
            comboBox2.Items.Add("Obstetricians and Gynaecology");
            comboBox2.Items.Add("Urology");
            comboBox2.Items.Add("Pathology");
            comboBox2.Items.Add("General Surgery");
            comboBox2.Items.Add("Cardiology");
            

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
            catch(Exception e)
            {
                MessageBox.Show("not conencted");
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Doctor_register_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_connect();
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            cm.CommandText = "Insert into Doctor_Details values(" +
                "'" + textBox1.Text + "'," +                      //fname
                "'" + textBox2.Text + "'," +                      //lname
                "'" + textBox3.Text + "'," +                      //phone number
                "'" + int.Parse(textBox5.Text) + "'," +           //age
                "'" + comboBox1.SelectedItem.ToString() + "'," +  //sex
                "'" + textBox4.Text + "'," +                      //email
                "'" + textBox6.Text +                             //password
                "')";


            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();


            OracleCommand cm1 = new OracleCommand();

            cm1 = new OracleCommand();
            cm1.Connection = conn;
            cm1.CommandText = "Insert into Department values(" +
                "'" + comboBox2.SelectedItem.ToString() + "'," +
                "'" + textBox4.Text + "')";

            cm1.CommandType = CommandType.Text;
            cm1.ExecuteNonQuery();

            conn.Close();
        }
    }
}
