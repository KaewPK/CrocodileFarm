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
    public partial class Report_ลูกค้า : Form
    {
        public Report_ลูกค้า()
        {
            InitializeComponent();
        }

        private void Report_ลูกค้า_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void bt_ดูรายงาน_Click(object sender, EventArgs e)
        {
            try
            {
                using (CrocodileFarmEntities db = new CrocodileFarmEntities())
                {
                    tbl_ล_กค_าBindingSource.DataSource = db.tbl_ล_กค_า.ToList();
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
