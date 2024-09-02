using System;
using System.Collections.Generic;

namespace Distribuidora
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dicionário para armazenar os valores de faturamento por estado
            Dictionary<string, decimal> faturamentoPorEstado = new Dictionary<string, decimal>
            {
                { "SP", 67836.43m },
                { "RJ", 36678.66m },
                { "MG", 29229.88m },
                { "ES", 27165.48m },
                { "Outros", 19849.53m }
            };

            // Calcula o faturamento total
            decimal faturamentoTotal = 0;
            foreach (var valor in faturamentoPorEstado.Values)
            {
                faturamentoTotal += valor;
            }

            // Exibe o percentual de representação de cada estado
            Console.WriteLine("Percentual de representação por estado:");
            foreach (var estado in faturamentoPorEstado)
            {
                decimal percentual = (estado.Value / faturamentoTotal) * 100;
                Console.WriteLine($"{estado.Key}: {percentual:F2}%");
            }
        }
    }
}
