using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KTLTHDT
{
    public partial class Form1 : Form
    {
        private DataGridView tapGiaoTacGridView = new DataGridView();
        DataTable dataTable;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.KetNoi();
            dataTable = Program.ExecSqlDataTable("EXEC SP_GIAOTAC "+ txtMinSup.Text);
            dgv1.DataSource = dataTable;
            Program.conn.Close();
        }

        private void btnTimD_Click(object sender, EventArgs e)
        {
            Program.KetNoi();
            dataTable = Program.ExecSqlDataTable("EXEC SP_GIAOTAC " + txtMinSup.Text);
            dgv1.DataSource = dataTable;
            Program.conn.Close();
        }

        private void btnTimItemSets_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
