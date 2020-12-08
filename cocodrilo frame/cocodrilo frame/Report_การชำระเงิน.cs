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
    public partial class Report_การชำระเงิน : Form
    {
        public Report_การชำระเงิน()
        {
            InitializeComponent();
        }

        private void bt_ดูรายงาน_Click(object sender, EventArgs e)
        {
            try
            {
                using (CrocodileFarmEntities4 db = new CrocodileFarmEntities4())
                {
                    tbl_การชำระเง_นBindingSource.DataSource = db.tbl_การชำระเง_น.ToList();
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

        private void Report_การชำระเงิน_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
