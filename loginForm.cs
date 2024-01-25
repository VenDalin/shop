using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_management_system
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection(Properties.Settings.Default.dbconnection);
            String sql = "Select * from TblEmployee where Username = @user and Password = @password";
            var com = new SqlCommand(sql,con);

            com.Parameters.AddWithValue("@user", txtUsername.Text);
            com.Parameters.AddWithValue("@password", txtPassword.Text);

            con.Open ();
            SqlDataReader dr = com.ExecuteReader();

            String name = null;
            String role = null;
            if(dr.HasRows )
            {
                while(dr.Read())
                {
                    name = dr.GetValue(1).ToString();
                    role= dr.GetValue(3).ToString();
                }
                MainForm fm = new MainForm(name,role);
                fm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password", "Information", MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }


            con.Close ();   
        }
    }
}
