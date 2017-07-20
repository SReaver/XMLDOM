using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLDOM
{

    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrderGuid { get; set; }
        public string UserId { get; set; }

        //public void Tostring()
        //{
        //    Console.WriteLine("Id");
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Order ord = new Order();
            ord.Name = "Serg";
            ord.Id = 1;
            ord.OrderGuid = "D8f8D337-2A84-4B42-A003-B3FCC8413CDC";
            ord.UserId = "2";
            CreateXmlUsingSysXml(ord);
        }


        static void CreateXmlUsingSysXml(Order order)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(declaration);

            XmlElement rootElemet = doc.CreateElement("orders");

            XmlElement orderElement = doc.CreateElement("order");
            orderElement.SetAttribute("Id", order.Id.ToString());
            orderElement.SetAttribute("OrderGuid", order.OrderGuid.ToString());
            rootElemet.AppendChild(orderElement);

            XmlElement orderElem_userId = doc.CreateElement("UserId");
            orderElem_userId.InnerText = order.UserId.ToString();
            orderElem_userId.SetAttribute("UserId", "D8f8D337-2A84-4B42-A003-B3FCC8413CDC");
            rootElemet.AppendChild(orderElem_userId);

            XmlElement orderElem_Name = doc.CreateElement("Name");
            orderElem_Name.InnerText = order.Name;
            rootElemet.AppendChild(orderElem_Name);

            doc.AppendChild(rootElemet);
            doc.Save("test.xml");

        }

    }
}
