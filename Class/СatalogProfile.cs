using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp4.Class
{
    static class CatalogProfile
    {
       public static  List<Profile> ProfileList = new List<Profile> {new Profile("admin","123abker$", "891853336612", "g1w2t3r4t5@gmail.com", "img_408797_1.png"),
       new Profile(" "," ","891853336612", "g1w2t3r4t5@gmail.com","img_408797_1.png")
       };
       public static int IdUser {get; set;}
       public static int KodEmail { get; set; }
    }
}
