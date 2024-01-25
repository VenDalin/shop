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

namespace Shop_management_system
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void English()
        {
            lblAddress.Text = "Address";
            //lblDesignName.Text = "NUBB's Student";
            lblEmail.Text = "Email";
            lblFirstName.Text = "First Name";
            lblLastName.Text = "Last Name";
            lblPhone.Text = "Phone";
            lblTop.Text = "New Customer";
            btnAdd.Text = "Add";

        }

        private void Khmer()
        {
            lblAddress.Text = "អាស័យដ្ខាន";
            //lblDesignName.Text = "និស្សិត ស.ជ.ប.ដ";
            lblEmail.Text = "អីមែល";
            lblFirstName.Text = "នាមខ្លូន";
            lblLastName.Text = "នាមត្រូល";
            lblPhone.Text = "លេខទូរស័ព្ទ";
            lblTop.Text = "អតិថិជនថ្មី";
            btnAdd.Text = "បន្ថែម";

        }

       

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKhmer_Click(object sender, EventArgs e)
        {
            Khmer();
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            English();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection(Properties.Settings.Default.dbconnection);
            //string sql = $"Insert Into TblCustomer (FirstName,LastName,Email,PhoneNumber,Address) " +
            //    $"Values(N'{txtFirstName.Text}', N'{txtLastName.Text}', '{txtEmail.Text}', '{txtPhone.Text}', N'{txtAddress.Text}')";

            string sql = $"Insert Into TblCustomer (FirstName,LastName,Email,PhoneNumber,Address)" +
            $"Values (@firstName, @lastName,@email, @phone, @address)";

            var com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            com.Parameters.AddWithValue("@lastName", txtLastName.Text);
            com.Parameters.AddWithValue("@email", txtEmail.Text); 
            com.Parameters.AddWithValue("@phone", txtPhone.Text);
            com.Parameters.AddWithValue("@address", txtAddress.Text);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Your data recorded. ");

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";

            ShowData();
            
        }

        private void ShowData()
        {
            var connect = new SqlConnection(Properties.Settings.Default.dbconnection);
            var sql1 = "SELECT * FROM TblCustomer";
            var com = new SqlCommand(sql1, connect);
            var da = new SqlDataAdapter(com);
            var dt = new DataTable();
            connect.Open();
            da.Fill(dt);
            connect.Close();
            DataGridView.DataSource = dt;
        }
    }
}
