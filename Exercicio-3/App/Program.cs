using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json; // Importar System.Text.Json

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            // JSON de exemplo para faturamento diário
            string json = @"
                [
                    { 'Dia': 1, 'Valor': 22174.1664 },
                    { 'Dia': 2, 'Valor': 24537.6698 },
                    { 'Dia': 3, 'Valor': 26139.6134 },
                    { 'Dia': 4, 'Valor': 0.0 },
                    { 'Dia': 5, 'Valor': 0.0 },
                    { 'Dia': 6, 'Valor': 26742.6612 },
                    { 'Dia': 7, 'Valor': 0.0 },
                    { 'Dia': 8, 'Valor': 42889.2258 }
                ]";

            // Desserializar o JSON para uma lista de FaturamentoDiario usando System.Text.Json
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<FaturamentoDiario> faturamentos = JsonSerializer.Deserialize<List<FaturamentoDiario>>(json.Replace("'", "\""), options)!;

            // Instanciar a CalculadoraFaturamento
            var calculadora = new CalculadoraFaturamento(faturamentos);

            // Calcular e exibir os resultados
            Console.WriteLine("Menor faturamento do mês: " + calculadora.ObterMenorFaturamento());
            Console.WriteLine("Maior faturamento do mês: " + calculadora.ObterMaiorFaturamento());
            Console.WriteLine("Número de dias com faturamento superior à média mensal: " + calculadora.ObterDiasFaturamentoSuperiorMedia());
        }
    }

    public class FaturamentoDiario
    {
        public int Dia { get; set; }
        public decimal Valor { get; set; }
    }

    public class CalculadoraFaturamento
    {
        private readonly List<FaturamentoDiario> _faturamentos;

        public CalculadoraFaturamento(List<FaturamentoDiario> faturamentos)
        {
            _faturamentos = faturamentos;
        }

        public decimal ObterMenorFaturamento()
        {
            return _faturamentos.Where(f => f.Valor > 0).Min(f => f.Valor);
        }

        public decimal ObterMaiorFaturamento()
        {
            return _faturamentos.Max(f => f.Valor);
        }

        public int ObterDiasFaturamentoSuperiorMedia()
        {
            var faturamentosValidos = _faturamentos.Where(f => f.Valor > 0).ToList();
            decimal mediaMensal = faturamentosValidos.Average(f => f.Valor);
            return faturamentosValidos.Count(f => f.Valor > mediaMensal);
        }
    }
}
