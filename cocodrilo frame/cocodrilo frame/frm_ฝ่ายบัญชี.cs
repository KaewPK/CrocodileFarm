using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cocodrilo_frame
{
    public partial class frm_ฝ่ายบัญชี : Form
    {
        public frm_ฝ่ายบัญชี()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_ล็อคอินพนักงาน from = new frm_ล็อคอินพนักงาน();
            from.Show();
        }

        private void bt_Rลูกค้า_Click(object sender, EventArgs e)
        {
            Report_ลูกค้า main = new Report_ลูกค้า();
            main.Show();
        }

        private void bt_Rจระเข้_Click(object sender, EventArgs e)
        {
            Report_จระเข้ main = new Report_จระเข้();
            main.Show();
        }

        private void bt_Rสั่งซื้อ_Click(object sender, EventArgs e)
        {
            Report_การสั่งซื้อ main = new Report_การสั่งซื้อ();
            main.Show();
        }

        private void bt_Rชำระเงิน_Click(object sender, EventArgs e)
        {
            Report_การชำระเงิน main = new Report_การชำระเงิน();
            main.Show();
        }

        private void bt_Rใบเสร็จ_Click(object sender, EventArgs e)
        {
            Report_ใบเสร็จ main = new Report_ใบเสร็จ();
            main.Show();
        }

        private void bt_Rซื้ออาหาร_Click(object sender, EventArgs e)
        {
            Report_กาซื้ออาหารจระเข้ main = new Report_กาซื้ออาหารจระเข้();
            main.Show();
        }
    }
}
