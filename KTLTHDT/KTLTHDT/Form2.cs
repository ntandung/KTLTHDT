﻿using System;
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

        public static DataTable SinhBangF(Dictionary<string, List<List<int>>> fCurrent)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("TID");
            dt.Columns.Add("Tập các mục");
            foreach (var item in fCurrent)
            {
                dt.Rows.Add(new object[] { item.Key, Program.GetTapMuc(item.Value) });
            }

            return dt;
        }


        public static DataTable SinhBangL(Dictionary<string, float> lCurrent)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Tập " + (Program.k + 1) + " mục");
            dt.Columns.Add("Support (%)");
            foreach (var item in lCurrent)
            {
                dt.Rows.Add(new object[] { Program.GetChiMuc(Program.StringToInt(item.Key)), item.Value });
                //Program.tapL[item.Key] = item.Value;
            }

            return dt;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Program.k = 0;
            Program.tapF.RemoveRange(1, Program.tapF.Count - 1);
            Program.tapL.Clear();
            btnBack.Enabled = false;

            DataTable dt = SinhBangF(Program.tapF[0]);

            dgvF.DataSource = dt;

            Dictionary<string, float> tapL = Program.TinhL(Program.tapF[0]);
            DataTable dtc = SinhBangL(tapL);
            dgvL.DataSource = dtc;
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
                var fNext = Program.SinhF(Program.tapF[Program.k], Program.TinhL(Program.tapF[Program.k]));
                DataTable dt = SinhBangF(fNext);
                dgvF.DataSource = dt;

                var tapL = Program.TinhL(Program.tapF[Program.k]);

                dgvL.DataSource = SinhBangL(tapL);

                if (tapL.Count == 0)
                {
                    btnNext.Text = "FINISH";
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
            dgvF.DataSource = dt;


            DataTable dtc = new DataTable();
            dtc.Columns.Add("Tập " + (Program.k + 1) + " mục");
            dtc.Columns.Add("Support (%)");
            var tapL = Program.TinhL(Program.tapF[Program.k]);
            foreach (var item in tapL)
            {

                dtc.Rows.Add(new object[] { Program.GetChiMuc(Program.StringToInt(item.Key)), item.Value });
                //Program.tapL[item.Key] = item.Value;
            }

            dgvL.DataSource = dtc;

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
