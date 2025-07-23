using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStockControl.Models
{
    public  class Venda
    {
        private Guid _GuidId;
        private Cliente _cliente;
        private DateTime _date;
        private decimal _total;
        private List<ProdutoVenda>? _produtoVenda;

        public Guid GuidId { get { return _GuidId; } }

        [PrimaryKey, AutoIncrement] //data annotations for SQLite
        public int AutoId { get; set; }
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public List<ProdutoVenda> ProdutoVenda
        {
            get { return _produtoVenda ;}
            set {  _produtoVenda = value; }
        }

        public decimal Total
        {
            get { return _total; }
            set { _total = TotalVenda(); }
        }
        public decimal TotalVenda()
        {
            decimal total = 0;
            foreach(var produtoVenda in ProdutoVenda)
            {
                total += produtoVenda.CalcularTotal();
            }
            return total;
        }
        public Venda ()
        {
            _GuidId = Guid.NewGuid();
            Cliente = new Cliente();
            Date = DateTime.Now;
            Total = 0;
            ProdutoVenda = new List<ProdutoVenda> ();
        }

    }
}
