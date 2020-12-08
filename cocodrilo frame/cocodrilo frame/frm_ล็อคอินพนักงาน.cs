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
    public partial class frm_ล็อคอินพนักงาน : Form
    {
        public frm_ล็อคอินพนักงาน()
        {
            InitializeComponent();
            tb_รหัสผ่าน.PasswordChar = '*';
            tb_รหัสผ่าน.MaxLength = 10;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (tb_ชื่อผู้ใช้งาน.Text == "AAAA" && tb_รหัสผ่าน.Text == "1111")
            {
                this.Hide();
                frm_เจ้าของฟาร์ม main = new frm_เจ้าของฟาร์ม();
                main.Show();
            }
            else if (tb_ชื่อผู้ใช้งาน.Text == "BBBB" && tb_รหัสผ่าน.Text == "2222")
            {
                this.Hide();
                frm_ผู้เลี้ยง main = new frm_ผู้เลี้ยง();
                main.Show();
            }
            else if (tb_ชื่อผู้ใช้งาน.Text == "CCCC" && tb_รหัสผ่าน.Text == "3333")
            {
                this.Hide();
                frm_ฝ่ายขาย main = new frm_ฝ่ายขาย();
                main.Show();
            }
            else if (tb_ชื่อผู้ใช้งาน.Text == "DDDD" && tb_รหัสผ่าน.Text == "4444")
            {
                this.Hide();
                frm_ฝ่ายการเงิน main = new frm_ฝ่ายการเงิน();
                main.Show();
            }
            else if (tb_ชื่อผู้ใช้งาน.Text == "EEEE" && tb_รหัสผ่าน.Text == "5555")
            {
                this.Hide();
                frm_ฝ่ายบัญชี main = new frm_ฝ่ายบัญชี();
                main.Show();
            }
            else if (tb_ชื่อผู้ใช้งาน.Text == "GGGG" && tb_รหัสผ่าน.Text == "6666")
            {
                this.Hide();
                frm_ฝ่ายจัดซื้ออาหารจระเข้ main = new frm_ฝ่ายจัดซื้ออาหารจระเข้();
                main.Show();
            }
        }
    }
}
