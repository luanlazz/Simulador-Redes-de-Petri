using System;
using SimuladorRedesPetri;

namespace redePetri.rededepetri
{
    public class Lugar
    {
        public string nome { get; set; }
        public int qtdMarcas { get; set; }

        public Lugar()
        {
        }

        public Lugar(string nome, int qtdMarcas)
        {
            this.nome = nome;
            this.qtdMarcas = qtdMarcas;
        }

        public void retiraMarca(int marcas)
        {
            if (marcas > this.qtdMarcas)
            {
                throw new RedePetriException("Quantidade de marcas indisponivel");
            }
            this.qtdMarcas -= marcas;
        }

        public void adicionaMarca(int marcas)
        {
            this.qtdMarcas += marcas;
        }
    }
}
