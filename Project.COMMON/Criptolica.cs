using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON
{
    public static class Criptolica
    {
        //sifrelede gez 
        
        // ilk char ı yakala sona at 
        // değişkene at dondur
        public static string Crip(string sifrele)
        {
          
            for (int i = sifrele.Length -1; i >= 0; i++)
            {

                sifrele = sifrele[i].ToString();
            }
            return sifrele;
        }
        public static string DeCrip(string sifreyiCoz)
        {
            return sifreyiCoz;
        }
    }
}
