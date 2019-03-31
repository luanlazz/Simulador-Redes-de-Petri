using System;
using redePetri.rededepetri;
using SimuladorRedesPetri.rededepetri.simulador;

namespace SimuladorRedesPetri.rededepetri
{
    class Tela
    {
        public static void imprimirSimulacao(SimuladorRedePetri simulador)
        {
            Console.WriteLine();
            Console.WriteLine("- Simulacao da Rede de Petri -");

            imprimirCabecalho(simulador);
            imprimirCiclo(simulador);
        }

        public static void imprimirCabecalho(SimuladorRedePetri simulador)
        {
            Console.WriteLine();
            Console.Write("Ciclo | ");
            foreach (Lugar lugar in simulador.lugares)
            {
                Console.Write(lugar.nome + " | "); 
            }
            foreach (Transicao transicao in simulador.transicoes)
            {
                Console.Write(transicao.nome + " | ");
            }
        }

        public static void imprimirCiclo(SimuladorRedePetri simulador)
        {
            Console.WriteLine();
            Console.Write(simulador.numCiclo.ToString("D5") + " | ");

            foreach (Lugar lugar in simulador.lugares)
            {
                Console.Write(lugar.qtdMarcas.ToString("D2") + " | ");
            }

            foreach (Transicao transicao in simulador.transicoes)
            {
                if (transicao.status)
                {
                    Console.Write("S " + " | ");
                }
                else
                {
                    Console.Write("N " + " | ");
                }
            }
        }

    }
}
