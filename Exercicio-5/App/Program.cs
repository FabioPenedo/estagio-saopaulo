using System;

namespace InverterString
{
    class Program
    {
        static void Main(string[] args)
        {
            // String definida previamente no código
            string original = "Exemplo de string a ser invertida";

            // Inversão da string usando um loop
            string invertida = InverterString(original);

            // Exibe a string original e a invertida
            Console.WriteLine("Original: " + original);
            Console.WriteLine("Invertida: " + invertida);
        }

        static string InverterString(string input)
        {
            // Array de caracteres para armazenar a string invertida
            char[] caracteres = new char[input.Length];

            // Loop para inverter os caracteres
            for (int i = 0; i < input.Length; i++)
            {
                caracteres[i] = input[input.Length - 1 - i];
            }

            // Retorna a string invertida a partir do array de caracteres
            return new string(caracteres);
        }
    }
}
