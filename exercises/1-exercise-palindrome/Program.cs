using System;

class Program
{
    static bool IsPalindrome(string word)
    {
        word = word.ToLower().Replace(" ", "");
        string reversedWord = ReverseString(word);
        return word == reversedWord;
    }

    static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static void Main()
    {
        // Ejemplos de palabras y si son palíndromos o no
        Console.WriteLine("Abba: " + IsPalindrome("Abba"));  // Palíndromo
        Console.WriteLine("Reconocer: " + IsPalindrome("Reconocer"));  // Palíndromo
        Console.WriteLine("Amo la paloma: " + IsPalindrome("Amo la paloma"));  // No es un palíndromo
        Console.WriteLine("Hola Mundo: " + IsPalindrome("Hola Mundo"));  // No es un palíndromo
    }
}

