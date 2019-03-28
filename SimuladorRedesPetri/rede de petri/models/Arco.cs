using System;

namespace redePetri.rededepetri
{
    public class Arco
    {
        public Lugar lugar { get; set; }
        public Transicao transicao { get; set; }
        public int peso { get; set; }

        public Arco()
        {
        }

        public Arco(Lugar lugar, Transicao transicao)
        {
            this.lugar = lugar;
            this.transicao = transicao;
        }


    }
}
