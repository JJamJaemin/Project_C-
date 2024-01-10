using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 상품관리_프로그램
{
    class Snack:Product
    {
        public string Id { get; set; }
        public DateTime InDate { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public bool isSoldOut { get; set; }

        public static List<Snack> SnackList = new List<Snack>();


        static Snack()
        {
            Load();
        }
        public static void Load()
        {
            try
            {
                string snackOutput = File.ReadAllText(@"./SnackList.xml");
                XElement snackXElement = XElement.Parse(snackOutput);
                SnackList = (from item in snackXElement.Descendants("snack")
                                 select new Snack()
                                 {
                                     Id = item.Element("id").Value,
                                     InDate = DateTime.Parse(item.Element("inDate").Value),
                                     Name = item.Element("name").Value,
                                     Price = int.Parse(item.Element("price").Value),
                                     Stock = int.Parse(item.Element("stock").Value),
                                     isSoldOut = item.Element("isSoldOut").Value != "0" ? true : false

                                 }).ToList<Snack>();
            }
            catch (FileNotFoundException)
            {
                Save();
            }

        }
        public static void Save()
        {
            string snackOutput = "";
            snackOutput += "<SnackList>\n";
            foreach (var item in SnackList)
            {
                snackOutput += "<snack>\n";
                snackOutput += " <id>" + item.Id + "</id>\n";
                snackOutput += " <inDate>" + item.InDate + "</inDate>\n";
                snackOutput += " <name>" + item.Name + "</name>\n";
                snackOutput += " <price>" + item.Price + "</price>\n";
                snackOutput += " <stock>" + item.Stock + "</stock>\n";
                snackOutput += " <isSoldOut>" + (item.isSoldOut ? 1:0) + "</isSoldOut>\n";
                snackOutput += "</snack>\n";

            }
            snackOutput += "</SnackList>\n";

            File.WriteAllText(@"./SnackList.xml", snackOutput);
        }
    }
}
