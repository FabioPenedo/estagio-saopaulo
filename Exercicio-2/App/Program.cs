// Inicializa a sequência de Fibonacci
List<int> fibonacci = new() { 0, 1 };

// Chama a função recursiva para começar o processo
SolicitarNumero(fibonacci);


static void SolicitarNumero(List<int> fibonacci)
{
    Console.Write("Sequência de fibonacci: ");
    foreach (var item in fibonacci)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine();

    Console.Write("Digite o próximo número: ");
    int n = int.Parse(Console.ReadLine()!);

    // Pega o ultimo e penultimo numero e verifica se é igual ao numero digitado
    int n1 = fibonacci[fibonacci.Count - 1];
    int n2 = fibonacci[fibonacci.Count - 2];

    if (n == n1 + n2)
    {
        fibonacci.Add(n);
        // Chama a função recursiva novamente para continuar solicitando números
        SolicitarNumero(fibonacci);
    }
    else
    {
        Console.WriteLine("O número digitado não pertence à sequência.");
    }
}