using System;
using System.Collections.Generic;

namespace redePetri.rededepetri
{
    public class Transicao
    {
        public string nome { get; set; }
        public bool podeExecutar { get; set; }
        public List<Arco> arcos { get; set; } = new List<Arco>();
        public List<Lugar> lugaresEntrada { get; set; } = new List<Lugar>();
        public List<Lugar> lugaresSaida { get; set; } = new List<Lugar>();

        // TODO: Não repetir os lugares na mesma transicao

        public Transicao()
        {
            podeExecutar = false;
        }

        public Transicao(string nome) : this()
        {
            this.nome = nome;
        }

        public void PodeExecutar()
        {
            foreach (Lugar lugar in lugaresEntrada)
            {
                if (lugar.qtdMarcas < lugar.arco.peso)
                {
                    podeExecutar = false;
                }
                else
                {
                    podeExecutar = true;
                }
            }
        }
    }
}
