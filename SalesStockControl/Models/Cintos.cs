using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStockControl.Models
{
    public class Cintos : Produto
    {
        private bool _preTensor;

        public bool PreTensor
        {
            get { return _preTensor; }
            set
            {
                _preTensor = value;
                string tem = _preTensor ? "Não" : "Sim";
            }
        }
        public Cintos()
        {
            PreTensor = true;
        }

        public override string Get()
        {
            string saida = base.Get();
            saida += $"Tem prétensor: {PreTensor}\n";
            return saida;
        }
    }
}
