using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ__Language_Integrated_Query_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // LINQ to XML
            XElement kitaplarXml = new XElement("Kitaplar",
                new XElement("Kitap", new XAttribute("Id", 1), new XElement("Ad", "C# Programlama"), new XElement("Fiyat", 120)),
                new XElement("Kitap", new XAttribute("Id", 2), new XElement("Ad", "Veritabanı"), new XElement("Fiyat", 90)),
                new XElement("Kitap", new XAttribute("Id", 3), new XElement("Ad", "Yapay Zeka"), new XElement("Fiyat", 150))
            );

            var pahaliKitaplar = from kitap in kitaplarXml.Elements("Kitap")
                                 where (int)kitap.Element("Fiyat") > 100
                                 select kitap.Element("Ad").Value;

            Console.WriteLine("Fiyatı 100 TL'den fazla olan kitaplar (LINQ to XML):");
            foreach (var ad in pahaliKitaplar)
                Console.WriteLine(ad);

            // LINQ to SQL (sadece örnekleme)
            // var db = new VeritabaniContext();
            // var kullanicilar = from k in db.Kullanicilar
            //                    where k.Yas > 18
            //                    select k.Isim;

            // foreach (var isim in kullanicilar)
            //     Console.WriteLine(isim);

            Console.WriteLine("\n(Not: LINQ to SQL için gerçek bir veritabanı bağlantısı gereklidir.)");
        }
    }
}
