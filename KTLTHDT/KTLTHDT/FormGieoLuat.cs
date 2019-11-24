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
            string chuoiCacMonHoc = "";

            foreach (DataRowView itemChecked in CheckListBoxMonHoc.CheckedItems)
            {
                chuoiCacMonHoc += itemChecked["MAMH"]+",";
            }
            chuoiCacMonHoc = chuoiCacMonHoc.Remove(chuoiCacMonHoc.Length-1,1);
            chuoiCacMonHoc = chuoiCacMonHoc.Replace(" ", String.Empty);

            DatabaseUtils dbUtils = new DatabaseUtils();
            dbUtils.KetNoi();
            dbUtils.ExecSqlNonQuery("EXEC SP_GENDIEM " +TxtNumRow.Text+","+TxtMinSup.Text + ",'"+chuoiCacMonHoc+"'");
            //dbUtils.ExecSqlNonQuery("EXEC SP_GENDIEM 10,80,'GT1,GT2'");

            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
    }
}
