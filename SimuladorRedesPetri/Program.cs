using System;
using redePetri.rededepetri;
using System.Collections.Generic;

namespace SimuladorRedesPetri
{
    class Program
    {
        static void Main(string[] args)
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

                foreach (string l in arrayLugares)
                {
                    Lugar lugar = lugares.Find(obj => obj.nome == l);

                    Transicao transicao = new Transicao($"T{i}");

                    Arco arco = new Arco(lugar, transicao);
                    arcos.Add(arco);

                    transicao.arcos.Add(arco);
                    transicoes.Add(transicao);
                }
            }

            foreach (Arco arco in arcos)
            {
                Console.Write($"Qual o peso do arco de ${arco.lugar.nome} para ${arco.transicao.nome}? ");
                arco.peso = int.Parse(Console.ReadLine());
            }



        }
    }
}
