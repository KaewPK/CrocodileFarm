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
    public partial class Report_จระเข้ : Form
    {
        public Report_จระเข้()
        {
            InitializeComponent();
        }

        private void bt_ออก_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Report_จระเข้_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void bt_ดูรายงาน_Click(object sender, EventArgs e)
        {
            try
            {
                using (CrocodileFarmEntities1 db = new CrocodileFarmEntities1())
                {
                    tbl_จระเข_BindingSource.DataSource = db.tbl_จระเข_.ToList();
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
