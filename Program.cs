using System;
using System.Collections;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Menu();

    }

    static void Menu(){
        Console.Clear();
        Console.WriteLine("==== Seja Bem-Vindo ao Binary Translator ====");
        Console.WriteLine("");
        Console.WriteLine("Escolha a opcao desejada:");
        Console.WriteLine("1- Converter");
        Console.WriteLine("2- Traduzir");
        Console.WriteLine("3- Sair");
        Console.WriteLine("");

        short res = short.Parse(Console.ReadLine());

        switch (res){
            case 1 : Converter(); break;
            case 2 : Traduzir(); break;
            case 3 : System.Environment.Exit(0); break;
        }
    }
    static void Converter(){
        Console.Clear();
        Console.WriteLine("Digite o texto que deseja que seja convertido:");

        string txt = Console.ReadLine();
        txt = txt.ToLower();

        string resultado = "";

        foreach (char caractere in txt)
        {
            int valorAscii = (int)caractere;
            string binario = Convert.ToString(valorAscii, 2);

            // Preenche com zeros à esquerda para ter 8 bits
            binario = binario.PadLeft(8, '0');

            resultado += binario;
        }

        Console.Clear();
        Console.WriteLine("==== Your Text ---> Binary ====");
        Console.WriteLine($"Your Text: {txt}");
        Console.WriteLine("");
        Console.WriteLine($"Binary: {resultado}");
        Console.WriteLine("");
        Console.WriteLine("==== Press Enter to return to Menu ====");
        Console.ReadKey();
        Menu();

    }
    static void Traduzir(){
        Console.Clear();
        Console.WriteLine("Digite o codigo que deseja traduzir:");
        string cod = Console.ReadLine();
        string textoSemEspacos = Regex.Replace(cod, @"\s+", "");

        string resultado = "";

        float contagem = 0;

        foreach (char caractere in textoSemEspacos)
        {
            contagem++;
        }

        if (contagem % 8 == 0){

            for (int i = 0; i < textoSemEspacos.Length; i += 8)
            {
                string byteBinario = textoSemEspacos.Substring(i, 8);
                int valorAscii = Convert.ToInt32(byteBinario, 2);
                char caractere = (char)valorAscii;
                resultado += caractere;
            }
            Console.Clear();
            Console.WriteLine("==== Binary ---> Your text Convert ====");
            Console.WriteLine($"Your code: {cod}");
            Console.WriteLine("");
            Console.WriteLine($"Text Convert: {resultado}");
            Console.WriteLine("");
            Console.WriteLine("==== Press Enter to return to Menu ====");
            Console.ReadKey();
            Menu();
        }else{
            Console.Clear();
            Console.WriteLine("Seu codigo infelizmente nao esta de acordo com a norma formativa de um codigo binario!!!");
            Console.WriteLine("");
            Console.WriteLine("Obs: Certifique-se que ele esteja com a definicao de 8bits por letra correta.");
            Console.WriteLine("");
            Console.WriteLine("==== Press Enter to return to Menu ====");
            Console.ReadKey();
            Menu();
        }
    }

}