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

namespace ProNatur_Biomarkt_GmbH
{
    public partial class ProductScreen : Form
    {
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Anwender\Documents\ProNatur Biomarkt GmbH.mdf;Integrated Security = True; Connect Timeout = 30");
        public ProductScreen()
        {
            InitializeComponent();

        }

        private void btnProductSave_Click(object sender, EventArgs e)
        {
            if (textBoxProductName.Text == ""
                || textBoxProductBrand.Text == ""
                || comboBoxProductCategory.Text == ""
                || textBoxProductPrice.Text == "")
            {
                MessageBox.Show("Bitte alle Felder füllen!");
                return;
            }

            // save product name in database
            string productName = textBoxProductName.Text;
            string productBrand = textBoxProductBrand.Text;
            string productCategory = comboBoxProductCategory.Text;
            string productPrice = textBoxProductPrice.Text;

            databaseConnection.Open();
            string query = string.Format("insert into Products values('{0}', '{1}', '{2}', '{3}')", productName, productBrand, productCategory, productPrice);
            SqlCommand sqlCommand = new SqlCommand(query, databaseConnection);
            sqlCommand.ExecuteNonQuery();
            databaseConnection.Close();

            ClearFelder();
            ShowProducts();
        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            ShowProducts();
        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {
            ClearFelder();
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            ShowProducts();
        }

        private void ShowProducts()
        {
            // Start
            databaseConnection.Open();

            string query = "Select * from dbo.Products";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            productsDGV.DataSource = dataSet.Tables[0];

            productsDGV.Columns[0].Visible = false;

            databaseConnection.Close();
        }

        private void ClearFelder()
        {
            textBoxProductName.Text = "";
            textBoxProductBrand.Text = "";
            textBoxProductPrice.Text = "";
            comboBoxProductCategory.Text = "";
            comboBoxProductCategory.SelectedItem = null;
        }

    }
}
