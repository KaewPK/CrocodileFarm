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
    public partial class Report_ใบเสร็จ : Form
    {
        public Report_ใบเสร็จ()
        {
            InitializeComponent();
        }

        private void bt_ดูรายงาน_Click(object sender, EventArgs e)
        {
            try
            {
                using (CrocodileFarmEntities5 db = new CrocodileFarmEntities5())
                {
                    tbl_ใบเสร_จBindingSource.DataSource = db.tbl_ใบเสร_จ.ToList();
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

        private void Report_ใบเสร็จ_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
