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
            Program.tapNMuc = 0;
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
            dtc.Columns.Add("Tập " + (Program.tapNMuc + 1) + " mục");
            dtc.Columns.Add("Support");
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
                foreach (var oItem in Program.SinhF(Program.tapF[Program.tapNMuc], Program.TinhL(Program.tapF[Program.tapNMuc])))
                {
                    dt.Rows.Add(new object[] { oItem.Key, Program.GetTapMuc(oItem.Value) });
                }

                dgvF.DataSource = dt;


                DataTable dtc = new DataTable();
                dtc.Columns.Add("Tập " + (Program.tapNMuc + 1) + " mục");
                dtc.Columns.Add("Support");
                var tapC = Program.TinhL(Program.tapF[Program.tapNMuc]);
                foreach (var oItem in tapC)
                {

                    dtc.Rows.Add(new object[] { Program.GetChiMuc(Program.StringToInt(oItem.Key)), oItem.Value });
                    Program.tapL[oItem.Key] = oItem.Value;
                }

                dgvC.DataSource = dtc;

                if (Program.TinhL(Program.tapF[Program.tapNMuc]).Count == 0)
                {
                    btnNext.Text = "FINISH";
                }
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            Program.tapNMuc -= 1;
            DataTable dt = new DataTable();
            dt.Columns.Add("TID");
            dt.Columns.Add("Tập các mục");
            foreach (var oItem in Program.tapF[Program.tapNMuc])
            {
                dt.Rows.Add(new object[] { oItem.Key, Program.GetTapMuc(oItem.Value) });
            }

            dgvF.DataSource = dt;


            DataTable dtc = new DataTable();
            dtc.Columns.Add("Tập " + (Program.tapNMuc + 1) + " mục");
            dtc.Columns.Add("Support");
            var tapC = Program.TinhL(Program.tapF[Program.tapNMuc]);
            foreach (var oItem in tapC)
            {

                dtc.Rows.Add(new object[] { Program.GetChiMuc(Program.StringToInt(oItem.Key)), oItem.Value });
                Program.tapL[oItem.Key] = oItem.Value;
            }

            dgvC.DataSource = dtc;

            if (tapC.Count == 0)
            {
                btnNext.Text = "FINISH";
            }
            else
            {
                btnNext.Text = "NEXT";
            }
            if (Program.tapNMuc == 0)
            {
                btnBack.Enabled = false;
            }
        }
    }
}
