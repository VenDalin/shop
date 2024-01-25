using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_management_system
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm( String user, String role)
        {
            InitializeComponent();
            lblUser.Text = $"Welcome to {role} role";

            if(role == "Admin")
            {
                btnCustomer.Visible = true;
                btnUser.Visible = true;
                btnProduct.Visible = true;
                buttonSell.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;

            }else if(role == "Sale")
            {
                btnCustomer.Visible = true;
                btnUser.Visible = true;
                btnProduct.Visible = true;
                buttonSell.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
            }
            else
            {
                btnCustomer.Visible = true;
                btnUser.Visible = false ;
                btnProduct.Visible = false;
                buttonSell.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            panelShow.Controls.Clear();
            ProductForm productForm = new ProductForm();
            productForm.TopLevel = false;
            //productForm.TopMost = true;
            panelShow.Controls.Add(productForm);
            productForm.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            panelShow.Controls.Clear();
            Form2 customerForm = new Form2();
            customerForm.TopLevel = false;
            //customerForm.TopMost = true;
            panelShow.Controls.Add(customerForm);
            customerForm.Show();
        }

        private void buttonSell_Click(object sender, EventArgs e)
        {
            panelShow.Controls.Clear();
            frmSell formsell = new frmSell();
            formsell.TopLevel = false;
            panelShow.Controls.Add(formsell);
            formsell.Show();    
        }
    }
}
