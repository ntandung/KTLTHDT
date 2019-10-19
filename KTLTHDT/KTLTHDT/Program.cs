using System;
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
        // Luu danh sach item theo chi so
        public static List<string> indexMapper = new List<string>();
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


        public static bool CompareTwoLists(List<int> a, List<int> b)
        {
            if (a.Count != b.Count)
                return false;
            for(int i=0; i <a.Count; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Su dung de hien thi cho bang F
        /// Tap cac tap n muc luu duoi dang list<list<int>> => Chuyen sang dang string
        /// Example: 1: CSDL, 2: CSDLPT, 3: VB
        /// {{1,2}, {2,3}, {1,3}} -> {{CSDL, CSDLPT}, {CSDL, VB}, {CSDL, VB}}
        /// </summary>
        /// <param name="idmuc"></param>
        /// <returns></returns>
        public static string GetTapMuc(List<List<int>> idmuc)
        {
            List<string> tapDuLieu = new List<string>();
            foreach(List<int> i in idmuc)
            {
                List<string> tapDuLieu1 = new List<string>();

                foreach (int index in i)
                {
                    tapDuLieu1.Add(Program.indexMapper[index - 1]);
                }
                tapDuLieu.Add("{"+ string.Join(",", tapDuLieu1.ToArray()) + "}");
            }
            
            return string.Join(",", tapDuLieu.ToArray());
        }

        /// <summary>
        /// Su dung de hien thi cho bang L
        /// Moi muc trong bang L duoc luu duoi dang List<int>, Example: {1,2}
        /// Chuyen doi List<int> -> string
        /// Example: 1: CSDL, 2: CSDLPT
        /// {1,2} => {CSDL, CSDPT}
        /// </summary>
        /// <param name="idmuc"></param>
        /// <returns></returns>
        public static string GetChiMuc(List<int> idmuc)
        {
            List<string> tapDuLieu1 = new List<string>();

            foreach (int index in idmuc)
            {
                tapDuLieu1.Add(Program.indexMapper[index - 1]);
            }
            return "{" + string.Join(",", tapDuLieu1.ToArray()) + "}";
        }

        /// <summary>
        /// Tinh tap L tu tap F hien tai
        /// </summary>
        /// <param name="fCurrent"></param>
        /// <returns></returns>
        public static Dictionary<string, float> TinhL(Dictionary<string, List<List<int>>> fCurrent)
        {
            Dictionary<string, float> tmp = new Dictionary<string, float>();
            // Lap lay danh sach cac chi muc thuoc F
            foreach(var item in fCurrent) {
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

            // Cac chi muc cua tap L thoa minSup
            // Loai bo cac tap muc khong thoa minSup
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

        /// <summary>
        /// Thuat toan apriori_gen, sinh ra tap ung vien C tu tap L(k-1)
        /// </summary>
        /// <param name="lPrevious">L(k-1)</param>
        /// <returns></returns>
        public static List<List<int>> AprioriGen(List<List<int>> lPrevious)
        {
            List<List<int>> tmp = new List<List<int>>();
            if (lPrevious.Count <= 1)
                return tmp;
            
            int k = lPrevious[0].Count;
            
            for(int i = 0; i < lPrevious.Count - 1; i++)
            {
                List<int> tmp1 = new List<int>(lPrevious[i]);
                tmp1.RemoveAt(k - 1);
                
                for (int j = i+1; j < lPrevious.Count; j++)
                {
                    List<int> tmp2 = new List<int>(lPrevious[j]);
                    tmp2.RemoveAt(k - 1);
                    
                    if (CompareTwoLists(tmp1, tmp2))
                    {
                        tmp2.Add(lPrevious[i][k-1]);
                        tmp2.Add(lPrevious[j][k-1]);
                        tmp.Add(tmp2);
                    }

                }

            }
            return tmp;
        }

        /// <summary>
        /// Chuyen chuoi string dang "1,2,3" thanh {1,2,3}
        /// </summary>
        /// <param name="strOfIntWithCommas">Example: "1,2,3"</param>
        /// <returns>{1,2,3}</returns>
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

        /// <summary>
        /// Kiem tra tap muc thuoc tid
        /// </summary>
        /// <param name="tid">Transaction id cua F</param>
        /// <param name="muc">Mot muc cua L, Example: {1,2}</param>
        /// <returns></returns>
        public static bool ThuocTid(List<List<int>> tid, List<int> muc)
        {
            List<int> p = new List<int>(muc);
            p.RemoveAt(muc.Count - 1);

            // p: c-c[k] 
            List<int> q = new List<int>(muc);
            q.RemoveAt(muc.Count - 2);

            //q: c-c[k-1] 
            int count = 0;
            foreach(List<int> item in tid)
            {
                if (CompareTwoLists(item, p))
                    count += 1;
                if (CompareTwoLists(item, q))
                    count += 1;
            }
            return count>=2;
        }

        /// <summary>
        /// Sinh ra tap F moi tu F(k-1) va L(k-1)
        /// </summary>
        /// <param name="fPrevious"></param>
        /// <param name="lPrevious"></param>
        /// <returns></returns>
        public static Dictionary<string, List<List<int>>> SinhF(Dictionary<string, List<List<int>>> fPrevious, Dictionary<string, float> lPrevious)
        {
            Program.tapNMuc += 1;
            List<List<int>> tmpLPrevious = new List<List<int>>();
            foreach(string item in lPrevious.Keys)
            {
                tmpLPrevious.Add(StringToInt(item));
            }
            List<List<int>> tapC = AprioriGen(tmpLPrevious);

            Dictionary<string, List<List<int>>> tmp = new Dictionary<string, List<List<int>>>();
            foreach(var fItem in fPrevious)
            {
                List<List<int>> tmp1 = new List<List<int>>();
                foreach (List<int> item in tapC)
                {
                    if(ThuocTid(fItem.Value, item))
                    {
                        tmp1.Add(item);
                    }
                }
                if(tmp1.Count > 0)
                {
                    tmp[fItem.Key] = tmp1;
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
