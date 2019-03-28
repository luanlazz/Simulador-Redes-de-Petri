using System;
using System.Collections.Generic;

namespace redePetri.rededepetri
{
    public class Transicao
    {
        public string nome { get; set; }
        public Boolean status { get; set; }
        public List<Arco> arcos { get; set; }

        public Transicao()
        {
        }

        public Transicao(string nome)
        {
            this.nome = nome;
            this.status = false;
            this.arcos = new List<Arco>();
        }

        public bool podeExecutar()
        {
            foreach (Arco arco in arcos)
            {
                if (arco.lugar.qtdMarcas < arco.peso)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
