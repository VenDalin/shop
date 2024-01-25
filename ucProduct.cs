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
    public partial class ucProduct : UserControl
    {
        public ucProduct()
        {
            InitializeComponent();

        }


        public ucProduct(string proName, string price, string id)
        {
            InitializeComponent();
            lblID.Text = id;
            lblPrice.Text = price;
            lblproName.Text = proName;
        }
        public ucProduct(string img, string proName, string price, string id)
        {
            InitializeComponent();
            lblID.Text = id;
            lblPrice.Text = price;
            lblproName.Text = proName;
            pictureBox1.ImageLocation = img;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var Fsell = (frmSell)Application.OpenForms["frmSell"];
            var fu = new ucProduct(lblproName.Text,lblPrice.Text,lblID.Text);
            Fsell.flowLayoutPanel2.Controls.Add(fu);
            fu.Show();
            Fsell.Show();
        }
    }
}
