using System;
using System.Text.RegularExpressions;

string email = "usuario@dominio.com";
bool isValid = Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

Console.WriteLine(isValid ? "Correo válido" : "Correo inválido");

Console.WriteLine("\nPresiona cualquier tecla para salir...");
Console.ReadKey();

