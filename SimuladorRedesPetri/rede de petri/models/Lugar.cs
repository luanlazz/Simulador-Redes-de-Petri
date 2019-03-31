using System;
using SimuladorRedesPetri;

namespace redePetri.rededepetri
{
    public class Lugar
    {
        public string nome { get; set; }
        public int qtdMarcas { get; set; }
        public Arco arco { get; set; }

        public Lugar()
        {
        }

        public Lugar(string nome, int qtdMarcas)
        {
            this.nome = nome;
            this.qtdMarcas = qtdMarcas;
        }

        public void RetiraMarca()
        {
            if (arco.peso > qtdMarcas)
            {
                throw new RedePetriException("Quantidade de marcas indisponivel");
            }
            qtdMarcas -= arco.peso;
        }

        public void AdicionaMarca()
        {
            qtdMarcas += arco.peso;
        }
    }
}
