using System;
using System.Data;
using System.Data.SqlClient;


namespace KTLTHDT
{
    class DatabaseUtils
    {
        private SqlConnection conn = new SqlConnection();

        private String connstr;
        private String servername = "DESKTOP-NG7E5Q6";

        // username
        private String mlogin = "sa";
        // password
        private String password = "123";
        // database name
        private String database = "QLDSV";

        public DatabaseUtils()
        {

        }

        public DatabaseUtils(string servername, string mlogin, string password, string database)
        {
            this.servername = servername;
            this.mlogin = mlogin;
            this.password = password;
            this.database = database;
        }

        

        public int KetNoi()
        {
            if (this.conn != null && this.conn.State == ConnectionState.Open)
                this.conn.Close();
            try
            {
                this.connstr = "Data Source=" + this.servername + ";Initial Catalog=" +
                      this.database + ";User ID=" +
                      this.mlogin + ";password=" + this.password;
                this.conn.ConnectionString = this.connstr;
                this.conn.Open();
                return 1;
            }

            catch (Exception e)
            {
                Console.WriteLine("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message);
                return 0;
            }
        }
        public SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, this.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (this.conn.State == ConnectionState.Closed) this.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader(); return myreader;

            }
            catch (SqlException ex)
            {
                this.conn.Close();
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (this.conn.State == ConnectionState.Closed) this.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public int ExecSqlNonQuery(String strlenh)
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
    }
}
