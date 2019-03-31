using System;
using System.Collections.Generic;
using redePetri.rededepetri;

namespace SimuladorRedesPetri.rededepetri.simulador
{
    public class SimuladorRedePetri
    {
        public int numCiclo { get; set; }
        public bool terminada { get; set; }
        public List<Lugar> lugares { get; set; }
        public List<Transicao> transicoes { get; set; }
        public List<Arco> arcos { get; set; }
        private List<Transicao> filaTransicoes = new List<Transicao>();

        public SimuladorRedePetri()
        {
        }

        public SimuladorRedePetri(List<Lugar> lugares, List<Transicao> transicoes, List<Arco> arcos)
        {
            numCiclo = 0;
            terminada = false;
            this.lugares = lugares;
            this.transicoes = transicoes;
            this.arcos = arcos;
        }

        public void ExecutaCiclo()
        {
            foreach (Transicao transicao in transicoes)
            {
                if (transicao.PodeExecutar())
                {
                    filaTransicoes.Add(transicao);
                }
            }
            foreach (Transicao transicao in filaTransicoes)
            {
                ExecutaTransicao(transicao);
            }

            numCiclo++;
        }

        public void ExecutaTransicao(Transicao transicao)
        {
            if (transicao.status == true)
            {
                foreach (Lugar lugar in transicao.lugaresEntrada)
                {
                    lugar.RetiraMarca();
                }
                foreach (Lugar lugar in transicao.lugaresSaida)
                {
                    lugar.AdicionaMarca();
                }
            }
        }

    }
}
