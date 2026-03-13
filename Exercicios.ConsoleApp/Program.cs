namespace Exercicios.ConsoleApp;

class Program
{
    const int ItemsPerPage = 5;
    const string HeaderTitle = "Lógica de Programação";
    const string FooterHint = "↕ selecionar ↔ página ↵ confirmar ␛ sair";

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        (string Nome, Action Metodo)[] exercicios =
        [
            ("1. Volume de uma caixa retangular", Exercicios.Exercicio01),
            ("2. Volume de um cilindro", Exercicios.Exercicio02),
            ("3. Consumo de combustível (km/L)", Exercicios.Exercicio03),
            ("4. Converter temperatura (C°→F°)", Exercicios.Exercicio04),
            ("5. Salário com comissão de vendas", Exercicios.Exercicio05),
            ("6. Calcular média harmônica", Exercicios.Exercicio06),
            ("7. Calcular média ponderada", Exercicios.Exercicio07),
            ("8. Verificador de número primo", Exercicios.Exercicio08),
            ("9. Área de terreno retangular", Exercicios.Exercicio09),
            ("10. Padaria Hotpão 💀", Exercicios.Exercicio10),
            ("11. Calcular dias de vida", Exercicios.Exercicio11),
            ("12. Salário com aumento e impostos", Exercicios.Exercicio12),
            ("13. A + B é menor que C?", Exercicios.Exercicio13),
            ("14. Ordenação decrescente de 3 números", Exercicios.Exercicio14),
            ("15. Calcular IMC", Exercicios.Exercicio15),
            ("16. Par ou ímpar?", Exercicios.Exercicio16),
            ("17. C = A == B ? A + B : A * B;", Exercicios.Exercicio17),
            ("18. Ímpares entre 100 e 200", Exercicios.Exercicio18),
            ("19. Soma de ímpares múltiplos de 3 (1-500)", Exercicios.Exercicio19),
            ("20. Calcular tabuada ", Exercicios.Exercicio20),
            ("21. Calcular fatorial", Exercicios.Exercicio21),
            ("22. Sequência de Fibonacci até um número", Exercicios.Exercicio22),
            ("23. FizzBuzz de 1 a 100", Exercicios.Exercicio23)
        ];

        string[] opcoes = [.. exercicios.Select(x => x.Nome)];
        int selected = 0;

        while (true)
        {
            int result = Select(opcoes, selected);

            if (result < 0)
                break;

            selected = result;

            Console.ResetColor();
            Console.Clear();
            Console.CursorVisible = true;

            exercicios[selected].Metodo();

            Console.CursorVisible = false;
        }

        Console.Clear();
    }

    static string Center(string text, int width)
    {
        if (text.Length >= width) return text[..width];
        return text.PadLeft((width + text.Length) / 2).PadRight(width);
    }

    static string FitToWidth(string text, int width)
    {
        if (text.Length <= width) return text.PadRight(width);
        return text[..(width - 1)] + "…";
    }

    static int Select(string[] options, int initialSelectedIndex)
    {
        int selectedIndex = initialSelectedIndex;
        int currentPage = selectedIndex / ItemsPerPage;
        int totalPages = (int)Math.Ceiling(options.Length / (double)ItemsPerPage);

        int contentWidth = Math.Max(HeaderTitle.Length, Math.Max(FooterHint.Length, options.Max(x => x.Length + 2)));
        int boxWidth = contentWidth + 2;

        DrawFrame(boxWidth);
        DrawPageOptions(options, selectedIndex, currentPage, totalPages, boxWidth);

        while (true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    {
                        int pageStart = currentPage * ItemsPerPage;

                        if (selectedIndex > pageStart)
                        {
                            int oldIndex = selectedIndex;
                            selectedIndex--;

                            UpdateSelection(options, oldIndex, selectedIndex, currentPage, boxWidth);
                        }

                        break;
                    }

                case ConsoleKey.DownArrow:
                    {
                        int pageStart = currentPage * ItemsPerPage;
                        int pageEnd = Math.Min(pageStart + ItemsPerPage - 1, options.Length - 1);

                        if (selectedIndex < pageEnd)
                        {
                            int oldIndex = selectedIndex;
                            selectedIndex++;

                            UpdateSelection(options, oldIndex, selectedIndex, currentPage, boxWidth);
                        }

                        break;
                    }

                case ConsoleKey.LeftArrow:
                    {
                        if (currentPage > 0)
                        {
                            currentPage--;
                            selectedIndex = currentPage * ItemsPerPage;
                            DrawPageOptions(options, selectedIndex, currentPage, totalPages, boxWidth);
                        }
                        break;
                    }

                case ConsoleKey.RightArrow:
                    {
                        if (currentPage < totalPages - 1)
                        {
                            currentPage++;
                            selectedIndex = currentPage * ItemsPerPage;
                            DrawPageOptions(options, selectedIndex, currentPage, totalPages, boxWidth);
                        }
                        break;
                    }

                case ConsoleKey.Enter:
                    return selectedIndex;

                case ConsoleKey.Escape:
                    return -1;
            }
        }
    }

    static void DrawFrame(int boxWidth)
    {
        Console.Clear();

        Console.WriteLine("┌" + new string('─', boxWidth) + "┐");
        Console.WriteLine("│" + Center(HeaderTitle, boxWidth) + "│");
        Console.WriteLine("├" + new string('─', boxWidth) + "┤");

        for (int i = 0; i < ItemsPerPage; i++)
            Console.WriteLine("│" + new string(' ', boxWidth) + "│");

        Console.WriteLine("├" + new string('─', boxWidth) + "┤");
        Console.WriteLine("│" + new string(' ', boxWidth) + "│");
        Console.WriteLine("└" + new string('─', boxWidth) + "┘");
        Console.WriteLine("  " + FooterHint);
    }

    static void DrawPageOptions(string[] options, int selectedIndex, int currentPage, int totalPages, int boxWidth)
    {
        int start = currentPage * ItemsPerPage;

        for (int row = 0; row < ItemsPerPage; row++)
        {
            int optionIndex = start + row;
            bool isSelected = optionIndex == selectedIndex;

            DrawOptionRow(options, optionIndex, row, isSelected, boxWidth);
        }
        Console.ResetColor();
        string pageText = $"Página {currentPage + 1}/{totalPages}";
        WriteInsideRow(ItemsPerPage + 4, Center(pageText, boxWidth));
    }

    static void UpdateSelection(string[] options, int oldIndex, int newIndex, int currentPage, int boxWidth)
    {
        int pageStart = currentPage * ItemsPerPage;

        DrawOptionRow(options, oldIndex, oldIndex - pageStart, false, boxWidth);
        DrawOptionRow(options, newIndex, newIndex - pageStart, true, boxWidth);
    }

    static void DrawOptionRow(string[] options, int optionIndex, int rowInPage, bool isSelected, int boxWidth)
    {
        string text = "";

        if (optionIndex < options.Length)
            text = isSelected ? $" → {options[optionIndex]}" : $"   {options[optionIndex]}";

        if (isSelected)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        else
        {
            Console.ResetColor();
        }

        WriteInsideRow(3 + rowInPage, FitToWidth(text, boxWidth));
    }

    static void WriteInsideRow(int row, string content)
    {
        Console.SetCursorPosition(1, row);
        Console.Write(content);
    }
}