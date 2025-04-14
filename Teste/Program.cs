using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int i = 13;
        int soma = 0;
        int k = 0;

        while (k < i)
        {
            k = k + 1;
            soma = soma + k;
        }
        Console.WriteLine("Questao 1\n");
        Console.WriteLine("Soma: " + soma);

        Console.WriteLine("\n*************************************************");
        Console.WriteLine("\nQuestao 2\n");

        Console.Write("Informe um número: ");
        if (int.TryParse(Console.ReadLine(), out int n))
        {
            int a = 0;
            int b = 1;
            bool pertence = false;

            Console.Write("Sequência de Fibonacci até o número informado: " + a);

            while (b <= n)
            {
                Console.Write(", " + b);
                if (b == n)
                {
                    pertence = true;
                }

                int temp = b;
                b = a + b;
                a = temp;
            }

            Console.WriteLine();

            if (n == 0)
                pertence = true;

            if (pertence)
                Console.WriteLine($"O número {n} pertence à sequência de Fibonacci.");
            else
                Console.WriteLine($"O número {n} NÃO pertence à sequência de Fibonacci.");
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
        }
        Console.WriteLine("\n*************************************************");
        Console.WriteLine("\nQuestao 3\n");

        string json = @"[
            { 'dia': 1, 'valor': 22174.1664 },
            { 'dia': 2, 'valor': 24537.6698 },
            { 'dia': 3, 'valor': 26139.6134 },
            { 'dia': 4, 'valor': 0.0 },
            { 'dia': 5, 'valor': 0.0 },
            { 'dia': 6, 'valor': 26742.6612 },
            { 'dia': 7, 'valor': 0.0 },
            { 'dia': 8, 'valor': 42889.2258 },
            { 'dia': 9, 'valor': 46251.174 },
            { 'dia': 10, 'valor': 11191.4722 },
            { 'dia': 11, 'valor': 0.0 },
            { 'dia': 12, 'valor': 0.0 },
            { 'dia': 13, 'valor': 3847.4823 },
            { 'dia': 14, 'valor': 373.7838 },
            { 'dia': 15, 'valor': 2659.7563 },
            { 'dia': 16, 'valor': 48924.2448 },
            { 'dia': 17, 'valor': 18419.2614 },
            { 'dia': 18, 'valor': 0.0 },
            { 'dia': 19, 'valor': 0.0 },
            { 'dia': 20, 'valor': 35240.1826 },
            { 'dia': 21, 'valor': 43829.1667 },
            { 'dia': 22, 'valor': 18235.6852 },
            { 'dia': 23, 'valor': 4355.0662 },
            { 'dia': 24, 'valor': 13327.1025 },
            { 'dia': 25, 'valor': 0.0 },
            { 'dia': 26, 'valor': 0.0 },
            { 'dia': 27, 'valor': 25681.8318 },
            { 'dia': 28, 'valor': 1718.1221 },
            { 'dia': 29, 'valor': 13220.495 },
            { 'dia': 30, 'valor': 8414.61 }
        ]";

        var faturamentoDias = JsonConvert.DeserializeObject<List<FaturamentoDia>>(json);

        var faturamentoValor = faturamentoDias.Where(f => f.valor > 0).ToList();

        double menor = faturamentoValor.Min(f => f.valor);
        double maior = faturamentoValor.Max(f => f.valor);
        double media = faturamentoValor.Average(f => f.valor);

        var diaMenorFaturamento = faturamentoValor.First(f => f.valor == menor).dia;

        var diaMaiorFaturamento = faturamentoValor.First(f => f.valor == maior).dia;

        var diasAcimaDaMedia = faturamentoValor.Where(f => f.valor > media).ToList();

        Console.WriteLine($"Menor faturamento: R$ {menor:F2} no dia {diaMenorFaturamento}");
        Console.WriteLine($"Maior faturamento: R$ {maior:F2} no dia {diaMaiorFaturamento}");

        int numeroDeDiasAcimaDaMedia = diasAcimaDaMedia.Count();
        Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaDaMedia.Count}");

        string diasComFaturamentoAcimaDaMedia = string.Join(", ", diasAcimaDaMedia.Select(d => $"Dia {d.dia}: R$ {d.valor:F2}"));
        Console.WriteLine($"Dias com faturamento acima da média: \n{diasComFaturamentoAcimaDaMedia}");

        Console.WriteLine("\n*************************************************");
        Console.WriteLine("\nQuestao 4\n");

        List<EstadoFaturamento> estados = new List<EstadoFaturamento>()
        {
            new EstadoFaturamento { Estado = "SP", Valor = 67836.43 },
            new EstadoFaturamento { Estado = "RJ", Valor = 36678.66 },
            new EstadoFaturamento { Estado = "MG", Valor = 29229.88 },
            new EstadoFaturamento { Estado = "ES", Valor = 27165.48 },
            new EstadoFaturamento { Estado = "Outros", Valor = 19849.53 }
        };

        double total = 0;
        foreach (var e in estados)
            total += e.Valor;

        Console.WriteLine("Percentual por estado:");
        foreach (var e in estados)
        {
            double percentual = (e.Valor / total) * 100;
            Console.WriteLine($"{e.Estado}: {percentual:F2}%");
        }

        Console.WriteLine($"\nFaturamento total: R$ {total:F2}");

        Console.WriteLine("\n*************************************************");
        Console.WriteLine("\nQuestao 5\n");

        Console.WriteLine("Digite uma palavra: ");
        string original = Console.ReadLine();

        string invertida = "";

        for(int p = original.Length - 1; p >= 0; p--)
        {
            invertida += original[p];
        }
        Console.WriteLine("String original: " + original);
        Console.WriteLine("String invertida: " + invertida);

    }
    public class FaturamentoDia
    {
        public int dia { get; set; }
        public double valor { get; set; }
    }
    class EstadoFaturamento
    {
        public string Estado { get; set; }
        public double Valor { get; set; }
    }
}
