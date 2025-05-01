string text = "Anita lava la tina";
string clean = new string(text.Where(char.IsLetter).ToArray()).ToLower();
bool isPalindrome = clean == new string(clean.Reverse().ToArray());

Console.WriteLine(isPalindrome ? "Es un palíndromo" : "No es un palíndromo");


Console.WriteLine("\nPresiona cualquier tecla para salir...");
Console.ReadKey();