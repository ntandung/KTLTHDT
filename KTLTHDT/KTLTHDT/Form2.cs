using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTLTHDT
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TID");
            dt.Columns.Add("Tập các mục");
            foreach (var oItem in Program.tapF[0])
            {
                string value = "";
                foreach(int val in oItem.Value)
                {
                    value = val + ",";
                }
                dt.Rows.Add(new object[] { oItem.Key, value });
            }

            dgvF.DataSource = dt;
        }
    }
}
