using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Produtoo
    {
       
            public int IdProduto { get; set; }
            public string Nome { get; set; }
            public double Preco { get; set; }
            public int Quantidade { get; set; }
            public DateTime DataCompra { get; set; }
        
    }
}
