using System;
using System.Data;
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
            Program.k = 0;
            Program.tapF.RemoveRange(1, Program.tapF.Count - 1);
            Program.tapL.Clear();
            btnBack.Enabled = false;

            DataTable dt = new DataTable();
            dt.Columns.Add("TID");
            dt.Columns.Add("Tập các mục");
            foreach (var oItem in Program.tapF[0])
            {
                dt.Rows.Add(new object[] { oItem.Key, Program.GetTapMuc(oItem.Value)});
            }

            dgvF.DataSource = dt;

            DataTable dtc = new DataTable();
            dtc.Columns.Add("Tập " + (Program.k + 1) + " mục");
            dtc.Columns.Add("Support (%)");
            foreach (var oItem in Program.TinhL(Program.tapF[0]))
            {
                
                dtc.Rows.Add(new object[] { Program.GetChiMuc(Program.StringToInt(oItem.Key)), oItem.Value });
                Program.tapL[oItem.Key] = oItem.Value;
            }

            dgvC.DataSource = dtc;
            if(Program.TinhL(Program.tapF[0]).Count == 0)
            {
                btnNext.Text = "FINISH";
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnBack.Enabled = true;
            if (btnNext.Text.Equals("FINISH"))
            {
                Form3 form3 = new Form3();
                form3.ShowDialog();
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("TID");
                dt.Columns.Add("Tập các mục");
                foreach (var item in Program.SinhF(Program.tapF[Program.k], Program.TinhL(Program.tapF[Program.k])))
                {
                    dt.Rows.Add(new object[] { item.Key, Program.GetTapMuc(item.Value) });
                }

                dgvF.DataSource = dt;


                DataTable dtc = new DataTable();
                dtc.Columns.Add("Tập " + (Program.k + 1) + " mục");
                dtc.Columns.Add("Support (%)");
                var tapL = Program.TinhL(Program.tapF[Program.k]);
                foreach (var item in tapL)
                {

                    dtc.Rows.Add(new object[] { Program.GetChiMuc(Program.StringToInt(item.Key)), item.Value });
                    Program.tapL[item.Key] = item.Value;
                }

                dgvC.DataSource = dtc;

                if (tapL.Count == 0)
                {
                    btnNext.Text = "FINISH";
                }
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.tapF.RemoveRange(Program.k, Program.tapF.Count - Program.k);
            Program.k -= 1;
            DataTable dt = new DataTable();
            dt.Columns.Add("TID");
            dt.Columns.Add("Tập các mục");
            foreach (var item in Program.tapF[Program.k])
            {
                dt.Rows.Add(new object[] { item.Key, Program.GetTapMuc(item.Value) });
            }

            dgvF.DataSource = dt;


            DataTable dtc = new DataTable();
            dtc.Columns.Add("Tập " + (Program.k + 1) + " mục");
            dtc.Columns.Add("Support (%)");
            var tapL = Program.TinhL(Program.tapF[Program.k]);
            foreach (var item in tapL)
            {

                dtc.Rows.Add(new object[] { Program.GetChiMuc(Program.StringToInt(item.Key)), item.Value });
                Program.tapL[item.Key] = item.Value;
            }

            dgvC.DataSource = dtc;

            if (tapL.Count == 0)
            {
                btnNext.Text = "FINISH";
            }
            else
            {
                btnNext.Text = "NEXT";
            }

            if (Program.k == 0)
            {
                btnBack.Enabled = false;
            }
        }
    }
}
