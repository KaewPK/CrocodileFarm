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
using DGVPrinterHelper;

namespace cocodrilo_frame
{
    public partial class frm_ฝ่ายการเงิน : Form
    {
        public frm_ฝ่ายการเงิน()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        string cn = "Data Source=.;Initial Catalog=CrocodileFarm; User Id=sa; Password=0000"; // ที่อยู่ของฐานข้อมูล

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_ฝ่ายการเงิน_Load(object sender, EventArgs e)
        {
            string sql = "SELECT OrderID,CustID,CustFirstName,CustLastName,CroID,CroCategory,CroPrice,CroNum,OrderPrice FROM tbl_การสั่งซื้อ";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(ds,"การสั่งซื้อ");
            dataGridView1.DataSource = ds.Tables["การสั่งซื้อ"];

            string sql1= "SELECT PayID,PayDate,OrderID,CustID,CustFirstName,CustLastName,CroID,CroCategory,CroPrice,CroNum,OrderPrice,PayStatus FROM tbl_การชำระเงิน ";
            SqlDataAdapter com = new SqlDataAdapter(sql1,cn);
            com.Fill(ds, "การชำระเงิน");
            dataGridView4.DataSource = ds.Tables["การชำระเงิน"];

            string sql2 = "SELECT BillID,BillDate,PayID,CustID,CustFristName,CustLastName,CroID,CroCategory,CroPrice,CroNum,OrderPrice FROM tbl_ใบเสร็จ ";
            SqlDataAdapter com1 = new SqlDataAdapter(sql2, cn);
            com1.Fill(ds, "ใบเสร็จ");
        }

        private void bt_ออกจากระบบ_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_ล็อคอินพนักงาน from = new frm_ล็อคอินพนักงาน();
            from.Show();
        }

        private void bt_ค้นหา_Click(object sender, EventArgs e)
        {
            string sql = "SELECT PayID,PayDate,OrderID,CustID,CustFirstName,CustLastName,CroID,CroCategory,CroPrice,CroNum,OrderPrice,PayStatus FROM tbl_การชำระเงิน WHERE PayID = '" + tb_ค้นหา.Text.Trim() + "' ";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "การชำระเงิน");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "การชำระเงิน";
        }

        private void tb_รหัสสั่งซื้อ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }

            string sql1 = "SELECT OrderID,CustID,CustFirstName,CustLastName,CroID,CroCategory,CroPrice,CroNum,OrderPrice FROM tbl_การสั่งซื้อ WHERE OrderID = '" + tb_รหัสสั่งซื้อ.Text.Trim() + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter com = new SqlDataAdapter(sql1, cn);
            com.Fill(ds, "การสั่งซื้อ");
            dataGridView3.DataSource = ds;
            dataGridView3.DataMember = "การสั่งซื้อ";
        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            lb_รหัสลูกค้า.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            lb_ชื่อ.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            lb_นามสกุล.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            lb_รหัสจระเข้.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
            lb_ประเเภท.Text = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
            lb_Price.Text = dataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();
            lb_จำนวน.Text = dataGridView3.Rows[e.RowIndex].Cells[7].Value.ToString();
            lb_ราคาต่อจำนวน.Text = dataGridView3.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void bt_บันทึก_Click(object sender, EventArgs e)
        {
            string sql = "SELECT PayID,PayDate,OrderID,CustID,CustFirstName,CustLastName,CroID,CroCategory,CroPrice,CroNum,OrderPrice,PayStatus FROM tbl_การชำระเงิน";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(ds, "การชำระเงิน");

            string sql2 = "SELECT BillID,BillDate,PayID,CustID,CustFristName,CustLastName,CroID,CroCategory,CroPrice,CroNum,OrderPrice FROM tbl_ใบเสร็จ";
            SqlDataAdapter com1 = new SqlDataAdapter(sql2, cn);
            SqlCommandBuilder cb1 = new SqlCommandBuilder(com1);
            com1.Update(ds, "ใบเสร็จ");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // เลือกข้อมูลจาก GridView มาใส่ใน textbox combobox
            if (e.RowIndex == -1) // ไม่เลือกหรือเลือกอย่างอื่นที่ไม่ใช่ข้อมูล
                return; // จบเงื่อนไข
            else
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                DataRow dr = ds.Tables["การสั่งซื้อ"].Rows[e.RowIndex];
                tb_รหัสสั่งซื้อ.Text = dr["OrderID"].ToString();
                lb_รหัสลูกค้า.Text = dr["CustID"].ToString();
                lb_ชื่อ.Text = dr["CustFirstName"].ToString();
                lb_นามสกุล.Text = dr["CustLastName"].ToString();
                lb_รหัสจระเข้.Text = dr["CroID"].ToString();
                lb_ประเเภท.Text = dr["CroCategory"].ToString();
                lb_Price.Text = dr["CroPrice"].ToString();
                lb_จำนวน.Text = dr["CroNum"].ToString();
                lb_ราคาต่อจำนวน.Text = dr["OrderPrice"].ToString();
            }
        }

        private void bt_เคลียร์_Click(object sender, EventArgs e)
        {
            dtp_วันที่ชำระเงิน.Text = "";
            tb_รหัสสั่งซื้อ.Text = "";
            lb_รหัสลูกค้า.Text = "";
            lb_ชื่อ.Text = "";
            lb_นามสกุล.Text = "";
            lb_รหัสจระเข้.Text = "";
            lb_ประเเภท.Text = "";
            lb_Price.Text = "";
            lb_จำนวน.Text = "";
            lb_ราคาต่อจำนวน.Text = "";
            tb_สถานะ.Text = "";
        }

        private void bt_แก้ไข_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["การชำระเงิน"].Select("PayID=" + tb_ชำระเงิน.Text + "");
            drs[0]["PayID"] = tb_ชำระเงิน.Text;
            drs[0]["PayDate"] = dtp_วันที่ชำระเงิน.Text;
            drs[0]["OrderID"] = tb_รหัสสั่งซื้อ.Text;
            drs[0]["CustID"] = lb_รหัสลูกค้า.Text;
            drs[0]["CustFirstName"] = lb_ชื่อ.Text;
            drs[0]["CustLastName"] = lb_นามสกุล.Text;
            drs[0]["CroID"] = tb_รหัสสั่งซื้อ.Text;
            drs[0]["CroCategory"] = lb_รหัสลูกค้า.Text;
            drs[0]["CroPrice"] = lb_Price.Text;
            drs[0]["CroNum"] = lb_จำนวน.Text;
            drs[0]["OrderPrice"] = lb_ราคาต่อจำนวน.Text;
            drs[0]["PayStatus"] = tb_สถานะ.Text;

            dataGridView4.DataSource = ds.Tables["การชำระเงิน"];
        }

        private void tb_ชำระเงิน_TextChanged(object sender, EventArgs e)
        {
            tb_ชำระเงิน.Enabled = true;
        }

        private void bt_เพิ่ม_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["การชำระเงิน"].Select(" PayID = " + tb_ชำระเงิน.Text + "");
            if (drs.Length == 0) //ไม่มีข้อมูลให้ทำการ Insert
            {
                DataRow dr = ds.Tables["การชำระเงิน"].NewRow(); //สร้างแถวใหม่
                dr["PayID"] = tb_ชำระเงิน.Text;
                dr["PayDate"] = dtp_วันที่ชำระเงิน.Text;
                dr["OrderID"] = tb_รหัสสั่งซื้อ.Text;
                dr["CustID"] = lb_รหัสลูกค้า.Text;
                dr["CustFirstName"] = lb_ชื่อ.Text;
                dr["CustLastName"] = lb_นามสกุล.Text;
                dr["CroID"] = tb_รหัสสั่งซื้อ.Text;
                dr["CroCategory"] = lb_รหัสลูกค้า.Text;
                dr["CroPrice"] = lb_Price.Text;
                dr["CroNum"] = lb_จำนวน.Text;
                dr["OrderPrice"] = lb_ราคาต่อจำนวน.Text;
                dr["PayStatus"] = tb_สถานะ.Text;
                ds.Tables["การชำระเงิน"].Rows.Add(dr); //เอาข้อมูลใส่ในแถว
            }
            else //มีข้อมูลให้ทำการ Update
            {
                drs[0]["PayID"] = tb_ชำระเงิน.Text;
                drs[0]["PayDate"] = dtp_วันที่ชำระเงิน.Text;
                drs[0]["OrderID"] = tb_รหัสสั่งซื้อ.Text;
                drs[0]["CustID"] = lb_รหัสลูกค้า.Text;
                drs[0]["CustFirstName"] = lb_ชื่อ.Text;
                drs[0]["CustLastName"] = lb_นามสกุล.Text;
                drs[0]["CroID"] = tb_รหัสสั่งซื้อ.Text;
                drs[0]["CroCategory"] = lb_รหัสลูกค้า.Text;
                drs[0]["CroPrice"] = lb_Price.Text;
                drs[0]["CroNum"] = lb_จำนวน.Text;
                drs[0]["OrderPrice"] = lb_ราคาต่อจำนวน.Text;
                drs[0]["PayStatus"] = tb_สถานะ.Text;
            }
            dataGridView4.DataSource = ds.Tables["การชำระเงิน"];

            DataRow[] drs1 = ds.Tables["ใบเสร็จ"].Select(" BillID = " + tb_ชำระเงิน.Text + "");
            if (drs.Length == 0) //ไม่มีข้อมูลให้ทำการ Insert
            {
                DataRow dr = ds.Tables["ใบเสร็จ"].NewRow(); //สร้างแถวใหม่
                dr["BillID"] = tb_ชำระเงิน.Text;
                dr["BillDate"] = dtp_วันที่ชำระเงิน.Text;
                dr["PayID"] = tb_ชำระเงิน.Text;
                dr["CustID"] = lb_รหัสลูกค้า.Text;
                dr["CustFristName"] = lb_ชื่อ.Text;
                dr["CustLastName"] = lb_นามสกุล.Text;
                dr["CroID"] = tb_รหัสสั่งซื้อ.Text;
                dr["CroCategory"] = lb_รหัสลูกค้า.Text;
                dr["CroPrice"] = lb_Price.Text;
                dr["CroNum"] = lb_จำนวน.Text;
                dr["OrderPrice"] = lb_ราคาต่อจำนวน.Text;
                ds.Tables["ใบเสร็จ"].Rows.Add(dr); //เอาข้อมูลใส่ในแถว
            }
            else //มีข้อมูลให้ทำการ Update
            {
                drs1[0]["BillID"] = tb_ชำระเงิน.Text;
                drs1[0]["BillDate"] = dtp_วันที่ชำระเงิน.Text;
                drs1[0]["PayID"] = tb_ชำระเงิน.Text;
                drs1[0]["CustID"] = lb_รหัสลูกค้า.Text;
                drs1[0]["CustFirstName"] = lb_ชื่อ.Text;
                drs1[0]["CustLastName"] = lb_นามสกุล.Text;
                drs1[0]["CroID"] = tb_รหัสสั่งซื้อ.Text;
                drs1[0]["CroCategory"] = lb_รหัสลูกค้า.Text;
                drs1[0]["CroPrice"] = lb_Price.Text;
                drs1[0]["CroNum"] = lb_จำนวน.Text;
                drs1[0]["OrderPrice"] = lb_ราคาต่อจำนวน.Text;
            }
        }

        private void bt_ลบ_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["การชำระเงิน"].Select("PayID=" + tb_ชำระเงิน.Text + "");
            if (drs.Length == 0) //หาไม่เจอให้แจ้งเตือน
                MessageBox.Show("ไม่พบข้อมูลที่ต้องการ");
            else //เจอข้อมูลให้ทำการลบ
            {
                drs[0].Delete(); //ลบข้อมูลในแถว *แต่แถวยังอยู่"
                //ปรับปรุงฐานข้อมูล
                string sql = "SELECT PayID,PayDate,OrderID,CustID,CustFirstName,CustLastName,CroID,CroCategory,CroPrice,CroNum,OrderPrice,PayStatus FROM tbl_การชำระเงิน";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "การชำระเงิน");

                ds.Tables["การชำระเงิน"].AcceptChanges(); //จะทำให้แถวที่ว่างหาย
            }
        }

        private void bt_พิมพ์ใบเสร็จ_Click(object sender, EventArgs e)
        {
            Print_ใบเสร็จ main = new Print_ใบเสร็จ();
            main.Show();
        }
    }
}
