using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseTask
{
    public partial class ExportPermission : Form
    {
        EFModel ent = new EFModel();
        string productId = "";
        string SupplierId = string.Empty;
        string warehouseId = string.Empty;
        public ExportPermission()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ExportPermission_Load(object sender, EventArgs e)
        {
            foreach (var item in ent.Products)
            {
                comboBox1.Items.Add(item.ID);
            }
            foreach (Supplier item in ent.Suppliers)
            {
                comboBox2.Items.Add(item.ID);
            }
            foreach (Warehouse item in ent.Warehouses)
            {
                comboBox3.Items.Add(item.ID);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox1.Text);
            Product s = ent.Products.FirstOrDefault(a => a.ID == id);
            textBox2.Text = s.Name;
            productId = comboBox1.Text;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SupplierId = comboBox2.Text;

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            warehouseId = comboBox3.Text;

        }
        public string ReqestNumber
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string productNAme
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string Quantity
        {
            get { return textBox3.Text; }
            set
            {
                textBox3.Text = value;
            }
        }
        public DateTime Requestdate
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }
        public string GetSupplier
        {
            get { return SupplierId; }
        }
        public string GetWarehouse
        {
            get { return warehouseId; }
        }
        public string GetProductID
        {
            get { return productId; }
        }
    }
}
