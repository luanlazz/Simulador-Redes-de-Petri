using System;
using System.Collections.Generic;

namespace redePetri.rededepetri
{
    public class Transicao
    {
        public string nome { get; set; }
        public bool status { get; set; }
        public List<Arco> arcos { get; set; }
        public List<Lugar> lugaresEntrada { get; set; } = new List<Lugar>();
        public List<Lugar> lugaresSaida { get; set; } = new List<Lugar>();

        // TODO: Não repetir os lugares na mesma transicao

        public Transicao()
        {
        }

        public Transicao(string nome)
        {
            this.nome = nome;
            status = false;
            arcos = new List<Arco>();
        }

        public bool PodeExecutar()
        {
            foreach (Lugar lugar in lugaresEntrada)
            {
                if (lugar.qtdMarcas < lugar.arco.peso)
                {
                    return false;
                }
            }
            status = true;
            return true;
        }
    }
}
