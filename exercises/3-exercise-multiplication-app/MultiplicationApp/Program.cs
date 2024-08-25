int baseNumber = 5;
string outputMessage = "";
string headerMessage = $@"
===========================================
        Tabla del {baseNumber}
===========================================

";

for (int i = 1; i <= 10; i++)
{
    outputMessage += $"{baseNumber} x {i} = {baseNumber * i}\n";
}

outputMessage = headerMessage + outputMessage;
Console.WriteLine(outputMessage);

string outputPath = "outputs";
Directory.CreateDirectory(outputPath);

string filePath = Path.Combine(outputPath, $"tabla-{baseNumber}.txt");
File.WriteAllText(filePath, outputMessage);

Console.WriteLine("¡Archivo creado!");
