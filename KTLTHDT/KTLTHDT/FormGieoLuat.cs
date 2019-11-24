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
    public partial class FormGieoLuat : Form
    {
        public FormGieoLuat()
        {
            InitializeComponent();
        }

        private void FormGieoLuat_Load(object sender, EventArgs e)
        {
            DataTable dataTable;
            DatabaseUtils dbUtils = new DatabaseUtils();
            dbUtils.KetNoi();
            dataTable = dbUtils.ExecSqlDataTable("EXEC SP_DSMONHOC");
            CheckListBoxMonHoc.DataSource = dataTable;
            CheckListBoxMonHoc.ValueMember = "MAMH";
            CheckListBoxMonHoc.DisplayMember = "TENMH";
        }

        private void BtnSinhData_Click(object sender, EventArgs e)
        {

        }
    }
}
