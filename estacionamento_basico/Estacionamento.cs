using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamento_basico
{
    internal class Estacionamento
    {
        private string _placa;

        public string Placa
        {
            get => this._placa;
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("A placa não pode ser vazia");
                }

                this._placa = value;
            }

        }

        private DateTime _horarioCadastrado;
        public DateTime HorarioCadastrado{
            get;
            set;
        }
        public string DataHoraCadastrada { get; set; }

        public Estacionamento(string placa)
        {
            this.Placa = placa;
            this._horarioCadastrado = DateTime.Now;
            //HorarioCadastrado = _horarioCadastrado;
            this.DataHoraCadastrada = this._horarioCadastrado.ToString("G");

        }

        public string EstacionamentoToEstring()
        {
            return "Placa do Veiculo | Data e Hora Cadastrada" + "\n" +
                    $"{_placa} \t| \t{DataHoraCadastrada}\n";
        }
    }
}
