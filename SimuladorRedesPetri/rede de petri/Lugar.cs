using System;

namespace redePetri.rededepetri
{
    public class Lugar
    {
        public string nome { get; set; }
        public int marca { get; set; }

        public Lugar()
        {
        }

        public Lugar(string nome, int marca)
        {
            this.nome = nome;
            this.marca = marca;
        }
    }
}
