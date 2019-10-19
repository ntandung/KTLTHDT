using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace KTLTHDT
{
    public partial class Form1 : Form
    {
        DataTable dataTable;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.KetNoi();
            dataTable = Program.ExecSqlDataTable("EXEC SP_GIAOTAC "+ txtMinSup.Text);
            Program.tongSoGiaoTac = dataTable.Rows.Count;
            Program.sup = (int)Math.Ceiling((float)(Convert.ToInt32(txtMinSup.Text) * Program.tongSoGiaoTac / 100.0));
            dgv1.DataSource = dataTable;
            Program.conn.Close();
            Dictionary<string, List<List<int>>> t = new Dictionary<string, List<List<int>>>();

            for (int j = 1; j < dataTable.Columns.Count; j++)
                Program.mahoaDL.Add(dataTable.Columns[j].ColumnName.ToString());

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                List<List<int>> tmp = new List<List<int>>();

                for (int j = 1; j < dataTable.Columns.Count; j++)
                {

                    if (dataTable.Rows[i][j].ToString().Equals("1"))
                    {
                        List<int> tmp1 = new List<int>();
                        tmp1.Add(j);
                        tmp.Add(tmp1);
                    }
                }
                t[dataTable.Rows[i][0].ToString()] = tmp;
            }
            Program.tapF.Add(t);
        }

        private void btnTimD_Click(object sender, EventArgs e)
        {
            Program.KetNoi();
            dataTable = Program.ExecSqlDataTable("EXEC SP_GIAOTAC " + txtMinSup.Text);
            Program.sup = (int)Math.Ceiling((float)(Convert.ToInt32(txtMinSup.Text) * Program.tongSoGiaoTac / 100.0));
            dgv1.DataSource = dataTable;
            Program.conn.Close();
            Dictionary<string, List<List<int>>> t = new Dictionary<string, List<List<int>>>();

            Program.mahoaDL.Clear();
            for (int j = 1; j < dataTable.Columns.Count; j++)
            {
                Program.mahoaDL.Add(dataTable.Columns[j].ColumnName.ToString());
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                List<List<int>> tmp = new List<List<int>>();

                for (int j = 1; j < dataTable.Columns.Count; j++)
                {

                    if (dataTable.Rows[i][j].ToString().Equals("1"))
                    {
                        List<int> tmp1 = new List<int>();
                        tmp1.Add(j);
                        tmp.Add(tmp1);
                    }
                }
                t[dataTable.Rows[i][0].ToString()] = tmp;
            }
            Program.tapF[0] = t;
        }

        private void btnTimItemSets_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
