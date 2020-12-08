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
    public partial class frm_ฝ่ายจัดซื้ออาหารจระเข้ : Form
    {
        public frm_ฝ่ายจัดซื้ออาหารจระเข้()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        string cn = "Data Source=.;Initial Catalog=CrocodileFarm; User Id=sa; Password=0000"; // ที่อยู่ของฐานข้อมูล

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_ล็อคอินพนักงาน from = new frm_ล็อคอินพนักงาน();
            from.Show();
        }

        private void frm_ฝ่ายจัดซื้ออาหารจระเข้_Load(object sender, EventArgs e)
        {
            string sql = "SELECT FoodID,FoodDate,FoodOfood,FoodNumber,FoodPrice FROM tbl_การซื้ออาหารจระเข้";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "การซื้ออาหารจระเข้");
            dataGridView1.DataSource = ds.Tables["การซื้ออาหารจระเข้"];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // เลือกข้อมูลจาก GridView มาใส่ใน textbox combobox
            if (e.RowIndex == -1) // ไม่เลือกหรือเลือกอย่างอื่นที่ไม่ใช่ข้อมูล
                return; // จบเงื่อนไข
            else
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                DataRow dr = ds.Tables["การซื้ออาหารจระเข้"].Rows[e.RowIndex];
                tb_รหัสซื้ออาหาร.Text = dr["FoodID"].ToString();
                dtp_วันที่.Text = dr["FoodDate"].ToString();
                cb_รายการ.Text = dr["FoodOfood"].ToString();
                tb_จำนวน.Text = dr["FoodNumber"].ToString();
                tb_ราคา.Text = dr["FoodPrice"].ToString();
            }
        }

        private void bt_เพิ่ม_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["การซื้ออาหารจระเข้"].Select("FoodID=" + tb_รหัสซื้ออาหาร.Text + "");
            if (drs.Length == 0) //ไม่มีข้อมูลให้ทำการ Insert
            {
                DataRow dr = ds.Tables["การซื้ออาหารจระเข้"].NewRow(); //สร้างแถวใหม่
                dr["FoodID"] = tb_รหัสซื้ออาหาร.Text;
                dr["FoodDate"] = dtp_วันที่.Text;
                dr["FoodOfood"] = cb_รายการ.Text;
                dr["FoodNumber"] = tb_จำนวน.Text;
                dr["FoodPrice"] = tb_ราคา.Text;
                ds.Tables["การซื้ออาหารจระเข้"].Rows.Add(dr); //เอาข้อมูลใส่ในแถว
            }
            else //มีข้อมูลให้ทำการ Update
            {
                drs[0]["FoodDate"] = dtp_วันที่.Text;
                drs[0]["FoodOfood"] = cb_รายการ.Text;
                drs[0]["FoodNumber"] = tb_จำนวน.Text;
                drs[0]["FoodPrice"] = tb_ราคา.Text;
            }
            dataGridView1.DataSource = ds.Tables["การซื้ออาหารจระเข้"];
        }

        private void bt_ลบ_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["การซื้ออาหารจระเข้"].Select("FoodID=" + tb_รหัสซื้ออาหาร.Text + "");
            if (drs.Length == 0) //หาไม่เจอให้แจ้งเตือน
                MessageBox.Show("ไม่พบข้อมูลที่ต้องการ");
            else //เจอข้อมูลให้ทำการลบ
            {
                drs[0].Delete(); //ลบข้อมูลในแถว *แต่แถวยังอยู่"
                //ปรับปรุงฐานข้อมูล
                string sql = "SELECT FoodID,FoodDate,FoodOfood,FoodNumber,FoodPrice FROM tbl_การซื้ออาหารจระเข้";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "การซื้ออาหารจระเข้");

                ds.Tables["การซื้ออาหารจระเข้"].AcceptChanges(); //จะทำให้แถวที่ว่างหาย
            }
        }

        private void bt_บันทึก_Click(object sender, EventArgs e)
        {
            string sql = "SELECT FoodID,FoodDate,FoodOfood,FoodNumber,FoodPrice FROM tbl_การซื้ออาหารจระเข้";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(ds, "การซื้ออาหารจระเข้");
        }

        private void bt_เคลียร์_Click(object sender, EventArgs e)
        {
            tb_รหัสซื้ออาหาร.Text = "";
            dtp_วันที่.Text = "";
            cb_รายการ.Text = "";
            tb_จำนวน.Text = "";
            tb_ราคา.Text = "";
        }

        private void bt_ค้นหา_Click(object sender, EventArgs e)
        {
            string sql = "SELECT FoodID,FoodDate,FoodOfood,FoodNumber,FoodPrice FROM tbl_การซื้ออาหารจระเข้ WHERE FoodID = '" + tb_ค้นหา.Text.Trim() + "' ";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "การซื้ออาหารจระเข้");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "การซื้ออาหารจระเข้";
        }

        private void bt_แก้ไข_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["การซื้ออาหารจระเข้"].Select("FoodID=" + tb_รหัสซื้ออาหาร.Text + "");
            drs[0]["FoodDate"] = dtp_วันที่.Text;
            drs[0]["FoodOfood"] = cb_รายการ.Text;
            drs[0]["FoodNumber"] = tb_จำนวน.Text;
            drs[0]["FoodPrice"] = tb_ราคา.Text;
            dataGridView1.DataSource = ds.Tables["การซื้ออาหารจระเข้"];
        }

        private void bt_ออกจากระบบ_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_ล็อคอินพนักงาน from = new frm_ล็อคอินพนักงาน();
            from.Show();
        }
    }
}
