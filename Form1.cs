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

namespace WarehouseTask
{

    public partial class Form1 : Form
    {
        EFModel ent = new EFModel();

        public Form1()
        {
            InitializeComponent();
        }

        private void AddStorage_Click(object sender, EventArgs e)
        {
            WarehouseForm wh = new WarehouseForm();
            DialogResult dresult = wh.ShowDialog();
            if (dresult == DialogResult.OK)
            {
                int ID = int.Parse(wh.StorageId);
                Warehouse w = ent.Warehouses.FirstOrDefault(a => a.ID == ID);
                if (w == null)
                {
                    Warehouse warehouse = new Warehouse();
                    warehouse.ID = int.Parse(wh.StorageId);
                    warehouse.Name = wh.StorageName;
                    warehouse.Address = wh.StorageLocation;
                    warehouse.Manager = wh.StorageManger;
                    MessageBox.Show("added");
                    ent.Warehouses.Add(warehouse);
                    ent.SaveChanges();
                }
                else
                {
                    MessageBox.Show("already existed");
                }

            }

        }

        private void EditStorage_Click(object sender, EventArgs e)
        {
            WarehouseForm wh = new WarehouseForm();
            if (textBox1.Text != "")
            {
                int ID = int.Parse(textBox1.Text);
                Warehouse w = ent.Warehouses.FirstOrDefault(a => a.ID == ID);
                if (w != null)
                {

                    wh.StorageName = w.Name;
                    wh.StorageLocation = w.Address;
                    wh.StorageManger = w.Manager;
                    DialogResult dresult = wh.ShowDialog();
                    if (dresult == DialogResult.OK)
                    {

                        w.Address = wh.StorageLocation;
                        w.Manager = wh.StorageManger;
                        ent.SaveChanges();
                    }
                }
                else { MessageBox.Show("dosent exist"); }
            }
            else
            {
                MessageBox.Show("you have to enter the Id to edit");
            }
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            ProductForm pf = new ProductForm();

            DialogResult dResult = pf.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                int ID = int.Parse(pf.ProductCode);
                Product p = ent.Products.FirstOrDefault(a => a.ID == ID);
                if (p == null)
                {
                    Product product = new Product();
                    product.ID = int.Parse(pf.ProductCode);
                    product.Name = pf.ProductName;
                    product.ProDate = pf.ProductionDate;
                    product.ExpDate = pf.ExpirationDate;
                    product.Quantity = int.Parse(pf.Quantity);
                    product.MeasuringUnit = pf.MeasureUnit;
                    product.EntryDate = DateTime.Now;
                    ent.Products.Add(product);
                    ent.SaveChanges();
                    MessageBox.Show("added");
                }
                else
                {
                    MessageBox.Show("already exist");
                }

            }
        }

        private void EditProduct_Click(object sender, EventArgs e)
        {
            ProductForm pf = new ProductForm();
            if (textBox2.Text != "" && textBox2.Text != null)
            {
                int Id = int.Parse(textBox2.Text);
                Product p = ent.Products.FirstOrDefault(a => a.ID == Id);
                if (p != null)
                {
                    pf.ProductCode = textBox2.Text;
                    pf.ProductName = p.Name;
                    pf.ProductionDate = (DateTime)p.ProDate;
                    pf.ExpirationDate = (DateTime)p.ExpDate;
                    pf.Quantity = p.Quantity.ToString();
                    pf.MeasureUnit = pf.MeasureUnit;

                    DialogResult dResult = pf.ShowDialog();
                    if (dResult == DialogResult.OK)
                    {
                        p.Name = pf.ProductName;
                        p.ProDate = pf.ProductionDate;
                        p.ExpDate = pf.ExpirationDate;
                        p.Quantity = int.Parse(pf.Quantity);
                        p.MeasuringUnit = pf.MeasureUnit;
                        ent.SaveChanges();
                        MessageBox.Show("updated");

                    }
                }
                else
                {
                    MessageBox.Show("dosent exist");
                }
            }
            else
            {
                MessageBox.Show("yoh have to enter Id");
            }
        }

        private void AddSupplier_Click(object sender, EventArgs e)
         {
            SuppClientForm sf = new SuppClientForm();

            if (radioButton1.Checked == true)
            {
                sf.RadioBtnSetter = 1;

                DialogResult dResult = sf.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    int ID = int.Parse(sf.Id);

                    // client
                    
                    
                        Client c = ent.Clients.FirstOrDefault(a => a.ID == ID);
                        if (c == null)
                        {
                            Client client = new Client();
                            client.ID = int.Parse(sf.Id);
                            client.Name = sf.PersonName;
                            client.Mobile = int.Parse(sf.MobileNo);
                            client.Telephone = int.Parse(sf.MobileNo);
                            client.Email = sf.Email;
                            client.Fax = int.Parse(sf.FaxNo);
                            client.WebSite = sf.Website;
                            ent.Clients.Add(client);
                            ent.SaveChanges();
                            MessageBox.Show("added");
                        }
                        else
                        {
                            MessageBox.Show("Client exists");
                        }

                    
                }
            }
            else if (radioButton2.Checked = true)
            {
                sf.RadioBtnSetter = 2;
                DialogResult dResult = sf.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    int ID = int.Parse(sf.Id);

                    // client
                    
                    
                        Supplier c = ent.Suppliers.FirstOrDefault(a => a.ID == ID);
                        if (c == null)
                        {
                            Supplier supplier = new Supplier();
                            supplier.ID = int.Parse(sf.Id);
                            supplier.Name = sf.PersonName;
                            supplier.Mobile = int.Parse(sf.MobileNo);
                            supplier.Telephone = int.Parse(sf.MobileNo);
                            supplier.Email = sf.Email;
                            supplier.Fax = int.Parse(sf.FaxNo);
                            supplier.WebSite = sf.Website;
                            ent.Suppliers.Add(supplier);
                            ent.SaveChanges();
                            MessageBox.Show("added");
                        }
                        else
                        {
                            MessageBox.Show("supplier exists");
                        }

                    
                }
            }
        }

        private void EditSupplier_Click(object sender, EventArgs e)
        {
            SuppClientForm sf = new SuppClientForm();
            sf.Id = textBox3.Text;
            if (textBox3.Text != "" && textBox3.Text != null)
            {
                int id = int.Parse(textBox3.Text);




                if (radioButton1.Checked == true)
                {
                    sf.RadioBtnSetter = 1;
                    Client c = ent.Clients.FirstOrDefault(x => x.ID == id);
                    if (c != null)
                    {
                        sf.PersonName = c.Name;
                        sf.Email = c.Email;
                        sf.MobileNo = c.Mobile.ToString();
                        sf.FaxNo = c.Fax.ToString();
                        sf.Website = c.WebSite;
                        DialogResult dResult = sf.ShowDialog();
                        if (dResult == DialogResult.OK)
                        {
                            c.Name = sf.PersonName;
                            c.Mobile = int.Parse(sf.MobileNo);
                            c.Telephone = int.Parse(sf.MobileNo);
                            c.Email = sf.Email;
                            c.Fax = int.Parse(sf.FaxNo);
                            c.WebSite = sf.Website;
                            ent.SaveChanges();

                            MessageBox.Show("Updated");
                        }
                    }
                    else { MessageBox.Show("client exists"); }


                }
                else if (radioButton2.Checked == true)
                {
                    sf.RadioBtnSetter = 2;
                    Supplier c = ent.Suppliers.FirstOrDefault(x => x.ID == id);
                    if (c != null)
                    {
                        sf.PersonName = c.Name;
                        sf.Email = c.Email;
                        sf.MobileNo = c.Mobile.ToString();
                        sf.FaxNo = c.Fax.ToString();
                        sf.Website = c.WebSite;
                        DialogResult dResult = sf.ShowDialog();
                        if (dResult == DialogResult.OK)
                        {

                            c.Name = sf.PersonName;
                            c.Mobile = int.Parse(sf.MobileNo);
                            c.Telephone = int.Parse(sf.MobileNo);
                            c.Email = sf.Email;
                            c.Fax = int.Parse(sf.FaxNo);
                            c.WebSite = sf.Website;
                            ent.SaveChanges();
                            MessageBox.Show("Updated");

                        }
                    }
                    else { MessageBox.Show("Supplier Exists"); }


                }
                else { MessageBox.Show("you have to choose what to edit"); }
            }
            else { MessageBox.Show("you have to enter Id"); }
        }

        private void ExportRequest_Click(object sender, EventArgs e)
        {
            ExportPermission Ep = new ExportPermission();
            DialogResult dResult = Ep.ShowDialog();
            if (Ep.ReqestNumber != "" && Ep.ReqestNumber != null)
            {
                int id = int.Parse(Ep.ReqestNumber);
                Permission p = ent.Permissions.FirstOrDefault(a => a.RequestNo == id);
                if (p == null)
                {
                    Permission permission = new Permission();
                    if (dResult == DialogResult.OK)
                    {
                        int prodID = int.Parse(Ep.GetProductID);
                        Product pr = ent.Products.FirstOrDefault(a => a.ID == prodID);
                        if (pr.Quantity >= int.Parse(Ep.Quantity))
                        {
                            int supId = int.Parse(Ep.GetSupplier);
                            int warID = int.Parse(Ep.GetWarehouse);


                            permission.Type = "Export";
                            permission.RequestNo = id;
                            permission.Date = Ep.Requestdate;
                            permission.Name = Ep.productNAme;
                            permission.Quantity = int.Parse(Ep.Quantity);
                            permission.SupplierID = supId;
                            permission.warehouseID = warID;
                            permission.ProductCode = prodID;
                            pr.Quantity -= int.Parse(Ep.Quantity);
                            ent.Permissions.Add(permission);
                            ent.SaveChanges();
                            MessageBox.Show("Export done");
                        }
                        else { MessageBox.Show("the quantity of the prodcut is lower than the requested "); }
                    }
                }
                else { MessageBox.Show("export already exists"); }
            }
            else { MessageBox.Show("you hace to enter Requst number"); }
        }

        private void ImportRequest_Click(object sender, EventArgs e)
        {
            ImportPermission Ep = new ImportPermission();
            DialogResult dResult = Ep.ShowDialog();
            if (Ep.ReqestNumber != "" && Ep.ReqestNumber != null)
            {
                int id = int.Parse(Ep.ReqestNumber);
                Permission p = ent.Permissions.FirstOrDefault(a => a.RequestNo == id);
                if (p == null)
                {
                    Permission permission = new Permission();
                    if (dResult == DialogResult.OK)
                    {
                        int prodID = int.Parse(Ep.GetProductID);
                        Product pr = ent.Products.FirstOrDefault(a => a.ID == prodID);

                        int supId = int.Parse(Ep.GetSupplier);
                        int warID = int.Parse(Ep.GetWarehouse);


                        permission.Type = "Import";
                        permission.RequestNo = id;
                        permission.Date = Ep.Requestdate;
                        permission.Name = Ep.productNAme;
                        permission.Quantity = int.Parse(Ep.Quantity);
                        permission.SupplierID = supId;
                        permission.warehouseID = warID;
                        permission.ProductCode = prodID;
                        pr.Quantity += int.Parse(Ep.Quantity);
                        ent.Permissions.Add(permission);
                        ent.SaveChanges();
                        MessageBox.Show("Import done");


                    }
                }
                else { MessageBox.Show("export already exists"); }
            }
            else { MessageBox.Show("you hace to enter Requst number"); }
        }

        private void Transfare_Click(object sender, EventArgs e)
        {
            TransfareRequest tr = new TransfareRequest();
            DialogResult dResult = tr.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                int perm = int.Parse(tr.RequestNo);
                Permission per = ent.Permissions.FirstOrDefault(a => a.RequestNo == perm);
                if (per == null)
                {

                    int id = int.Parse(tr.GetProduct);
                    Product p = ent.Products.FirstOrDefault(x => x.ID == id);
                    if (p.Quantity > int.Parse(tr.GetQuanttity))
                    {
                        //product modification
                        p.Quantity -= int.Parse(tr.GetQuanttity);
                        Product product = new Product();
                        product.ID = int.Parse(tr.GetQuanttity) - id;
                        product.Name = p.Name;
                        product.Quantity = int.Parse(tr.GetQuanttity);
                        product.ExpDate = p.ExpDate;
                        product.ProDate = p.ProDate;
                        product.StoreID = int.Parse(tr.GetNewWarehouse);
                        //adding permission
                        Permission permission = new Permission();
                        permission.Type = "Transfare";
                        permission.RequestNo = int.Parse(tr.RequestNo);
                        permission.Name = p.Name;
                        permission.Quantity = int.Parse(tr.GetQuanttity);
                        permission.SupplierID = int.Parse(tr.GetSupplier);
                        permission.Date = DateTime.Now;
                        permission.ProductCode = p.ID;
                        permission.warehouseID = int.Parse(tr.GetNewWarehouse);
                        ent.Products.Add(product);
                        ent.Permissions.Add(permission);
                        ent.SaveChanges();
                        MessageBox.Show("Transfared");
                    }
                    else if (p.Quantity == int.Parse(tr.GetQuanttity))
                    {
                        //prodcut modification
                        p.StoreID = int.Parse(tr.GetNewWarehouse);
                        //adding permission
                        Permission permission = new Permission();
                        permission.Type = "Transfare";
                        permission.RequestNo = int.Parse(tr.RequestNo);
                        permission.Name = p.Name;
                        permission.Quantity = int.Parse(tr.GetQuanttity);
                        permission.SupplierID = int.Parse(tr.GetSupplier);
                        permission.Date = DateTime.Now;
                        permission.ProductCode = p.ID;
                        permission.warehouseID = int.Parse(tr.GetNewWarehouse);
                        ent.Permissions.Add(permission);
                        ent.SaveChanges();
                        MessageBox.Show("transfared");
                    }
                    else if (p.Quantity < int.Parse(tr.GetQuanttity))
                    {
                        MessageBox.Show("the quantity you want to transfare is bigger than the stored one");
                    }
                }
                else
                {
                    MessageBox.Show("request number is already exists");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = comboBox3.Text;
            var ss = s.Split(' ');
            if (comboBox1.Text != "")
            {


                int id = int.Parse(ss[0]);

                DateTime date1 = dateTimePicker1.Value;
                DateTime date2 = dateTimePicker2.Value;
                sqlConnection2.Open();
                SqlDataReader dreader;
                if (Reports.Items.Count > 0)
                {
                    Reports.Items.Clear();
                }
                string strs = this.sqlCommand1.CommandText = "select Warehouse.*, Product.Name, Product.EntryDate\r\nfrom Warehouse inner join Permission\r\non Warehouse.ID = Permission.Warehouseid\r\ninner join Product\r\non Product.ID = Permission.ProductCode and EntryDate between '" + date1 + "' and '" + date2 + "' and Warehouse.ID =" + id;

                dreader = sqlCommand1.ExecuteReader();
                while (dreader.Read())
                {
                    string str2 = ((int)dreader[0]).ToString() + "\t" + dreader[1].ToString() + "\t" + dreader[2].ToString() + "\t" + dreader[3].ToString() + "\t" + ((int)dreader[4]).ToString() + "\t" + ((int)dreader[5]).ToString() + "\t" + dreader[6].ToString() + "\t" + dreader[7].ToString() + "\t";
                    Reports.Items.Add(str2);
                }
                dreader.Close();
                sqlConnection2.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox1.Text != null && comboBox2.Text != "" && comboBox2.Text != null)
            {


                string ware = comboBox2.Text;
                var spl = ware.Split(' ');
                int id = int.Parse(spl[0]);


                string str = comboBox1.Text;



                DateTime date1 = dateTimePicker1.Value;
                DateTime date2 = dateTimePicker2.Value;
                sqlConnection2.Open();
                SqlDataReader dreader;
                if (Reports.Items.Count > 0)
                {
                    Reports.Items.Clear();
                }
                string con = this.sqlCommand1.CommandText = "select Product.ID ,Product.Name,StoreID , EntryDate\r\nfrom\tProduct inner join Permission\r\non Product.id=Permission.ProductCode and EntryDate between '" + date1 + "' and '" + date2 + "' and StoreID = '" + id + "'";

                dreader = sqlCommand1.ExecuteReader();
                while (dreader.Read())
                {
                    string str2 = ((int)dreader[0]).ToString() + "\t" + dreader[1].ToString() + "\t" + ((int)dreader[2]).ToString() + "\t" + dreader[3].ToString();
                    Reports.Items.Add(str2);
                }
                dreader.Close();
                sqlConnection2.Close();

            }
            else
            {
                MessageBox.Show("please choose the prodct and warehose");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Product item in ent.Products)
            {
                comboBox1.Items.Add(item.ID + " " + item.Name);


            }
            foreach (Warehouse item in ent.Warehouses)
            {
                comboBox2.Items.Add(item.ID + " " + item.Name);
                comboBox3.Items.Add(item.ID + " " + item.Name);
                comboBox4.Items.Add(item.ID+ " " + item.Name);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox4.Text != "")
            {

                if (Reports.Items.Count>0)
                {
                    Reports.Items.Clear();
                }

                int time = int.Parse(textBox4.Text);



                sqlConnection2.Open();
                SqlDataReader dreader;
                if (Reports.Items.Count > 0)
                {
                    Reports.Items.Clear();
                }
                this.sqlCommand1.CommandText = "select Product.* , StoreID\r\nfrom Product inner join Permission\r\non Product.ID=Permission.ProductCode and DATEDIFF(DAY,GETDATE(),EntryDate)<" + time;
                dreader = sqlCommand1.ExecuteReader();
                while (dreader.Read())
                {
                    string str2 = ((int)dreader[0]).ToString() + dreader[1].ToString() + ((int)dreader[2]).ToString() + dreader[3].ToString() + dreader[4].ToString() + ((int)dreader[5]).ToString() + ((int)dreader[6]).ToString() + ((int)dreader[7]).ToString() + dreader[8].ToString() + dreader[9].ToString() + ((int)dreader[10]).ToString();
                    Reports.Items.Add(str2);
                }
                dreader.Close();
                sqlConnection2.Close();


            }
            else
            {
                MessageBox.Show("please choose the product and enter time");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {


                int time = int.Parse(textBox5.Text);
                sqlConnection2.Open();
                SqlDataReader dreader;
                if (Reports.Items.Count > 0)
                {
                    Reports.Items.Clear();
                }
                this.sqlCommand1.CommandText = "select Product.id,Product.Name,Quantity,ExpDate,ProDate,EntryDate\r\nfrom Product\r\nwhere ExpDate>GETDATE() and DATEDIFF(DAY,GETDATE(),ExpDate)<" + time;
                dreader = sqlCommand1.ExecuteReader();
                while (dreader.Read())
                {
                    string str2 = ((int)dreader[0]).ToString() + "\t" + dreader[1].ToString() + "\t" + ((int)dreader[2]).ToString() + "\t" + dreader[3].ToString() + "\t" + dreader[4].ToString() + "\t" + dreader[5].ToString() + "\t";
                    Reports.Items.Add(str2);
                }
                dreader.Close();
                sqlConnection2.Close();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = comboBox4.Text;
            var ss = s.Split(' ');
            if (comboBox4.Text != "")
            {


                int id = int.Parse(ss[0]);

                DateTime date1 = dateTimePicker1.Value;
                DateTime date2 = dateTimePicker2.Value;
                sqlConnection2.Open();
                SqlDataReader dreader;
                if (Reports.Items.Count > 0)
                {
                    Reports.Items.Clear();
                }
                string strs = this.sqlCommand1.CommandText = "select Warehouse.*, Product.Name, Product.EntryDate\r\nfrom Warehouse inner join Permission\r\non Warehouse.ID = Permission.Warehouseid\r\ninner join Product\r\non Product.ID = Permission.ProductCode and EntryDate between '" + date1 + "' and '" + date2 + "' and Warehouse.ID =" + id;

                dreader = sqlCommand1.ExecuteReader();
                while (dreader.Read())
                {
                    string str2 = ((int)dreader[0]).ToString() + "\t" + dreader[1].ToString() + "\t" + dreader[2].ToString() + "\t" + dreader[3].ToString() + "\t" + ((int)dreader[4]).ToString() + "\t" + ((int)dreader[5]).ToString() + "\t" + dreader[6].ToString() + "\t" + dreader[7].ToString() + "\t";
                    Reports.Items.Add(str2);
                }
                dreader.Close();
                sqlConnection2.Close();

            }
        }
    }
}
