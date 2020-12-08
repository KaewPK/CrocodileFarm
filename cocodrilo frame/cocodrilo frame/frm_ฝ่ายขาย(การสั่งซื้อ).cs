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

namespace cocodrilo_frame
{
    public partial class Form15 : Form
    {
        private SqlConnection cn;
        public Form15()   
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_ล็อคอินพนักงาน from = new frm_ล็อคอินพนักงาน();
            from.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_ฝ่ายขาย from = new frm_ฝ่ายขาย();
            from.Show();
        }

        private void Form15_Load(object sender, EventArgs e) //สร้างข้อมูลใน listbox
        {
            cn = new SqlConnection(@"Data Source=.;Initial Catalog=CrocodileFarm; User Id=sa; Password=0000"); // ที่อยู่ของฐานข้อมูล
            cn.Open();
            listView1.Columns.Add("รหัสสินค้า", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("ประเภทสินค้า", 180, HorizontalAlignment.Center);
            listView1.Columns.Add("ราคาขาย", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("จำนวนที่ซื้อ", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("รวมเป็นเงิน", 100, HorizontalAlignment.Center);
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            tb_รหัสจระเข้.Focus();
            lb_Price.Text = "0";
            tb_จำนวน.Text = "1";
            lb_ราคาต่อจำนวน.Text = "0";
        }

        private void bt_ถัดไป_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_ฝ่ายขาย_แก้ไขสถานะ_ from = new frm_ฝ่ายขาย_แก้ไขสถานะ_();
            from.Show();
        }

        private void bt_ค้นหา_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=.;Initial Catalog=CrocodileFarm; User Id=sa; Password=0000"); // ที่อยู่ของฐานข้อมูล
            cn.Open();
            using (SqlConnection conn = new SqlConnection())
            {
                string sql = "SELECT OrderID,CustID,CustFirstName,CustLastName,CroID,CroCategory,CroPrice,CroNum,OrderPrice FROM tbl_การสั่งซื้อ WHERE OrderID = '" + tb_ค้นหา.Text.Trim() + "' ";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(ds, "การสั่งซื้อ");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "การสั่งซื้อ";
            }
        }

        private void tb_รหัสลูกค้า_KeyPress(object sender, KeyPressEventArgs e) //ป้อนรหัสลูกค้า
        {
            cn = new SqlConnection(@"Data Source=.;Initial Catalog=CrocodileFarm; User Id=sa; Password=0000"); // ที่อยู่ของฐานข้อมูล
            cn.Open();
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }

            string sql = "SELECT CustPhone,CustFirstName,CustLastName FROM tbl_ลูกค้า WHERE CustID = '" + tb_รหัสลูกค้า.Text.Trim() + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "ลูกค้า");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "ลูกค้า";
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cn = new SqlConnection(@"Data Source=.;Initial Catalog=CrocodileFarm; User Id=sa; Password=0000"); // ที่อยู่ของฐานข้อมูล
            cn.Open();
            if (e.RowIndex == -1) return;
            lb_ชื่อ.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            lb_นามสกุล.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void tb_รหัสจระเข้_KeyPress(object sender, KeyPressEventArgs e)
        {
            cn = new SqlConnection(@"Data Source=.;Initial Catalog=CrocodileFarm; User Id=sa; Password=0000"); // ที่อยู่ของฐานข้อมูล
            cn.Open();
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }

            string sql = "SELECT CroID,CroCategory,CroBirth,CroNum,CroPrice FROM tbl_จระเข้ WHERE CroID = '" + tb_รหัสจระเข้.Text.Trim() + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "จระเข้");
            dataGridView3.DataSource = ds;
            dataGridView3.DataMember = "จระเข้";
        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cn = new SqlConnection(@"Data Source=.;Initial Catalog=CrocodileFarm; User Id=sa; Password=0000"); // ที่อยู่ของฐานข้อมูล
            cn.Open();
            if (e.RowIndex == -1) return;
            lb_ประเเภท.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            lb_Price.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void bt_เพิ่ม_Click(object sender, EventArgs e)
        {

            if ((tb_รหัสจระเข้.Text.Trim() == "") || (lb_Price.Text.Trim() == ""))
            {
                tb_รหัสจระเข้.Focus();
                return;
            }
            if (int.Parse(tb_จำนวน.Text) == 0)
            {
                tb_จำนวน.Focus();
                return;
            }
            int i = 0;
            ListViewItem lvi;
            int tmpProductID = 0;
            for (i = 0; i <= listView1.Items.Count - 1; i++)
            {
                tmpProductID = int.Parse(listView1.Items[i].SubItems[0].Text);
                if (int.Parse(tb_รหัสจระเข้.Text.Trim()) == tmpProductID)
                {
                    MessageBox.Show("คุณเลือกสินค้าที่ซ้ำกัน");
                    tb_รหัสจระเข้.Focus();
                    tb_รหัสจระเข้.SelectAll();
                    return;
                }
            }
            string[] anydata;
            anydata = new string[]
            {
                tb_รหัสจระเข้.Text,
                lb_ประเเภท.Text,
                lb_Price.Text,
                tb_จำนวน.Text,
                lb_ราคาต่อจำนวน.Text,
            };
            lvi = new ListViewItem(anydata);
            listView1.Items.Add(lvi);
            CaculateNet();
            bt_บันทึก.Enabled = true;
            tb_รหัสจระเข้.Focus();
            tb_รหัสจระเข้.SelectAll();
        }

        private void CaculateNet()
        {
            int i = 0;
            double tmpnetTotal = 0;
            for (i = 0; i <= listView1.Items.Count - 1; i++)
            {
                tmpnetTotal += double.Parse(listView1.Items[i].SubItems[4].Text);

            }
            lb_ราคารวม.Text = tmpnetTotal.ToString("#,##00.00");
        }

        private void bt_เคลียร์_Click(object sender, EventArgs e)
        {
            tb_รหัสลูกค้า.Clear();
            tb_รหัสจระเข้.Clear();
            tb_จำนวน.Text = "1";
            lb_Price.Text = "0";
            lb_ราคาต่อจำนวน.Text = "";
            lb_ชื่อ.Text = "";
            lb_นามสกุล.Text = "";
            lb_ประเเภท.Text = "";
            listView1.Clear();
        }

        private void listView1_DoubleClick(object sender, EventArgs e) //ลบข้อมูลใน listView
        {
            int i = 0;
            for (i = 0; i <= listView1.SelectedItems.Count - 1; i++)
            {
                ListViewItem lvi;
                lvi = listView1.SelectedItems[i];
                listView1.Items.Remove(lvi);
            }
            CaculateNet();
            tb_รหัสจระเข้.Focus();
            tb_จำนวน.Text = "1";
            lb_Price.Text = "0";
            lb_ราคาต่อจำนวน.Text = "";
            lb_ชื่อ.Text = "";
            lb_นามสกุล.Text = "";
            lb_ประเเภท.Text = "";
        }

        private void bt_บันทึก_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=.;Initial Catalog=CrocodileFarm; User Id=sa; Password=0000"); // ที่อยู่ของฐานข้อมูล
            cn.Open();
            int i = 0;
            for (i = 0; i <= listView1.Items.Count - 1; i++)
            {
                string sql = "INSERT INTO tbl_การสั่งซื้อ(CustID,CustFirstName,CustLastName,CroID,CroCategory,CroPrice,CroNum,OrderPrice) VALUES('" + tb_รหัสลูกค้า.Text.Trim() + "','" + lb_ชื่อ.Text.Trim()+ "','" + lb_นามสกุล.Text.Trim() + "','" + listView1.Items[i].SubItems[0].Text + "','" + listView1.Items[i].SubItems[1].Text + "','" + listView1.Items[i].SubItems[2].Text + "','" + listView1.Items[i].SubItems[3].Text + "','" + listView1.Items[i].SubItems[4].Text + "')";
                SqlCommand com = new SqlCommand(sql, cn);
                com.ExecuteNonQuery();
                MessageBox.Show("บันทึกสินค้าเรียบร้อย");
            }
        }

        private void caluateTotal()
        {
            double Total;
            Total = (double.Parse(lb_Price.Text)) * int.Parse(tb_จำนวน.Text);
            lb_ราคาต่อจำนวน.Text = Total.ToString("#,##0.00");
        }

        private void tb_จำนวน_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
            caluateTotal();
            tb_รหัสจระเข้.SelectAll();
        }
    }
}
