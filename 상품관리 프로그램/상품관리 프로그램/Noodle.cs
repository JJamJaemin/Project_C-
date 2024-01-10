using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 상품관리_프로그램
{
    class Noodle:Product
    {
        public string Id { get; set; }
        public DateTime InDate { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public bool isSoldOut { get; set; }

        public static List<Noodle> NoodleList = new List<Noodle>();
        

       static Noodle()
        {
            Load();
        }
        public static void Load()
        {
            try
            {
                string noodleOutput = File.ReadAllText(@"./NoodleList.xml");
                XElement noodleXElement = XElement.Parse(noodleOutput);
                NoodleList = (from item in noodleXElement.Descendants("noodle")
                               select new Noodle()
                               {
                                   Id = item.Element("id").Value,
                                   InDate = DateTime.Parse(item.Element("inDate").Value),
                                   Name = item.Element("name").Value,
                                   Price = int.Parse(item.Element("price").Value),
                                   Stock = int.Parse(item.Element("stock").Value),
                                   isSoldOut = item.Element("isSoldOut").Value != "0" ? true : false

                               }).ToList<Noodle>();
            }
            catch (FileNotFoundException)
            {
                Save();
            }

        }
        public static void Save()
        {
            string noodleOutput = "";
            noodleOutput += "<NoodleList>\n";
            foreach (var item in NoodleList)
            {
                noodleOutput += "<noodle>\n";
                noodleOutput += " <id>" + item.Id + "</id>\n";
                noodleOutput += " <inDate>" + item.InDate + "</inDate>\n";
                noodleOutput += " <name>" + item.Name + "</name>\n";
                noodleOutput += " <price>" + item.Price + "</price>\n";
                noodleOutput += " <stock>" + item.Stock + "</stock>\n";
                noodleOutput += " <isSoldOut>" + (item.isSoldOut ? 1:0) + "</isSoldOut>\n";
                noodleOutput += "</noodle>\n";

            }
            noodleOutput += "</NoodleList>\n";

            File.WriteAllText(@"./NoodleList.xml", noodleOutput);
        }

        

        
    }
    
}
