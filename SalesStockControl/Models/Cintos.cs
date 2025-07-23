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
            normal
        }
        private bool _preTensor;
        private TipoCinto _tipo;

        public bool PreTensor
        {
            get { return _preTensor; }
            set
            {
                _preTensor = value;
                string tem = _preTensor ? "Não" : "Sim";
            }
        }

        public TipoCinto Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public Cintos(TipoCinto tipo) : base()
        {
            PreTensor = true;
            switch (tipo)
            {
                case TipoCinto.laser:
                    Preco = 100;
                    break;
                case TipoCinto.normal:
                    Preco = 70;
                    break;
            }
            Preco = Preco + (_preTensor ? 50 : 0);
        }

        public override string Get()
        {
            string saida = base.Get();
            saida += $"Tem prétensor: {PreTensor}\n";
            saida += $"Preço:  {Preco} \n";
            return saida;
        }
    }
}
