using System;
using redePetri.rededepetri;
using System.Collections.Generic;
using SimuladorRedesPetri.rededepetri.simulador;
using SimuladorRedesPetri.rededepetri;

namespace SimuladorRedesPetri
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Lugar> lugares = new List<Lugar>();
                List<Transicao> transicoes = new List<Transicao>();
                List<Arco> arcos = new List<Arco>();

                Console.Write("Quantos lugares: ");
                int qtdLugar = int.Parse(Console.ReadLine());

                for (int i = 1; i <= qtdLugar; i++)
                {
                    Console.Write($"Quantas marcas em L{i}? ");
                    int qtdMarcas = int.Parse(Console.ReadLine());

                    lugares.Add(new Lugar($"L{i}", qtdMarcas));
                }

                Console.Write("Quantas transicões: ");
                int qtdTransicoes = int.Parse(Console.ReadLine());

                for (int i = 1; i <= qtdTransicoes; i++)
                {
                    Console.Write($"Quais são os lugares de entrada de T{i}? ");
                    string[] arrayLugares = Console.ReadLine().Split(",");

                    Transicao transicao = new Transicao($"T{i}");
                    transicoes.Add(transicao);

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

                foreach (Arco arco in arcos)
                {
                    Console.Write($"Qual o peso do arco de ${arco.lugar.nome} para ${arco.transicao.nome}? ");
                    arco.peso = int.Parse(Console.ReadLine());
                }

                SimuladorRedePetri simulador = new SimuladorRedePetri(lugares, transicoes, arcos);

                while (!simulador.terminada)
                {
                    Tela.imprimirSimulacao(simulador);

                    simulador.terminada = true;

                }
            } catch (RedePetriException e)
            {
                Console.Write(e.Message);
            }

        }
    }
}
