using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    public partial class frmNhapSV : Form
    {   DSSV ds= new DSSV(100); 
        int i = 0;
        public frmNhapSV()
        {
            InitializeComponent();
        }
        private void ShowSV(SV sv)
        {
            txtMasv.Text = sv.mssv;
            txtHo.Text = sv.ho;
            txtTen.Text = sv.ten;
            txtMalop.Text = sv.malop;
            cmbPhai.Text = sv.phai;
            dtpNgaysinh.Value = sv.ngaysinh;
            txtNoisinh.Text = sv.noisinh;
            txtDiachi.Text = sv.diachi;

        }
        private void frmNhapNV_Load(object sender, EventArgs e)
        {
            Program.KetNoi(); 
            SqlDataReader dr ;  
            dr  =Program.ExecSqlDataReader("SELECT MASV, HO, TEN, MALOP, PHAI=CASE WHEN PHAI='TRUE' THEN 'Nam' ELSE N'Nữ' END, NGAYSINH, NOISINH,DIACHI FROM SINHVIEN");
            int i = 0;
           
            try
            {
                while (dr.Read())
                {
                    ds.data[i].mssv = dr.GetString(0);
                    ds.data[i].ho = dr.GetString(1);
                    ds.data[i].ten = dr.GetString(2);
                    ds.data[i].malop = dr.GetString(3);
                    ds.data[i].phai = dr.GetString(4);
                    ds.data[i].ngaysinh = dr.GetDateTime(5);
                    ds.data[i].noisinh = dr.GetString(6);
                    ds.data[i].diachi = dr.GetString(7);
                    
                    i++;
                }
                // dr.Close();
                ds.n = i;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            ShowSV(ds.data[0]);
            Program.conn.Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
  
	        if (txtMasv.Text.Trim().CompareTo("")==0) Close ();
	      //  if (ds.Search (txtMasv.Text.Trim())>=0) return ;
            //SV sv = new SV(ds.data[i]); 
            string strLenh = "EXEC GHISV '" + txtMasv.Text +
                  "' , '" + txtHo.Text +
                  "' , '" + txtTen.Text +
                  "' , '" + txtMalop.Text +
                  "' , '" + (cmbPhai.Text == "Nam" ? "TRUE" : "FALSE") +
                  "' , '" + dtpNgaysinh.Value.ToShortDateString() +
                  "' , '" + txtNoisinh.Text +
                  "' , '" + txtDiachi.Text + "'";
            Program.ExecSqlNonQuery(strLenh);

       }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMasv.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            txtMalop.Text = ""; cmbPhai.SelectedIndex = 0;
            dtpNgaysinh.Value  = DateTime.Today ; txtNoisinh.Text = "";
            txtDiachi.Text = "";
        }
     
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (i == ds.n - 1) return;
            i++;
            ShowSV(ds.data[i]);
        }

      

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (i == 0) return;
            i--;
            ShowSV(ds.data[i]);
        }

     
        
    }
}
