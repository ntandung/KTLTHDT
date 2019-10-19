﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace KTLTHDT
{
    class Program
    {

        public static SqlConnection conn = new SqlConnection();
        public static String connstr;
        public static int tapNMuc = 0;
        public static int tongSoGiaoTac = 0;
        public static int sup = 0;
        public static List<string> mahoaDL = new List<string>();
        public static Dictionary<string, float> tapL = new Dictionary<string, float>();
        public static List<Dictionary<string, List<List<int>>>> tapF = new List<Dictionary<string, List<List<int>>>>();

        // Nhap server name
        public static String servername = "DESKTOP-NG7E5Q6";
        public static String username = "";

        // username
        public static String mlogin = "sa";
        // password
        public static String password = "123";
        // database name
        public static String database = "QLDSV";

        public static string GetTapMuc(List<List<int>> idmuc)
        {
            List<string> tapDuLieu = new List<string>();
            foreach(List<int> i in idmuc)
            {
                List<string> tapDuLieu1 = new List<string>();

                foreach (int index in i)
                {
                    tapDuLieu1.Add(Program.mahoaDL[index - 1]);
                }
                tapDuLieu.Add("{"+ string.Join(",", tapDuLieu1.ToArray()) + "}");
            }
            
            return string.Join(",", tapDuLieu.ToArray());
        }

        public static string GetChiMuc(List<int> idmuc)
        {
            List<string> tapDuLieu1 = new List<string>();

            foreach (int index in idmuc)
            {
                tapDuLieu1.Add(Program.mahoaDL[index - 1]);
            }
            return "{" + string.Join(",", tapDuLieu1.ToArray()) + "}";
        }

        public static Dictionary<string, float> TinhL(Dictionary<string, List<List<int>>> f)
        {
            Dictionary<string, float> tmp = new Dictionary<string, float>();
            foreach(var item in f) {
                foreach (var j in item.Value)
                {
                    string key = GetChiMuc(j);
                    key = string.Join(",", j);
                    if (tmp.ContainsKey(key))
                        tmp[key] += 1;
                    else
                    {
                        tmp[key] = 1;
                    }
                }
            }
            Dictionary<string, float> tmp1 = new Dictionary<string, float>(tmp);
            foreach (var i in tmp1)
            {
                if (i.Value >= Program.sup)
                {
                    tmp[i.Key] = (float)(i.Value) / Program.tongSoGiaoTac * 100;
                }
                else
                {
                    tmp.Remove(i.Key);
                }
            }
            return tmp;
        }

        public static List<List<int>> AprioriGen(List<List<int>> L_previous)
        {
            List<List<int>> tmp = new List<List<int>>();
            if (L_previous.Count <= 1)
                return tmp;
            int k = L_previous[0].Count;
            for(int i = 0; i < L_previous.Count - 1; i++)
            {
                List<int> tmp_i = new List<Int32>(L_previous[i]);
                tmp_i.RemoveAt(k - 1);
                int sumi = tmp_i.Count > 0 ? Convert.ToInt32(string.Join("", tmp_i)) : 0;
                for (int j = i+1; j < L_previous.Count; j++)
                {
                    List<int> tmp_j = new List<Int32>(L_previous[j]);
                    tmp_j.RemoveAt(k - 1);
                    int sumj = tmp_j.Count > 0 ?  Convert.ToInt32(string.Join("", tmp_j)) : 0;
                    if (sumi == sumj)
                    {
                        tmp_j.Add(L_previous[i][k-1]);
                        tmp_j.Add(L_previous[j][k-1]);
                        tmp.Add(tmp_j);
                    }

                }

            }
            return tmp;
        }

        public static List<int> StringToInt(string strOfIntWithCommas)
        {
            string[] items = strOfIntWithCommas.Split(',');
            List<int> tmp = new List<int>();
            foreach (string item in items)
            {
                tmp.Add(Convert.ToInt32(item));
            }
            return tmp;
        }

        public static bool ThuocTid(List<List<int>> tid, List<int> chimuc)
        {
            List<string> tmp = new List<string>();

            foreach(List<int> item in tid)
            {
                tmp.Add(string.Join(",", item));
            }
            List<int> tmp_t1 = new List<int>(chimuc);
            tmp_t1.RemoveAt(chimuc.Count - 1);
            
            List<int> tmp_t2 = new List<int>(chimuc);
            tmp_t2.RemoveAt(chimuc.Count - 2);

            string t1 = string.Join("", tmp_t1);
            string t2 = string.Join("", tmp_t2);
            int count = 0;
            foreach(string item in tmp)
            {
                if (item.Equals(t1))
                    count += 1;
                if (item.Equals(t2))
                    count += 1;
            }
            return count>=2;
        }

        public static Dictionary<string, List<List<int>>> SinhF(Dictionary<string, List<List<int>>> f_previous, Dictionary<string, float> tapL)
        {
            Program.tapNMuc += 1;
            List<string> keys = new List<string>(tapL.Keys);
            List<List<int>> tapC = new List<List<int>>();
            foreach(string item in keys)
            {
                tapC.Add(StringToInt(item));
            }
            List<List<int>> rs = AprioriGen(tapC);

            Dictionary<string, List<List<int>>> tmp = new Dictionary<string, List<List<int>>>();
            foreach(var f_item in f_previous)
            {
                List<List<int>> tmp1 = new List<List<int>>();
                foreach (List<int> item in rs)
                {
                    if(ThuocTid(f_item.Value, item))
                    {
                        tmp1.Add(item);
                    }
                }
                if(tmp1.Count > 0)
                {
                    tmp[f_item.Key] = tmp1;
                }
            }
            Program.tapF.Add(tmp);
            return tmp;
        }
        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open)
                Program.conn.Close();
            try
            {
                Program.connstr = "Data Source=" + Program.servername + ";Initial Catalog=" +
                      Program.database + ";User ID=" +
                      Program.mlogin + ";password=" + Program.password;
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return 1;
            }

            catch (Exception e)
            {
                Console.WriteLine("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message);
                return 0;
            }
        }
        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader(); return myreader;

            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            // TODO: Exception in SP_GIAOTAC
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static int ExecSqlNonQuery(String strlenh)
        {
            SqlCommand Sqlcmd = new SqlCommand(strlenh, conn);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut 
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery(); conn.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                conn.Close();
                return ex.State; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
        }
        static void Main(string[] args)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
    }
}
