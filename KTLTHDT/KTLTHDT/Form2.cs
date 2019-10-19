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
            Program.tapNMuc = 0;
            Program.tapF.RemoveRange(1, Program.tapF.Count - 1);
            Program.tapL.Clear();

            DataTable dt = new DataTable();
            dt.Columns.Add("TID");
            dt.Columns.Add("Tập các mục");
            foreach (var oItem in Program.tapF[0])
            {
                dt.Rows.Add(new object[] { oItem.Key, Program.getTapMuc(oItem.Value)});
            }

            dgvF.DataSource = dt;

            DataTable dtc = new DataTable();
            dtc.Columns.Add("Tập " + (Program.tapNMuc + 1) + " mục");
            dtc.Columns.Add("Support");
            foreach (var oItem in Program.tinhC(Program.tapF[0]))
            {
                
                dtc.Rows.Add(new object[] { Program.getChiMuc(Program.strToInt(oItem.Key)), oItem.Value });
                Program.tapL[oItem.Key] = oItem.Value;
            }

            dgvC.DataSource = dtc;
            if(Program.tinhC(Program.tapF[0]).Count == 0)
            {
                btnNext.Text = "Finish";
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (btnNext.Text.Equals("Finish"))
            {
                Form3 form3 = new Form3();
                form3.ShowDialog();
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("TID");
                dt.Columns.Add("Tập các mục");
                foreach (var oItem in Program.sinhF(Program.tapF[Program.tapNMuc], Program.tinhC(Program.tapF[Program.tapNMuc])))
                {
                    dt.Rows.Add(new object[] { oItem.Key, Program.getTapMuc(oItem.Value) });
                }

                dgvF.DataSource = dt;


                DataTable dtc = new DataTable();
                dtc.Columns.Add("Tập " + (Program.tapNMuc + 1) + " mục");
                dtc.Columns.Add("Support");
                var tapC = Program.tinhC(Program.tapF[Program.tapNMuc]);
                foreach (var oItem in tapC)
                {

                    dtc.Rows.Add(new object[] { Program.getChiMuc(Program.strToInt(oItem.Key)), oItem.Value });
                    Program.tapL[oItem.Key] = oItem.Value;
                }

                dgvC.DataSource = dtc;

                if (Program.tinhC(Program.tapF[Program.tapNMuc]).Count == 0)
                {
                    btnNext.Text = "Finish";
                }
            }
            
        }
    }
}
