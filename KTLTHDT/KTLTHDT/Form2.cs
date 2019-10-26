using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace KTLTHDT
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sinh bang F de hien thi len datagridview
        /// </summary>
        /// <param name="fCurrent"></param>
        /// <returns></returns>
        public static DataTable SinhBangF(List<ItemSetsCollection> fCurrent)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("TID");
            dt.Columns.Add("Tập các mục");
            foreach (ItemSetsCollection item in fCurrent)
            {
                dt.Rows.Add(new object[] {item.tid, item.GetDisplay() });
            }

            return dt;
        }

        /// <summary>
        /// Sinh bang L de hien thi len datagridview
        /// </summary>
        /// <param name="lCurrent"></param>
        /// <returns></returns>
        public static DataTable SinhBangL(ItemSetsCollection lCurrent)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tập mục");
            dt.Columns.Add("Support (%)");
            foreach (Itemsets item in lCurrent)
            {
                dt.Rows.Add(new object[] { item.GetDisplay(), item.support });
            }

            return dt;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Program.k = 0;
            Program.tapF.RemoveRange(1, Program.tapF.Count - 1);
            Program.tapL.Clear();
            btnBack.Enabled = false;
            lbTapL.Text = "Tập L " + (Program.k + 1);

            DataTable dt = SinhBangF(Program.tapF[0]);

            dgvF.DataSource = dt;

            ItemSetsCollection tapL = Program.TinhL(Program.tapF[0]);
            DataTable dtc = SinhBangL(tapL);
            dgvL.DataSource = dtc;
            if(Program.TinhL(Program.tapF[0]).Count == 0)
            {
                btnNext.Text = "Sinh Luật";
                lbTapL.Text = "Tập L tổng";
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnBack.Enabled = true;
            if (btnNext.Text.Equals("Sinh Luật"))
            {
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {
                List<ItemSetsCollection> fNext = Program.SinhF(Program.tapF[Program.k], Program.TinhL(Program.tapF[Program.k]));
                lbTapL.Text = "Tập L " + (Program.k + 1);
                DataTable dt = SinhBangF(fNext);
                dgvF.DataSource = dt;

                ItemSetsCollection tapL = Program.TinhL(Program.tapF[Program.k]);

                dgvL.DataSource = SinhBangL(tapL);

                if (tapL.Count == 0)
                {
                    btnNext.Text = "Sinh Luật";
                    lbTapL.Text = "Tập L tổng";
                    dgvL.DataSource = SinhBangL(Program.tapL);
                    dgvF.DataSource = null;
                }
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.tapF.RemoveRange(Program.k, Program.tapF.Count - Program.k);
            Program.k -= 1;
            DataTable dt = SinhBangF(Program.tapF[Program.k]);
            lbTapL.Text = "Tập L " + (Program.k + 1);
            dgvF.DataSource = dt;
            var tapL = Program.TinhL(Program.tapF[Program.k]);

            dgvL.DataSource = SinhBangL(tapL);

            if (tapL.Count == 0)
            {
                btnNext.Text = "Sinh Luật";
                lbTapL.Text = "Tập L tổng";
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
