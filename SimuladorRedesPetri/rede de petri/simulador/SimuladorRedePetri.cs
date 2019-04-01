using System;
using System.Collections.Generic;
using redePetri.rededepetri;

namespace SimuladorRedesPetri.rededepetri.simulador
{
    public class SimuladorRedePetri
    {
        public int numCiclo { get; set; }
        public bool terminada { get; set; }
        public List<Lugar> lugares { get; set; } = new List<Lugar>();
        public List<Transicao> transicoes { get; set; } = new List<Transicao>();
        public List<Arco> arcos { get; set; } = new List<Arco>();
        private List<Transicao> filaTransicoes = new List<Transicao>();

        public SimuladorRedePetri()
        {
            numCiclo = 0;
            terminada = false;
        }

        public SimuladorRedePetri(List<Lugar> lugares, List<Transicao> transicoes, List<Arco> arcos) :
            this()
        {
            this.lugares = lugares;
            this.transicoes = transicoes;
            this.arcos = arcos;
        }

        public void ExecutaCiclo()
        {
            filaTransicoes.Clear();
            TransacoesHabilitadas();
            if (filaTransicoes.Count == 0)
            {
                terminada = true;
                Tela.ImprimeSimulacaoFinalizada();
                return;
            }

            foreach (Transicao transicao in filaTransicoes)
            {
                ExecutaTransicao(transicao);
            }

            numCiclo++;
        }

        public void TransacoesHabilitadas()
        {
            foreach (Transicao transicao in transicoes)
            {
                transicao.PodeExecutar();
                if (transicao.podeExecutar)
                {
                    filaTransicoes.Add(transicao);
                }
            }
        }

        public void ExecutaTransicao(Transicao transicao)
        {
            if (transicao.podeExecutar)
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

        public void RecebeLugares() {
            Console.Write("Quantos lugares: ");
            int qtdLugar = int.Parse(Console.ReadLine());

            for (int i = 1; i <= qtdLugar; i++)
            {
                Console.Write($"Quantas marcas em L{i}? ");
                int qtdMarcas = int.Parse(Console.ReadLine());

                lugares.Add(new Lugar($"L{i}", qtdMarcas));
            }
        }

        public void RecebeTransicoes() {

            Console.Write("Quantas transicões: ");
            int qtdTransicoes = int.Parse(Console.ReadLine());

            for (int i = 1; i <= qtdTransicoes; i++)
            {
                Transicao transicao = new Transicao($"T{i}");
                transicoes.Add(transicao);

                RecebeLugaresEntrada(transicao);
                RecebeLugaresSaida(transicao);
            }
        }

        private void RecebeLugaresEntrada(Transicao transicao)
        {
            Console.Write($"Quais são os lugares de entrada de {transicao.nome}? ");
            string[] arrayLugares = Console.ReadLine().Split(",");

            if (arrayLugares.Length > 0)
            {
                foreach (string nome in arrayLugares)
                {
                    Lugar lugar = lugares.Find(obj => obj.nome == nome);

                    Arco arco = new Arco(lugar, transicao);
                    arcos.Add(arco);

                    lugar.arco = arco;
                    transicao.arcos.Add(arco);
                    transicao.lugaresEntrada.Add(lugar);
                }
            }
        }

        private void RecebeLugaresSaida(Transicao transicao)
        {
            Console.Write($"Quais são os lugares de saida de {transicao.nome}? ");
            string[] arrayLugares = Console.ReadLine().Split(",");

            if (arrayLugares.Length > 0)
            {
                foreach (string nome in arrayLugares)
                {
                    Lugar lugar = lugares.Find(obj => obj.nome == nome);

                    Arco arco = new Arco(lugar, transicao);
                    arcos.Add(arco);

                    lugar.arco = arco;
                    transicao.arcos.Add(arco);
                    transicao.lugaresSaida.Add(lugar);
                }
            }
        }

        public void RecebePesoArcos()
        {
            foreach (Transicao transicao in transicoes)
            {
                foreach (Lugar lugar in transicao.lugaresEntrada)
                {
                    Console.Write($"Qual o peso do arco de ${lugar.nome} para ${transicao.nome}? ");
                    lugar.arco.peso = int.Parse(Console.ReadLine());
                }
                foreach (Lugar lugar in transicao.lugaresSaida)
                {
                    Console.Write($"Qual o peso do arco de ${transicao.nome} para ${lugar.nome}? ");
                    lugar.arco.peso = int.Parse(Console.ReadLine());
                }
            }
        }
    }
}
