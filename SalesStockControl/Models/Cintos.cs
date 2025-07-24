using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SalesStockControl.Models.Airbag;

namespace SalesStockControl.Models
{
    public class Cintos : Produto
    {
        public enum TipoCinto
        {
            laser,
            normal,
            preTensor
        }

        private TipoCinto _tipo;

        public TipoCinto Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public Cintos(TipoCinto tipo) : base()
        {
            Tipo = tipo;
            switch (tipo)
            {
                case TipoCinto.laser:
                    Preco = 100;
                    break;
                case TipoCinto.normal:
                    Preco = 70;
                    break;
                case TipoCinto.preTensor:
                    Preco = 50;
                    break;
            }
        }

        public override string Get()
        {
            string saida = base.Get();
            saida += $"Preço:  {Preco} \n";
            return saida;
        }
    }
}
