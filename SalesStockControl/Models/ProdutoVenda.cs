using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStockControl.Models
{
    public class ProdutoVenda
    {
        private Produto? _produto;
        private int _quantidade;
        private decimal _total;

        public Produto? Produto
        {
            get { return _produto; }
            set
            {
                _produto = value;
                // Atualiza o total sempre que o produto ou quantidade for alterado
                if (_produto != null)
                {
                    CalcularTotal();
                }
                else
                {
                    _total = 0;
                }
            }
        }
        public int Quantidade
        {
            get { return _quantidade; }
            set
            {
                _quantidade = value < 0 ? 0 : value; //se valor for menor que zero, valor é zero, se nao valor e o valor
                CalcularTotal();
            }
        }
        public decimal Total
        {
            get { return _total; }
        }
        public decimal CalcularTotal()
        {
            _total = Quantidade * Produto.Preco;
            return _total;
        }

        public ProdutoVenda(Produto produtos)
        {
            Quantidade = 0;//
            Produto = produtos; //Atribui o produto recebido à propriedade interna. Perfeito.
            CalcularTotal();
        }
        public string Get()
        {
            return $"Quantidade: {Quantidade}\n" +
                   $"Preço: {Produto.Preco}\n" +
                   $"Total: {Total}";
        }
    }
}
