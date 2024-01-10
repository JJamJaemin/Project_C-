using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 상품관리_프로그램
{
    internal class Product
    {
        



        public string Id { get; set; }
        public string InDate { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Stock { get; set; }
        public string isSoldOut { get; set; }

        public int Sum { get; set; }
        public Product()
        {

        }
    }

}
