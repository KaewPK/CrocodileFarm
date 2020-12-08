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
    public partial class Report_กาซื้ออาหารจระเข้ : Form
    {
        public Report_กาซื้ออาหารจระเข้()
        {
            InitializeComponent();
        }

        private void Report_กาซื้ออาหารจระเข้_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void bt_ดูรายงาน_Click(object sender, EventArgs e)
        {
            try
            {
                using (CrocodileFarmEntities6 db = new CrocodileFarmEntities6())
                {
                    tbl_การซ__ออาหารจระเข_BindingSource.DataSource = db.tbl_การซ__ออาหารจระเข_.ToList();
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_ออก_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
