using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStockControl.Models
{
    public class Produto
    {
        private Guid _guidProduto;
        private string _carroModelo;
        private string _marca;
        private int _ano;
        private decimal _preco;
        private int _quantidadeEstoque;
  
        public string GuiProduto
        {
            get { return _guidProduto.ToString(); }
        }

        public string CarroModelo
        {
            get { return _carroModelo; }
            set
            {
                _carroModelo = value.Trim();
                if (_carroModelo.Length == 0)
                {
                    _carroModelo = "Não inforamado";
                }
            }
        }
        public string Marca
        {
            get { return _marca; }
            set
            {
                _marca = value.Trim();
                if (_marca.Length == 0)
                {
                    _marca = "Não inforamado";
                }
            }
        }
        public int Ano
        {
            get { return _ano; }
            set
            {
                _ano = value;
                if (_ano < 2005)
                {
                    _ano = 2005;
                }
            }
        }


        public decimal Preco
        {
            get { return _preco; }
            set
            {
                _preco = value;
                if (_preco < 0)
                {
                    _preco = 0;
                }
            }
        }

        public int QuantidadeEstoque
        {
            get { return _quantidadeEstoque; }
            set
            {
                _quantidadeEstoque = value;
                if (_quantidadeEstoque < 0)
                {
                    _quantidadeEstoque = 0;
                }
            }
        }

        public Produto()
        {
            _guidProduto = Guid.NewGuid();
            CarroModelo = " ";
            Ano = 2005;
            Marca = " ";
            QuantidadeEstoque = 0;
            Preco = 0;
        }
        public virtual string Get()
        {
            string saida = $"GUID PRODUTO: {_guidProduto}\n" +
                            $"Marca: {Marca}\n" +
                            $"Modole do Carro: {CarroModelo}\n" +
                            $"Ano: : {Ano}\n" +
                            $"Preço: {Preco}\n" +
                            $"Quantidade: {QuantidadeEstoque}\n";
            return saida;
        }

    }
}
