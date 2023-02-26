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
    public partial class TransfareRequest : Form
    {
        EFModel ent = new EFModel();
        string str=string.Empty;
        string str2 = string.Empty;
        string str3 = string.Empty;
        
        public TransfareRequest()
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
            
            if (comboBox1.Text == comboBox3.Text)
            {
                MessageBox.Show("you cant choose the same warehouse");
                comboBox3.Text = string.Empty;
            }
            else if(comboBox1.Text != comboBox3.Text && comboBox1.Text!="" && comboBox3.Text!="")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        private void TransfareRequest_Load(object sender, EventArgs e)
        {
            foreach (Warehouse item in ent.Warehouses)
            {
                comboBox1.Items.Add(item.ID);
                comboBox3.Items.Add(item.ID);
            }
            foreach (Supplier item in ent.Suppliers)
            {
                comboBox4.Items.Add(item.ID+" "+item.Name);
            }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox1.Text);
            comboBox2.Items.Clear();
            var prodInWharehouse = ent.Products.Where(a => a.StoreID == id).Select(a => a);
            foreach (var item in prodInWharehouse)
            {
                comboBox2.Items.Add(item.ID + " " + item.Name);
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             str = comboBox2.Text;
            var vr = str.Split(' ');
             str2 = vr[0];
            
            
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text=="")
            {
                MessageBox.Show("please Choose product if possible");
            }
            if (comboBox1.Text==comboBox3.Text)
            {
                MessageBox.Show("you cant choose the same warehouse");
                
            }
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBox4.Text;
            var trim = s.Split(' ');
            str3 = trim[0];
        }

        public string GetOldWarehouse
        {
            get { return comboBox1.Text;}

        }
        public string GetNewWarehouse
        {
            get { return comboBox3.Text;}
        }
        public string GetProduct
        {
            get { return str2;}
        }
        public string GetQuanttity
        {
            get { return textBox1.Text; }
        }
        public string RequestNo
        {
            get { return textBox2.Text; } 
        }
        public string GetSupplier
        {
            get { return str3; }
        }

       
    }
}
