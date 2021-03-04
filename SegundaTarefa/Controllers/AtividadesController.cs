using SegundaTarefa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SegundaTarefa.Controllers
{
    public class AtividadesController : ApiController
    {
        private static List<Atividade> atividades = new List<Atividade>();

        public List<Atividade> Get()
        {
            return atividades;
        }

        public List<Atividade> Post(string nome, string tempo)
        {
            if (!string.IsNullOrEmpty(nome))
                atividades.Add(new Atividade(nome, tempo));

            for(int i = 1; i < atividades.Count; i++)
            {
                Atividade atv = new Atividade(atividades[i].Nome, atividades[i].Hora);

                string[] words2 = atv.Hora.Split(':');

                int x;
                for(x = i -1; i >= 0 && (int.Parse(atividades[x].Hora.Split(':')[0]) > int.Parse(words2[0])) || (int.Parse(atividades[x].Hora.Split(':')[0]) == int.Parse(words2[0]) && int.Parse(atividades[x].Hora.Split(':')[1]) > int.Parse(words2[1])); x--)
                {
                    atividades[x + 1] = atividades[x];

                    if (x - 1 < 0)
                    {
                        x--;
                        break;
                    }
                }
                atividades[x + 1] = atv;
            }

            return atividades;
        }
    }
}
