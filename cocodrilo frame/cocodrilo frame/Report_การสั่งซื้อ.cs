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
    public partial class Report_การสั่งซื้อ : Form
    {
        public Report_การสั่งซื้อ()
        {
            InitializeComponent();
        }

        private void Report_การสั่งซื้อ_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void bt_ดูรายงาน_Click(object sender, EventArgs e)
        {
            try
            {
                using (CrocodileFarmEntities3 db = new CrocodileFarmEntities3())
                {
                    tbl_การส__งซ__อBindingSource.DataSource = db.tbl_การส__งซ__อ.ToList();
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
