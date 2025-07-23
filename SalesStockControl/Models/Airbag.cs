using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Airbag() : base()
        {
            Tipo = TipoAirBag.volante; // padrão ao acessar o tipo de airbag
        }
        public override string Get()
        {
            string saida = base.Get();
            saida += $"Tipo do AirBag:  {Tipo}\n";
            return saida;
        }
    }
}
