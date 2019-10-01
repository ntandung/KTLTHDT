using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Shape
    {
        private float _area;
        private int _color;
        private float _perimeter;


        //Tạo các Properties
        //Thuộc tính diện tích 
        public float Area
        {
            get {  return _area; }
            set {  _area = value; }
        }
        //Thuộc tính màu sắc
        public int Color
        {
            get   {   return _color;     }
            set  {  _color = value;   }
        }
        //Thuộc tính chu vi
        public float Perimeter
        {
            get
            {
                return _perimeter;
            }
            set
            {
                _perimeter = value;
            }
        }

    }
}
