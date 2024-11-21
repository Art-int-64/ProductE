using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp4.Class
{
   public class Products
    {
        public string Type { get; set; } = "";
        public string name { get; set; }
        public int price { get; set; } 

        public string structure { get; set; }

        public string term { get; set; } 
        public string brand { get; set; }

        public string pack { get; set; }
        public string ImageProducts { get; set; } 

        public int CountProducts { get; set; }

       public  Products(string Type,string name, int price,string structure, string term, string brand, string pack,  string ImageProducts) 
        {
            this.Type = Type;
            this.name = name;
            this.ImageProducts = ImageProducts;
            this.price = price;
            this.structure = structure;
            this.term = term;
            this.brand = brand;
            this.pack = pack;
       }

       public  Products(string ImageProducts, string name, int price, int CountProducts, string structure,string term, string brand, string pack) 
        {
            this.ImageProducts = ImageProducts;
            this.price=price;
            this.name = name;
            this.CountProducts = CountProducts;
            this.structure = structure;
            this.term = term;
            this.brand = brand;
            this.pack = pack;
        }
      

    }
}
