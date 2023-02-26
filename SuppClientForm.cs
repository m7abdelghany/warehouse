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
    public partial class SuppClientForm : Form
    {
        int Form1RadioBtn = 2;
        int RadioBtnState = 2;
        public SuppClientForm()
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
            this.DialogResult= DialogResult.OK;
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                RadioBtnState = 2;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                RadioBtnState = 1;
            }
        }

        private void SuppClientForm_Load(object sender, EventArgs e)
        {
            if (Form1RadioBtn == 1)
            {
                radioButton2.Enabled = false;
            }
            else if (Form1RadioBtn == 2)
            {
                radioButton1.Enabled = false;
            }
        }
        public string Id
        {
            get { return textBox6.Text; }
            set { textBox6.Text = value; }
        }
        public string PersonName
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string MobileNo
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string FaxNo
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public string Email
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }
        public string Website
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }
        public int Whichone
        {
            get { return RadioBtnState; }

        }
        public int RadioBtnSetter
        {
            set { Form1RadioBtn = value; }
        }

    }
}
