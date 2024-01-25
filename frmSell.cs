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
    public partial class frmSell : Form
    {
        public frmSell()
        {
            InitializeComponent();
        }

        private void ucProduct1_Load(object sender, EventArgs e)
        {

        }

        private void frmSell_Load(object sender, EventArgs e)
        {
            //for(var i=1; i<10; i++) {
            //    var pro = new ucProduct($"prouct {i}",$"{i*100}",$"{i}");
            //    flowLayoutPanel1.Controls.Add(pro);
            //    pro.Show();
            //}
            GetallProduct();
            
        }
        private void GetallProduct()
        {
            var cn = new SqlConnection(Properties.Settings.Default.dbconnection);
            var sql = "select * from TblProduct";
            var cm = new SqlCommand(sql, cn);
            cn.Open();
            SqlDataReader dr = cm.ExecuteReader();

            while (dr.Read())
            {
                string id = dr.GetValue(0).ToString();
                string name = dr.GetValue(1).ToString();
                string price = dr.GetValue(3).ToString();
                var product = new ucProduct(id, name, price);
                flowLayoutPanel1.Controls.Add(product);
                product.Show();
            }
            cn.Close() ;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
