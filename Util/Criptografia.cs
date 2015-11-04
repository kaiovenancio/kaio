using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Util
{
     public class Criptografia
    {
         public static string Encriptar(string valor)
         {
             try
             {
                 MD5 md5 = new MD5CryptoServiceProvider();
                 md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(valor));
                 byte[] resultado = md5.Hash;

                 string saida = string.Empty;
                 for (int i = 0; i < resultado.Length; i++)
                 {
                     saida += resultado[i].ToString("x");
                 }
                 return saida;
             }
             catch 
             {
                 
                 throw;
             }
         }
    }
}
