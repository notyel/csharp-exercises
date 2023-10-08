# Ejercicio de Palíndromo en C#

Este ejercicio tiene como objetivo verificar si una palabra o frase es un palíndromo en C#, es decir, si se lee igual de izquierda a derecha y de derecha a izquierda, sin tener en cuenta espacios ni mayúsculas/minúsculas.

## Descripción

El código C# proporcionado contiene una función `IsPalindrome(string word)` que toma una cadena de texto como entrada y devuelve `true` si es un palíndromo y `false` si no lo es. Además, se utiliza la función `ReverseString(string input)` para invertir una cadena y realizar la verificación.

### Ejemplo de uso

```csharp
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
```

## Cómo Ejecutar el Programa en C#

Para ejecutar el programa en C# y verificar si una palabra o frase es un palíndromo, sigue estos pasos:

1. Abre una terminal o línea de comandos.

2. Navega hasta el directorio donde se encuentra el archivo "Program.cs" del proyecto.

3. Ejecuta el siguiente comando para compilar y ejecutar el programa:

   ```bash
   dotnet run
   ```

4. El programa te mostrará ejemplos de palabras y si son palíndromos o no en la consola.

¡Eso es todo! Ahora puedes utilizar el comando `dotnet run` para verificar palíndromos utilizando el programa en C#.
