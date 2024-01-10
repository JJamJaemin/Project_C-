using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 상품관리_프로그램
{
    class Vegetable:Product
    {
        public string Id { get; set; }
        public DateTime InDate { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public bool isSoldOut { get; set; }

        public static List<Vegetable> VegetableList = new List<Vegetable>();


        static Vegetable()
        {
            Load();
        }
        public static void Load()
        {
            try
            {
                string vegetableOutput = File.ReadAllText(@"./VegetableList.xml");
                XElement vegetableXElement = XElement.Parse(vegetableOutput);
                VegetableList = (from item in vegetableXElement.Descendants("vegetable")
                              select new Vegetable()
                              {
                                  Id = item.Element("id").Value,
                                  InDate = DateTime.Parse(item.Element("inDate").Value),
                                  Name = item.Element("name").Value,
                                  Price = int.Parse(item.Element("price").Value),
                                  Stock = int.Parse(item.Element("stock").Value),
                                  isSoldOut = item.Element("isSoldOut").Value != "0" ? true : false

                              }).ToList<Vegetable>();
            }
            catch (FileNotFoundException)
            {
                Save();
            }

        }
        public static void Save()
        {
            string vegetableOutput = "";
            vegetableOutput += "<VegetableList>\n";
            foreach (var item in VegetableList)
            {
                vegetableOutput += "<vegetable>\n";
                vegetableOutput += " <id>" + item.Id + "</id>\n";
                vegetableOutput += " <inDate>" + item.InDate + "</inDate>\n";
                vegetableOutput += " <name>" + item.Name + "</name>\n";
                vegetableOutput += " <price>" + item.Price + "</price>\n";
                vegetableOutput += " <stock>" + item.Stock + "</stock>\n";
                vegetableOutput += " <isSoldOut>" + (item.isSoldOut ? 1:0)+ "</isSoldOut>\n";
                vegetableOutput += "</vegetable>\n";

            }
            vegetableOutput += "</VegetableList>\n";

            File.WriteAllText(@"./VegetableList.xml", vegetableOutput);
        }




    }

}
