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
    public partial class frm_ฝ่ายขาย : Form
    {
        public frm_ฝ่ายขาย()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        string cn = "Data Source=.;Initial Catalog=CrocodileFarm; User Id=sa; Password=0000"; // ที่อยู่ของฐานข้อมูล

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 from = new Form15();
            from.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_ล็อคอินพนักงาน from = new frm_ล็อคอินพนักงาน();
            from.Show();
        }

        private void frm_ฝ่ายขาย_Load(object sender, EventArgs e)
        {
            string sql = "SELECT CustID,CustFirstName,CustLastName,CustBDay,CustPhone,CustEmail FROM tbl_ลูกค้า";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "ลูกค้า");
            dataGridView1.DataSource = ds.Tables["ลูกค้า"];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // เลือกข้อมูลจาก GridView มาใส่ใน textbox combobox
            if (e.RowIndex == -1) // ไม่เลือกหรือเลือกอย่างอื่นที่ไม่ใช่ข้อมูล
                return; // จบเงื่อนไข
            else
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                DataRow dr = ds.Tables["ลูกค้า"].Rows[e.RowIndex];
                tb_รหัสลูกค้า.Text = dr["CustID"].ToString();
                tb_ชื่อ.Text = dr["CustFirstName"].ToString();
                tb_นามสกุล.Text = dr["CustLastName"].ToString();
                dtp_BDay.Text = dr["CustBDay"].ToString();
                tb_เบอร์โทร.Text = dr["CustPhone"].ToString();
                tb_อีเมล์.Text = dr["CustEmail"].ToString();
            }
        }

        private void bt_เพิ่ม_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["ลูกค้า"].Select("CustID=" + tb_รหัสลูกค้า.Text + "");
            if (drs.Length == 0) //ไม่มีข้อมูลให้ทำการ Insert
            {
                DataRow dr = ds.Tables["ลูกค้า"].NewRow(); //สร้างแถวใหม่
                dr["CustID"] = tb_รหัสลูกค้า.Text;
                dr["CustFirstName"] = tb_ชื่อ.Text;
                dr["CustLastName"] = tb_นามสกุล.Text;
                dr["CustBDay"] = dtp_BDay.Text;
                dr["CustPhone"] = tb_เบอร์โทร.Text;
                dr["CustEmail"] = tb_อีเมล์.Text;
                ds.Tables["ลูกค้า"].Rows.Add(dr); //เอาข้อมูลใส่ในแถว
            }
            else //มีข้อมูลให้ทำการ Update
            {
                drs[0]["CustFirstName"] = tb_ชื่อ.Text;
                drs[0]["CustLastName"] = tb_นามสกุล.Text;
                drs[0]["CustBDay"] = dtp_BDay.Text;
                drs[0]["CustPhone"] = tb_เบอร์โทร.Text;
                drs[0]["CustEmail"] = tb_อีเมล์.Text;  
            }
            dataGridView1.DataSource = ds.Tables["ลูกค้า"];
        }

        private void bt_ลบ_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["ลูกค้า"].Select("CustID=" + tb_รหัสลูกค้า.Text + "");
            if (drs.Length == 0) //หาไม่เจอให้แจ้งเตือน
                MessageBox.Show("ไม่พบข้อมูลที่ต้องการ");
            else //เจอข้อมูลให้ทำการลบ
            {
                drs[0].Delete(); //ลบข้อมูลในแถว *แต่แถวยังอยู่"
                //ปรับปรุงฐานข้อมูล
                string sql = "SELECT CustID,CustFirstName,CustLastName,CustBDay,CustPhone,CustEmail FROM tbl_ลูกค้า";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "ลูกค้า");

                ds.Tables["ลูกค้า"].AcceptChanges(); //จะทำให้แถวที่ว่างหาย
            }
        }

        private void bt_บันทึก_Click(object sender, EventArgs e)
        {
            string sql = "SELECT CustID,CustFirstName,CustLastName,CustBDay,CustPhone,CustEmail FROM tbl_ลูกค้า";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(ds, "ลูกค้า");
        }

        private void ptb_หน้าแรก_Click(object sender, EventArgs e)
        {

        }

        private void bt_ค้นหา_Click(object sender, EventArgs e)
        {
            string sql = "SELECT CustID,CustFirstName,CustLastName,CustBDay,CustPhone,CustEmail FROM tbl_ลูกค้า WHERE CustID = '" + tb_ค้นหา.Text.Trim() + "' ";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "ลูกค้า");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "ลูกค้า";
        }

        private void bt_เคลียร์_Click(object sender, EventArgs e)
        {
            tb_รหัสลูกค้า.Text = "";
            tb_ชื่อ.Text = "";
            tb_นามสกุล.Text = "";
            dtp_BDay.Text = "";
            tb_เบอร์โทร.Text = "";
            tb_อีเมล์.Text = "";

        }

        private void bt_แก้ไข_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["ลูกค้า"].Select("CustID=" + tb_รหัสลูกค้า.Text + "");
            drs[0]["CustFirstName"] = tb_ชื่อ.Text;
            drs[0]["CustLastName"] = tb_นามสกุล.Text;
            drs[0]["CustBDay"] = dtp_BDay.Text;
            drs[0]["CustPhone"] = tb_เบอร์โทร.Text;
            drs[0]["CustEmail"] = tb_อีเมล์.Text;

            dataGridView1.DataSource = ds.Tables["ลูกค้า"];
        }
    }
}
