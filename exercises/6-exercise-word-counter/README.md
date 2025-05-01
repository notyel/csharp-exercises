# Ejercicio 6: Word Counter

Este programa en C# cuenta cuántas palabras hay en una frase simple usando `Split`.

## Lógica

Separamos las palabras por espacios usando:

```csharp
frase.Split(' ', StringSplitOptions.RemoveEmptyEntries)
````

Esto evita contar espacios vacíos accidentales.

## Ejemplo de salida

Para la frase:

```
C# es un lenguaje genial para aprender.
```

La salida será:

```
Cantidad de palabras: 7
```

## Cómo ejecutar

Ejecuta con `dotnet run` o desde Visual Studio. El programa incluye una pausa con `Console.ReadKey()` para evitar que la consola se cierre automáticamente.



