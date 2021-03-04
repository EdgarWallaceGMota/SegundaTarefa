using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegundaTarefa.Models
{
    public class Atividade
    {
        public string Nome { get; set; }
        public string Hora { get; set; }

        public Atividade(string texto, string tempo)
        {
            this.Nome = texto;
            this.Hora = tempo;
        }
    }
}