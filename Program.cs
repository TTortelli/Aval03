internal class Program
{
    //Eduardo Tortelli
    private static void Main(string[] args)
    {
        string textoCifrado = "Lu0s z q0tm0uƒ€q~x ƒ40t ‚uy~t (~ 0†w|q~„mPe}q(†ytq(q‚q‚i0…}0uy~…„w0y‚‚m|u†qv„uPeu0q„qy…u0tm † (u}0†é‚yqƒ(s ‚u{0u0„i}q~xwƒPTqvt 0ri|qƒ0m0sywi‚‚ ƒ(u0sqz ~qƒ(q0uƒ|‚q~xwƒPSqz‚ ƒ0wƒƒ 0lyŠu~l 0ƒyuP_0ƒq~q|0o‚y„qvt 0~ë PTu~u0ƒuz0yƒƒw0 …u(sxq}i}0tu(‚uƒƒ}‚uy÷ë PPSi€y„qt0Y~ykyq|PZuƒƒ…z‚uy÷ë";

        int[] chave = Enumerable.Range(1, textoCifrado.Length).Select(i => i % 5 == 0 ? 8 : 16).ToArray();

        string textoDecifrado = DecifrarTexto(textoCifrado, chave);

        textoDecifrado = textoDecifrado.Replace('@', '\n');

        List<string> palindromos = EncontrarPalindromos(textoDecifrado);

        SubstituirPalindromos(textoDecifrado, palindromos);

        Console.WriteLine("Conteúdo do texto cifrado:");
        Console.WriteLine(textoCifrado);
        Console.WriteLine("\nPalíndromos encontrados:");
        foreach (var palindromo in palindromos)
        {
            Console.WriteLine(palindromo);
        }
        Console.WriteLine($"\nNúmero de caracteres do texto decifrado: {textoDecifrado.Length}");
        Console.WriteLine($"Quantidade de palavras no texto decifrado: {ContarPalavras(textoDecifrado)}");
        Console.WriteLine("\nTexto decifrado em maiúsculo:");
        Console.WriteLine(textoDecifrado.ToUpper());
    }

    static string DecifrarTexto(string textoCifrado, int[] chave)
    {
        string textoDecifrado = "";

        for (int i = 0; i < textoCifrado.Length; i++)
        {
            char caractere = textoCifrado[i];
            int valorChave = chave[i % chave.Length];

            // Aplicar o algoritmo "De Teus Pulos"
            char caractereDecifrado = (char)(caractere - valorChave);

            textoDecifrado += caractereDecifrado;
        }

        return textoDecifrado;
    }

    static List<string> EncontrarPalindromos(string texto)
    {
        List<string> palindromos = new List<string>();
        string[] palavras = texto.Split(' ', '\n', '\r', '\t');

        foreach (var palavra in palavras)
        {
            if (EhPalindromo(palavra))
            {
                palindromos.Add(palavra);
            }
        }

        return palindromos;
    }

    static bool EhPalindromo(string palavra)
    {
        return palavra.SequenceEqual(palavra.Reverse());
    }

    static void SubstituirPalindromos(string texto, List<string> palindromos)
    {
        for (int i = 0; i < palindromos.Count && i < 3; i++)
        {
            texto = texto.Replace(palindromos[i], i switch
            {
                0 => "gloriosa",
                1 => "bondade",
                2 => "passam",
                _ => throw new ArgumentOutOfRangeException()
            });
        }
    }

    static int ContarPalavras(string texto)
    {
        string[] palavras = texto.Split(' ', '\n', '\r', '\t');
        return palavras.Count(p => !string.IsNullOrWhiteSpace(p));
    }
}
    

