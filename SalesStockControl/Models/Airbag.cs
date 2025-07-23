using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SalesStockControl.Models.Airbag;

namespace SalesStockControl.Models
{
    public class Airbag : Produto
    {
        public enum TipoAirBag
        {
            volante,
            cortina,
            banco,
            passageiro,
            joelho
        }
        private TipoAirBag _tipo;
        public TipoAirBag Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public Airbag(TipoAirBag tipo) : base()
        {
            Tipo = tipo;

            // Preço fixo com base no tipo
            switch (tipo)
            {
                case TipoAirBag.volante:
                    Preco = 200.00m;
                    break;
                case TipoAirBag.cortina:
                    Preco = 100.00m;
                    break;
                case TipoAirBag.banco:  
                    Preco = 70.00m;
                    break;
                case TipoAirBag.passageiro:
                    Preco = 120.00m;
                    break;
                case TipoAirBag.joelho:
                    Preco = 80.00m;
                    break;
            }
        }
        public override string Get()
        {
            string saida = base.Get();
            saida += $"Tipo do AirBag:  {Tipo}\n";
            saida += $"Preço:  {Preco} \n";
            return saida;
        }
    }
}
