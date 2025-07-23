using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStockControl.Models
{
    public class Tabelies : Produto
    {
        private string _cor;

        public string Cor
        {
            get { return _cor; }
            set
            {
                _cor = value.Trim();
                if (_cor.Length == 0)
                {
                    _cor = "Não Informada";
                }
            }
        }
        public Tabelies()
        {
            Cor = "";
        }
        public override string Get()
        {
            string saida = base.Get();
            saida += $"Cor:  {Cor} \n";
            return saida;
        }
    }
}
