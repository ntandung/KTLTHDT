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
                dt.Rows.Add(new object[] { oItem.Key, Program.getTapMuc(oItem.Value)});
            }

            dgvF.DataSource = dt;

            DataTable dtc = new DataTable();
            dtc.Columns.Add("Tập " + (Program.tapNMuc+=1) + " mục");
            dtc.Columns.Add("Support");
            foreach (var oItem in Program.tinhC(Program.tapF[0]))
            {
                
                dtc.Rows.Add(new object[] { Program.getChiMuc(Program.strToInt(oItem.Key)), oItem.Value });
            }

            dgvC.DataSource = dtc;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TID");
            dt.Columns.Add("Tập các mục");
            foreach (var oItem in Program.sinhF(Program.tapF[0],Program.tinhC(Program.tapF[0])))
            {
                dt.Rows.Add(new object[] { oItem.Key, Program.getTapMuc(oItem.Value) });
            }

            dgvF.DataSource = dt;
        }
    }
}
