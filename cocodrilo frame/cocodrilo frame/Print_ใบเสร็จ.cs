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
    public partial class Print_ใบเสร็จ : Form
    {
        public Print_ใบเสร็จ()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        string cn = "Data Source=.;Initial Catalog=CrocodileFarm; User Id=sa; Password=0000"; // ที่อยู่ของฐานข้อมูล

        private void Print_ใบเสร็จ_Load(object sender, EventArgs e)
        {
            string sql = "SELECT BillID,BillDate,PayID,CustID,CustFristName,CustLastName,CroID,CroCategory,CroPrice,CroNum,OrderPrice FROM tbl_ใบเสร็จ ";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "ใบเสร็จ");
        }

        private void bt_ค้นหา_Click(object sender, EventArgs e)
        {
            string sql = "SELECT BillID,BillDate,PayID,CustID,CustFristName,CustLastName,CroID,CroCategory,CroPrice,CroNum,OrderPrice FROM tbl_ใบเสร็จ WHERE PayID = '" + tb_ค้นหา.Text.Trim() + "' ";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "ใบเสร็จ");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "ใบเสร็จ";
        }

        private void bt_ออก_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.ShowDialog();
        }
    }
}
