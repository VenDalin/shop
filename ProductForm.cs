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
    public partial class ProductForm : Form
       
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cm = new SqlCommand();

        public ProductForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)

        {
            if(btnAdd.Text== "Update" && lblID.Text != "0")
            {
                UpdateProduct();
                GetProduct();
                ClearText();
            }
            else
            {
                AddProduct();
                GetProduct();
                ClearText();

            }
           
           
        }

        private void AddProduct()
        {
            string sql = "Insert into TblProduct(ProductName,Description,Price,Category) Values (@productName ,@description,@price, @category)";
            cm = new SqlCommand(sql, con);
            cm.Parameters.AddWithValue("@productName", txtProductName.Text);
            cm.Parameters.AddWithValue("@description", txtDescription.Text);
            cm.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text));
            cm.Parameters.AddWithValue("@category", txtCategory.Text);

            con.Open();
            cm.ExecuteNonQuery();
            con.Close();

        }

        private void UpdateProduct()
        {
            string sql = "Update TblProduct set ProductName = @productName, Description =@description,Price=@price,Category= @category where ProductID =@id";
            cm = new SqlCommand(sql, con);
            cm.Parameters.AddWithValue("@productName", txtProductName.Text);
            cm.Parameters.AddWithValue("@description", txtDescription.Text);
            cm.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text));
            cm.Parameters.AddWithValue("@category", txtCategory.Text);
            cm.Parameters.AddWithValue("@id", lblID.Text);

            con.Open();
            cm.ExecuteNonQuery();
            con.Close() ;
        }

        private void DeleteProduct()
        {
            string sql = "Delete from TblProduct where ProductID= @id";
            cm = new SqlCommand(sql, con);
            cm.Parameters.AddWithValue("@id",lblID.Text);
            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }

        private void GetProduct()
        {
            string sql = "select * from TblProduct";
            cm = new SqlCommand(sql, con);
            var da = new SqlDataAdapter(cm);
            var dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            dataGridViewProduct.DataSource = dt;

        }
        private void ClearText()
        {
            txtCategory.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtProductName.Text = "";
            lblID.Text = "0";
            btnAdd.Text = "AddProduct";
            txtProductName.Focus();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            GetProduct();
        }

        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                  if (dataGridViewProduct.Columns[e.ColumnIndex].Index == 0)
                {
                    var msg = MessageBox.Show("Do you wanna delete the record", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        DeleteProduct();
                        ClearText();
                        GetProduct();
                    }

                }

                else
                {

                    txtCategory.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtDescription.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtPrice.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtProductName.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                    lblID.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[0].Value.ToString();

                    btnAdd.Text = "Update";

                }

            }

            //if(e.RowIndex >= 0)
            //{
            //    txtCategory.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            //    txtDescription.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    txtPrice.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
            //    txtProductName.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    lblID.Text = dataGridViewProduct.Rows[e.RowIndex].Cells[0].Value.ToString();

            //    btnAdd.Text = "Update";


            //}


        }

        private void dataGridViewProduct_DoubleClick(object sender, EventArgs e)
        {
           

        }
    }
}
