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
                SimuladorRedePetri simulador = new SimuladorRedePetri();
                simulador.RecebeLugares();
                simulador.RecebeTransicoes();
                simulador.RecebePesoArcos();
                
                Console.WriteLine("\n- Simulacao da Rede de Petri -");

                while (!simulador.terminada)
                {
                    simulador.TransacoesHabilitadas();

                    Tela.imprimirSimulacao(simulador);

                    Console.WriteLine();
                    Console.WriteLine("Para executar aperte 'Enter'");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        simulador.ExecutaCiclo();
                    }
                    else
                    {
                        Tela.ImprimeSimulacaoFinalizada();
                        break;
                    }
                }
            } catch (RedePetriException e)
            {
                Console.Write(e.Message);
            }

        }
    }
}
