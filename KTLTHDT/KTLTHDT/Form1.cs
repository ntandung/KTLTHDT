using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace KTLTHDT
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Goi SP_GIAOTAC tu db de lay du lieu tap D
        /// Tong so giao tac bang tong so dong cua data lay ve
        /// Tinh lai Program.sup
        /// Cap nhat lai indexMapper
        /// </summary>
        /// <param name="minSup"></param>
        /// <returns></returns>
        public static DataTable TimD(int minSup)
        {
            DataTable dataTable;
            Program.KetNoi();
            dataTable = Program.ExecSqlDataTable("EXEC SP_GIAOTAC " + minSup);
            Program.tongSoGiaoTac = dataTable.Rows.Count;
            Program.sup = (int)Math.Ceiling((float)(minSup * Program.tongSoGiaoTac / 100.0));
            Program.conn.Close();

            Program.indexMapper.Clear();
            for (int j = 1; j < dataTable.Columns.Count; j++)
            {
                Program.indexMapper.Add(dataTable.Columns[j].ColumnName.ToString());
            }

            return dataTable;
        }


        /// <summary>
        /// Lap tren datatable lay tu sql server do ve, Kiem tra cac ceil co gia tri la 1 thi them vao F
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static Dictionary<string, List<List<int>>> SinhTapFTuTapD(DataTable dataTable)
        {
            Dictionary<string, List<List<int>>> fResults = new Dictionary<string, List<List<int>>>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                List<List<int>> tapCacMuc = new List<List<int>>();
                for (int j = 1; j < dataTable.Columns.Count; j++)
                {
                    if (dataTable.Rows[i][j].ToString().Equals("1"))
                    {
                        List<int> muc = new List<int>();
                        muc.Add(j);
                        tapCacMuc.Add(muc);
                    }
                }
                fResults[dataTable.Rows[i][0].ToString()] = tapCacMuc;
            }
            return fResults;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dataTable = TimD(int.Parse(txtMinSup.Text));
            dgv1.DataSource = dataTable;
            Program.tapF.Add(SinhTapFTuTapD(dataTable));
        }

        private void btnTimD_Click(object sender, EventArgs e)
        {
            DataTable dataTable = TimD(int.Parse(txtMinSup.Text));
            dgv1.DataSource = dataTable;
            Program.tapF[0] = SinhTapFTuTapD(dataTable);
        }

        private void btnTimItemSets_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

    }
}
