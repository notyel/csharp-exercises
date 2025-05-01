using System;

string frase = "C# es un lenguaje genial para aprender.";
int cantidadPalabras = frase.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

Console.WriteLine($"Cantidad de palabras: {cantidadPalabras}");

Console.WriteLine("\nPresiona cualquier tecla para salir...");
Console.ReadKey();
