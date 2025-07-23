using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStockControl.Models
{
    public class Cliente : Contacto
    {
        private string _nomeDaOficina;
        private DateTime _dateCad;

        [PrimaryKey, AutoIncrement] //data annotations for SQLite
        public int AutoId { get; set; }

        // Propriedade: data de cadastro do cliente no sistema
        public DateTime DateCad
        {
            get { return _dateCad; }
            set { _dateCad = value; }
        }

        public string NomeDaOficina
        {
            get { return _nomeDaOficina; }
            set
            {
                _nomeDaOficina = value.Trim();
                if (_nomeDaOficina.Length == 0)
                {
                    _nomeDaOficina = "Não informado!";
                }

            }
        }

        public Cliente() : base()
        {
            NomeDaOficina = "";
            DateCad = DateTime.Now;
 
        }

        public override string Get()
        {
            string saida = base.Get();
            saida += $"Nome da Oficina: {NomeDaOficina}\n";
            saida += $"Data de Cadastro: {DateCad:dd/MM/yyyy}\n";
            return saida;
        }
    }
}
