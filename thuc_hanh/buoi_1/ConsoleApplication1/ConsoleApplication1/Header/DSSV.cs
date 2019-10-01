using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public struct SV
    {
        string _mssv; string _ho, _ten, _malop, _phai,  _noisinh, _diachi;
        DateTime _ngaysinh;
        
        public string mssv
        {
            get { return _mssv; }
            set { _mssv = value; }
        }
        public string ho
        {
            get { return _ho; }
            set { _ho = value; }
        }
        public string ten
        {
            get { return _ten; }
            set { _ten = value; }
        }
        public string malop
        {
            get { return _malop; }
            set { _malop = value; }
        }
        public string phai
        {
            get { return _phai; }
            set { _phai = value ; }
        }
        public DateTime  ngaysinh
        {
            get { return _ngaysinh; }
            set { _ngaysinh = value; }
        }
        public string noisinh
        {
            get { return _noisinh; }
            set { _noisinh = value; }
        }
        public string diachi
        {
            get { return _diachi; }
            set { _diachi = value; }
        }
       
    }
    public class DSSV
    {   int _n;    
        public  SV[] data;
       
        public int n
        {
          get { return _n; }
          set { _n = value; }
        } 
        public DSSV(int N)
        {
            n = N;
            data = new SV[N];
        }
        public int Search(string x)
        {
            for (int i = 0; i < n; i++)
                if (data[i].mssv == x) return i;
            return -1;
        }
       
		 
    }
}
