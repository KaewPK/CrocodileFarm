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
    public partial class frm_ฝ่ายขาย_แก้ไขสถานะ_ : Form
    {
        public frm_ฝ่ายขาย_แก้ไขสถานะ_()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        string cn = "Data Source=.;Initial Catalog=CrocodileFarm; User Id=sa; Password=0000"; // ที่อยู่ของฐานข้อมูล

        private void bt_ย้อนกลับ_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 from = new Form15();
            from.Show();
        }

        private void bt_บันทึก_Click(object sender, EventArgs e)
        {
            string sql = "SELECT CroID,CroBirth,CroWeight,CroLength,CroPrice,CroStatus FROM tbl_จระเข้";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(ds, "จระเข้");
        }

        private void bt_เคลียร์_Click(object sender, EventArgs e)
        {
            tb_รหัสจระเข้.Text = "";
            tb_จำนวน.Text = "";
        }

        private void bt_เพิ่ม_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["จระเข้"].Select("CroID=" + tb_รหัสจระเข้.Text + "");
            if (drs.Length == 0) //ไม่มีข้อมูลให้ทำการ Insert
            {
                DataRow dr = ds.Tables["จระเข้"].NewRow(); //สร้างแถวใหม่
                dr["CroID"] = tb_รหัสจระเข้.Text;
                dr["CroNum"] = tb_จำนวน.Text;
                ds.Tables["จระเข้"].Rows.Add(dr); //เอาข้อมูลใส่ในแถว
            }
            else //มีข้อมูลให้ทำการ Update
            {
                drs[0]["CroNum"] = tb_จำนวน.Text;
            }
            dataGridView1.DataSource = ds.Tables["จระเข้"];
        }

        private void bt_แก้ไข_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["จระเข้"].Select("CroID=" + tb_รหัสจระเข้.Text + "");
            drs[0]["CroNum"] = tb_จำนวน.Text;

            dataGridView1.DataSource = ds.Tables["จระเข้"];
        }

        private void bt_ออกจากระบบ_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_ล็อคอินพนักงาน from = new frm_ล็อคอินพนักงาน();
            from.Show();
        }

        private void bt_ค้นหา_Click(object sender, EventArgs e)
        {
            string sql = "SELECT CroID,CroCategory,CroBirth,CroPrice,CroNum FROM tbl_จระเข้ WHERE CroID = '" + tb_ค้นหา.Text.Trim() + "' ";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "จระเข้");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "จระเข้";
        }

        private void frm_ฝ่ายขาย_แก้ไขสถานะ__Load(object sender, EventArgs e)
        {
            string sql = "SELECT CroID,CroCategory,CroBirth,CroPrice,CroNum FROM tbl_จระเข้";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "จระเข้");
            dataGridView1.DataSource = ds.Tables["จระเข้"];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // เลือกข้อมูลจาก GridView มาใส่ใน textbox combobox
            if (e.RowIndex == -1) // ไม่เลือกหรือเลือกอย่างอื่นที่ไม่ใช่ข้อมูล
                return; // จบเงื่อนไข
            else
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                DataRow dr = ds.Tables["จระเข้"].Rows[e.RowIndex];
                tb_รหัสจระเข้.Text = dr["CroID"].ToString();
                tb_จำนวน.Text = dr["CroNum"].ToString();
            }
        }
    }
}
