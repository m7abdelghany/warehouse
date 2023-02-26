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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public string ProductCode
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public new string ProductName
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string MeasureUnit
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public DateTime ProductionDate
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }
        public DateTime ExpirationDate
        {
            get { return dateTimePicker2.Value; }
            set { dateTimePicker1.Value = value; }
        }
        public string Quantity
        {
            get { return textBox6.Text; }
            set { textBox6.Text = value; }
        }
    }
}
