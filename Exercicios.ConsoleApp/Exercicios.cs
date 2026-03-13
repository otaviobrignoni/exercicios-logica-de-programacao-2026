using System.Numerics;

namespace Exercicios.ConsoleApp;

public static class Exercicios
{
    // 1. Crie um programa para calcular o volume de uma caixa retangular
    public static void Exercicio01()
    {
        WriteTitle("Volume de uma caixa retangular");

        decimal length = GetDecimal("Comprimento: ");
        decimal width = GetDecimal("Largura: ");
        decimal height = GetDecimal("Altura: ");

        decimal volume = length * width * height;

        WriteTitle("Volume de uma caixa retangular");
        Console.WriteLine($"Volume = {volume:F2} m³");
        ReturnToMenu();
    }

    // 2. Crie um programa para calcular o volume de um Cilindro
    public static void Exercicio02()
    {
        WriteTitle("Volume de um cilindro");

        decimal radius = GetDecimal("Raio: ");
        decimal height = GetDecimal("Altura: ");

        decimal volume = (decimal)Math.PI * radius * radius * height;

        WriteTitle("Volume de um cilindro");
        Console.WriteLine($"Volume = {volume:F2} m³");
        ReturnToMenu();
    }

    // 3. Crie um programa que calcule o consumo de combustível por quilômetro percorrido em uma viagem.
    // O programa deve solicitar ao usuário:
    // ● A quilometragem inicial do veículo no início da viagem.
    // ● A quilometragem final ao término da viagem.
    // ● A quantidade de combustível consumida durante a viagem (em litros).
    public static void Exercicio03()
    {
        while (true)
        {
            WriteTitle("Consumo de combustível (km/L)");

            decimal initialMileage = GetDecimal("Quilometragem inicial: ");
            decimal finalMileage = GetDecimal("Quilometragem final: ");
            decimal consumedFuel = GetDecimal("Combustível consumido (L): ");

            if (finalMileage < initialMileage)
            {
                ShowValidationMessage("A quilometragem final não pode ser menor que a inicial.");
                continue;
            }

            if (consumedFuel <= 0)
            {
                ShowValidationMessage("O combustível consumido deve ser maior que zero.");
                continue;
            }

            decimal traveledDistance = finalMileage - initialMileage;
            decimal fuelConsumption = traveledDistance / consumedFuel;

            WriteTitle("Consumo de combustível (km/L)");
            Console.WriteLine($"Distância percorrida = {traveledDistance:F2} km");
            Console.WriteLine($"Consumo = {fuelConsumption:F2} km/L");
            ReturnToMenu();
            return;
        }
    }

    // 4. Crie um programa para converter a temperatura da escala Celsius para a escala Fahrenheit
    public static void Exercicio04()
    {
        WriteTitle("Converter temperatura (C°→F°)");

        decimal celsiusTemperature = GetDecimal("Temperatura em Celsius: ");
        decimal fahrenheitTemperature = (celsiusTemperature * 9m / 5m) + 32m;

        WriteTitle("Converter temperatura (C°→F°)");
        Console.WriteLine($"Temperatura em Fahrenheit = {fahrenheitTemperature:F2} °F");
        ReturnToMenu();
    }

    // 5. Crie um programa para calcular o salário total de um vendedor.
    // Deverá ser informado o salário base e o total de vendas.
    // A comissão é calculada com um percentual (informado pelo usuário) sobre o total de vendas.
    public static void Exercicio05()
    {
        while (true)
        {
            WriteTitle("Salário com comissão de vendas");

            decimal baseSalary = GetDecimal("Salário base: ");
            decimal totalSales = GetDecimal("Total de vendas: ");
            decimal commissionPercentage = GetDecimal("Percentual de comissão (%): ");

            if (baseSalary < 0 || totalSales < 0 || commissionPercentage < 0)
            {
                ShowValidationMessage("Os valores não podem ser negativos.");
                continue;
            }

            decimal commissionValue = totalSales * (commissionPercentage / 100m);
            decimal totalSalary = baseSalary + commissionValue;

            WriteTitle("Salário com comissão de vendas");
            Console.WriteLine($"Comissão = {commissionValue:C2}");
            Console.WriteLine($"Salário total = {totalSalary:C2}");
            ReturnToMenu();
            return;
        }
    }

    // 6. Crie um programa para calcular a média harmônica das notas de um Aluno
    public static void Exercicio06()
    {
        while (true)
        {
            WriteTitle("Calcular média harmônica");

            decimal firstGrade = GetDecimal("Primeira nota: ");
            decimal secondGrade = GetDecimal("Segunda nota: ");
            decimal thirdGrade = GetDecimal("Terceira nota: ");

            if (firstGrade == 0 || secondGrade == 0 || thirdGrade == 0)
            {
                ShowValidationMessage("Nenhuma nota pode ser zero na média harmônica.");
                continue;
            }

            decimal harmonicAverage = 3m / ((1m / firstGrade) + (1m / secondGrade) + (1m / thirdGrade));

            WriteTitle("Calcular média harmônica");
            Console.WriteLine($"Média harmônica = {harmonicAverage:F2}");
            ReturnToMenu();
            return;
        }
    }

    // 7. Crie um programa para calcular a média ponderada de duas provas realizadas por um aluno
    public static void Exercicio07()
    {
        while (true)
        {
            WriteTitle("Calcular média ponderada");

            decimal firstGrade = GetDecimal("Nota da prova 1: ");
            decimal firstWeight = GetDecimal("Peso da prova 1: ");
            decimal secondGrade = GetDecimal("Nota da prova 2: ");
            decimal secondWeight = GetDecimal("Peso da prova 2: ");

            if (firstWeight == 0 || secondWeight == 0)
            {
                ShowValidationMessage("Os pesos não podem ser zero.");
                continue;
            }

            decimal weightedAverage = ((firstGrade * firstWeight) + (secondGrade * secondWeight)) / (firstWeight + secondWeight);

            WriteTitle("Calcular média ponderada");
            Console.WriteLine($"Média ponderada = {weightedAverage:F2}");
            ReturnToMenu();
            return;
        }
    }

    // 8. Crie um programa para verificar se um número é primo.
    public static void Exercicio08()
    {
        WriteTitle("Verificador de número primo");

        int number = GetInteger("Digite um número inteiro: ");

        bool isPrime = number > 1;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        WriteTitle("Verificador de número primo");
        Console.WriteLine(isPrime ? $"{number} é primo." : $"{number} não é primo.");
        ReturnToMenu();
    }

    // 9. A imobiliária Imóbilis vende apenas terrenos retangulares.
    // Faça um algoritmo para ler as dimensões de um terreno e depois exibir a área do terreno.
    public static void Exercicio09()
    {
        WriteTitle("Área de terreno retangular");

        decimal width = GetDecimal("Largura do terreno: ");
        decimal length = GetDecimal("Comprimento do terreno: ");

        decimal area = width * length;

        WriteTitle("Área de terreno retangular");
        Console.WriteLine($"Área do terreno = {area:F2} m²");
        ReturnToMenu();
    }

    // 10. A padaria Hotpão vende uma certa quantidade de pães franceses e uma quantidade de broas a cada dia.
    // Cada pãozinho custa R$ 0,12 e a broa custa R$ 1,50.
    // Ao final do dia, o dono quer saber quanto arrecadou com a venda dos pães e broas (juntos),
    // e quanto deve guardar numa conta de poupança (10% do total arrecadado).
    // Você foi contratado para fazer os cálculos para o dono.
    // Com base nestes fatos, faça um algoritmo para ler as quantidades de pães e de broas,
    // e depois calcular os dados solicitados.
    public static void Exercicio10()
    {
        while (true)
        {
            WriteTitle("Padaria Hotpão 💀");

            int paesAmount = GetInteger("Quantidade de pães: ");
            int broasAmount = GetInteger("Quantidade de broas: ");

            if (paesAmount < 0 || broasAmount < 0)
            {
                ShowValidationMessage("As quantidades não podem ser negativas.");
                continue;
            }

            decimal paesTotal = paesAmount * 0.12m;
            decimal broasTotal = broasAmount * 1.50m;
            decimal totalRevenue = paesTotal + broasTotal;
            decimal savingsAmount = totalRevenue * 0.10m;

            WriteTitle("Padaria Hotpão 💀");
            Console.WriteLine($"Total arrecadado = {totalRevenue:C2}");
            Console.WriteLine($"Guardar na poupança = {savingsAmount:C2}");
            ReturnToMenu();
            return;
        }
    }

    // 11. Escreva um algoritmo para ler o nome e a idade de uma pessoa,
    // e exibir quantos dias de vida ela possui.
    // Considere sempre anos completos, e que um ano possui 365 dias.
    // Ex: uma pessoa com 19 anos possui 6935 dias de vida;
    // veja um exemplo de saída: MARIA, VOCÊ JÁ VIVEU 6935 DIAS.
    public static void Exercicio11()
    {
        while (true)
        {
            WriteTitle("Calcular dias de vida");

            string name = GetString("Nome: ");
            int age = GetInteger("Idade: ");

            if (string.IsNullOrWhiteSpace(name))
            {
                ShowValidationMessage("O nome não pode ficar vazio.");
                continue;
            }

            if (age < 0)
            {
                ShowValidationMessage("A idade não pode ser negativa.");
                continue;
            }

            int livedDays = age * 365;

            WriteTitle("Calcular dias de vida");
            Console.WriteLine($"{name.ToUpper()}, VOCÊ JÁ VIVEU {livedDays} DIAS.");
            ReturnToMenu();
            return;
        }
    }

    // 12. Faça um algoritmo para ler o salário de um funcionário e aumentá-lo em 15%.
    // Após o aumento, desconte 8% de impostos.
    // Imprima o salário inicial, o salário com o aumento e o salário final.
    public static void Exercicio12()
    {
        while (true)
        {
            WriteTitle("Salário com aumento e impostos");

            decimal initialSalary = GetDecimal("Salário inicial: ");

            if (initialSalary < 0)
            {
                ShowValidationMessage("O salário não pode ser negativo.");
                continue;
            }

            decimal increasedSalary = initialSalary * 1.15m;
            decimal finalSalary = increasedSalary * 0.92m;

            WriteTitle("Salário com aumento e impostos");
            Console.WriteLine($"Salário inicial = R$ {initialSalary:F2}");
            Console.WriteLine($"Salário com aumento = R$ {increasedSalary:F2}");
            Console.WriteLine($"Salário final = R$ {finalSalary:F2}");
            ReturnToMenu();
            return;
        }
    }

    // 13. Faça um algoritmo que leia os valores A, B, C
    // e imprima na tela se a soma de A + B é menor que C.
    public static void Exercicio13()
    {
        WriteTitle("A + B é menor que C?");

        decimal a = GetDecimal("A: ");
        decimal b = GetDecimal("B: ");
        decimal c = GetDecimal("C: ");

        decimal sum = a + b;
        bool isLower = sum < c;

        WriteTitle("A + B é menor que C?");
        Console.WriteLine($"A + B = {sum:F2}");
        Console.WriteLine(isLower ? "A soma de A + B é menor que C." : "A soma de A + B não é menor que C.");
        ReturnToMenu();
    }

    // 14. Escreva um algoritmo que leia três valores inteiros e diferentes
    // e mostre-os em ordem decrescente.
    public static void Exercicio14()
    {
        while (true)
        {
            WriteTitle("Ordenação decrescente de 3 números");

            int firstValue = GetInteger("Primeiro valor: ");
            int secondValue = GetInteger("Segundo valor: ");
            int thirdValue = GetInteger("Terceiro valor: ");

            if (firstValue == secondValue || firstValue == thirdValue || secondValue == thirdValue)
            {
                ShowValidationMessage("Os três valores devem ser diferentes.");
                continue;
            }

            int[] values = [firstValue, secondValue, thirdValue];
            Array.Sort(values);
            Array.Reverse(values);

            WriteTitle("Ordenação decrescente de 3 números");
            Console.WriteLine($"Ordem decrescente: {string.Join(", ", values)}");
            ReturnToMenu();
            return;
        }
    }

    // 15. O IMC – Índice de Massa Corporal é um critério da Organização Mundial de Saúde
    // para dar uma indicação sobre a condição de peso de uma pessoa adulta.
    // A fórmula é IMC = peso / (altura)².
    // Elabore um algoritmo que leia o peso e a altura de um adulto e mostre sua condição de acordo com a listagem abaixo:
    // ● Abaixo de 18,5 → Abaixo do peso
    // ● Entre 18,5 e 25 → Peso normal
    // ● Entre 25 e 30 → Acima do peso
    // ● Acima de 30 → Obeso
    public static void Exercicio15()
    {
        while (true)
        {
            WriteTitle("Calcular IMC");

            decimal weight = GetDecimal("Peso (kg): ");
            decimal height = GetDecimal("Altura (m): ");

            if (weight <= 0 || height <= 0)
            {
                ShowValidationMessage("Peso e altura devem ser maiores que zero.");
                continue;
            }

            decimal bmi = weight / (height * height);
            string classification;

            if (bmi < 18.5m)
                classification = "Abaixo do peso";
            else if (bmi < 25m)
                classification = "Peso normal";
            else if (bmi < 30m)
                classification = "Acima do peso";
            else
                classification = "Obeso";

            WriteTitle("Calcular IMC");
            Console.WriteLine($"IMC = {bmi:F2}");
            Console.WriteLine($"Condição = {classification}");
            ReturnToMenu();
            return;
        }
    }

    // 16. Faça um algoritmo para receber um número qualquer
    // e informar na tela se é par ou ímpar.
    public static void Exercicio16()
    {
        WriteTitle("Par ou ímpar?");

        int number = GetInteger("Digite um número inteiro: ");

        WriteTitle("Par ou ímpar?");
        Console.WriteLine(number % 2 == 0 ? $"{number} é par." : $"{number} é ímpar.");
        ReturnToMenu();
    }

    // 17. Faça um algoritmo que leia dois valores inteiros A e B,
    // se os valores forem iguais deverá se somar os dois,
    // caso contrário multiplique A por B.
    // Ao final de qualquer um dos cálculos deve-se atribuir o resultado para uma variável C
    // e mostrar seu conteúdo na tela.
    public static void Exercicio17()
    {
        WriteTitle("C = A == B ? A + B : A * B;");

        int a = GetInteger("A: ");
        int b = GetInteger("B: ");

        int c = a == b ? a + b : a * b;

        WriteTitle("C = A == B ? A + B : A * B;");
        Console.WriteLine($"C = {c}");
        ReturnToMenu();
    }

    // 18. Escrever um algoritmo que gera e escreve os números ímpares entre 100 e 200.
    public static void Exercicio18()
    {
        WriteTitle("Ímpares entre 100 e 200");
        int count = 0;
        for (int number = 101; number < 200; number += 2)
        {
            if (count == 5)
            {
                count = 0;
                Console.WriteLine();
            }
            Console.Write(number + " ");
            count++;

        }
        Console.WriteLine();
        ReturnToMenu();
    }

    // 19. Desenvolver um algoritmo que efetue a soma de todos os números ímpares
    // que são múltiplos de três e que se encontram no conjunto dos números de 1 até 500.
    public static void Exercicio19()
    {
        WriteTitle("Soma de ímpares múltiplos de 3 (1-500)");

        int sum = 0;

        for (int number = 1; number <= 500; number++)
        {
            if (number % 2 != 0 && number % 3 == 0)
                sum += number;
        }

        Console.WriteLine($"Resultado = {sum}");
        ReturnToMenu();
    }

    // 20. Escrever um algoritmo que leia um valor para uma variável N de 1 a 10
    // e calcule a tabuada de N.
    // Mostre a tabuada na forma:
    // ● 0 x N = 0
    // ● 1 x N = 1N
    // ● ...
    // ● 10 x N = 10N
    public static void Exercicio20()
    {
        while (true)
        {
            WriteTitle("Calcular tabuada");

            int number = GetInteger("Digite um número (1 a 10): ");

            if (number < 1 || number > 10)
            {
                ShowValidationMessage("O número deve estar entre 1 e 10.");
                continue;
            }

            WriteTitle("Calcular tabuada");

            for (int i = 0; i <= 10; i++)
                Console.WriteLine($"{i} × {number} = {i * number}");

            ReturnToMenu();
            return;
        }
    }

    // 21. Escreva um algoritmo que leia um valor inicial A
    // e imprima a sequência de valores do cálculo de A! e o seu resultado.
    // a. Ex: 5! = 5 X 4 X 3 X 2 X 1 = 120
    // b. Pesquise sobre “fatorial”
    public static void Exercicio21()
    {
        while (true)
        {
            WriteTitle("Calcular fatorial");

            int number = GetInteger("Digite um número inteiro não negativo: ");

            if (number < 0)
            {
                ShowValidationMessage("O número não pode ser negativo.");
                continue;
            }

            if (number == 0)
            {
                WriteTitle("Calcular fatorial");
                Console.WriteLine("0! = 1");
                ReturnToMenu();
                return;
            }

            BigInteger factorial = 1;

            WriteTitle("Calcular fatorial");
            Console.Write($"{number}! = ");

            for (int value = number; value >= 1; value--)
            {
                Console.Write(value);

                if (value > 1)
                    Console.Write(" × ");

                factorial *= value;
            }

            Console.WriteLine($" = {factorial}");
            ReturnToMenu();
            return;
        }
    }

    // 22. Escreva um programa que leia um número
    // e imprima a sequência de Fibonacci até esse número.
    public static void Exercicio22()
    {
        while (true)
        {
            WriteTitle("Sequência de Fibonacci até um número");

            int limit = GetInteger("Digite um número limite: ");

            if (limit < 0)
            {
                ShowValidationMessage("O número não pode ser negativo.");
                continue;
            }

            WriteTitle("Sequência de Fibonacci até um número");

            int current = 0;
            int next = 1;
            int count = 0;

            while (current <= limit)
            {
                Console.Write($"{current} ");
                count++;

                if (count == 10)
                {
                    count = 0;
                    Console.WriteLine();
                }
                int newNext = current + next;
                current = next;
                next = newNext;
            }
            Console.WriteLine();
            ReturnToMenu();
            return;
        }
    }

    // 23. Escreva um programa que imprima os números de 1 a 100 em ordem crescente,
    // substituindo os números múltiplos de 3 pela palavra "Fizz"
    // e os múltiplos de 5 pela palavra "Buzz".
    // Para números que são múltiplos de ambos, use "FizzBuzz".
    public static void Exercicio23()
    {
        WriteTitle("FizzBuzz de 1 a 100");

        const int maxLineLength = 37;
        int currentLineLength = 0;

        for (int number = 1; number <= 100; number++)
        {
            string output;

            if (number % 15 == 0) output = "FizzBuzz";
            else if (number % 3 == 0) output = "Fizz";
            else if (number % 5 == 0) output = "Buzz";
            else output = number.ToString();

            string text = number < 100 ? $"{output}, " : output;

            if (currentLineLength + text.Length > maxLineLength)
            {
                Console.WriteLine();
                currentLineLength = 0;
            }

            Console.Write(text);
            currentLineLength += text.Length;
        }
        Console.WriteLine();
        ReturnToMenu();
    }

    private static void WriteTitle(string title)
    {
        int width = title.Length + 2;

        Console.Clear();
        Console.WriteLine("┌" + new string('─', width) + "┐");
        Console.WriteLine("│ " + title + " │");
        Console.WriteLine("└" + new string('─', width) + "┘");
        Console.WriteLine();
    }

    private static int GetInteger(string text)
    {
        while (true)
        {
            Console.Write(text);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value))
                return value;

            Console.WriteLine("Valor inválido. Tente novamente.");
        }
    }

    private static decimal GetDecimal(string text)
    {
        while (true)
        {
            Console.Write(text);
            string? input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal value))
                return value;

            Console.WriteLine("Valor inválido. Tente novamente.");
        }
    }

    private static string GetString(string text)
    {
        Console.Write(text);
        return Console.ReadLine() ?? string.Empty;
    }

    private static void ShowValidationMessage(string message)
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
        Console.ReadKey(true);
        Console.Clear();
    }

    private static void ReturnToMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para voltar...");
        Console.ReadKey(true);
    }
}