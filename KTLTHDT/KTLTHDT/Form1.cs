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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.KetNoi();
            DataTable dataAdapter;
            dataAdapter = Program.ExecSqlDataTable("EXEC SP_GIAOTAC 50");
            dgv1.DataSource = dataAdapter;
            
            Program.conn.Close();
        }
    }
}
