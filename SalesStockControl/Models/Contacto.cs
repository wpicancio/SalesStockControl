using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStockControl.Models
{
    public class Contacto
    {
        private Guid _guidContacto;
        private string _nome;
        private string _nif;
        private string _morada;
        private string _telemovel;

        public string guidContacto
        {
            get { return _guidContacto.ToString(); }
        }
        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value.Trim();
                if (_nome.Length == 0)
                {
                    _nome = "Anónimo";
                }
            }
        }
        public string Nif
        {
            get { return _nif; }
            set
            {
                _nif = value.Trim();
                if (_nif.Length == 0)
                {
                    _nif = "---------";
                }
            }
        }
        public string Morada
        {
            get { return _morada; }
            set
            {
                _morada = value.Trim();
                if (_morada.Length == 0)
                {
                    _morada = "Desconhecida";
                }
            }
        }
        public string Telemovel
        {
            get { return _telemovel; }
            set
            {
                _telemovel = value.Trim();
                if (_telemovel.Length == 0)
                {
                    _telemovel = "Sem Nº de telemovel!";
                }
            }
        }

        public Contacto()
        {
            _guidContacto = Guid.NewGuid();
            Nome = "";
            Nif = "";
            Morada = "";
        }
        public virtual string Get()
        {
            return "Guid Cliente: " + guidContacto + "\n" +
                   "Nome: " + Nome + "\n" +
                   "NIF: " + Nif + "\n" +
                   "Morada: " + Morada + "\n";
        }
    }
}
