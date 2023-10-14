using System;
using System.IO;
using System.Text.Json;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string bookJsonPath = "books.json";  // Cambiar la ruta al archivo JSON de libros.
        string authorJsonPath = "authors.json";  // Cambiar la ruta al archivo JSON de autores.

        try
        {
            string bookJson = File.ReadAllText(bookJsonPath);
            string authorJson = File.ReadAllText(authorJsonPath);
            var options = new JsonSerializerOptions
            {
                Converters = { new CustomDateTimeConverter() }
            };

            var books = JsonSerializer.Deserialize<Book[]>(bookJson, options);
            var authors = JsonSerializer.Deserialize<Author[]>(authorJson, options);

            // Ejemplo 1: Seleccionar libros con más de 150 páginas.
            TitleExample("Ejemplo 1: Seleccionar libros con más de 150 páginas");
            SelectLongBooks(books);
            newLine();

            // Ejemplo 2: Seleccionar libros de un autor específico (por ejemplo, "F. Scott Fitzgerald").
            TitleExample("Ejemplo 2: Seleccionar libros de un autor específico (por ejemplo, 'F.Scott Fitzgerald')");
            string authorNameToFind = "F. Scott Fitzgerald";  // Cambiar al nombre del autor que buscas.
            SelectBooksByAuthor(books, authors, authorNameToFind);
            newLine();

            // Ejemplo 3: Contar los libros y agruparlos por autor.
            TitleExample("Ejemplo 3: Contar los libros y agruparlos por autor");
            CountBooksByAuthor(books, authors);
            newLine();

            // Ejemplo 4: Buscar un libro en específico por título.
            TitleExample("Ejemplo 4: Buscar un libro en específico por título");
            string bookTitleToFind = "1984";  // Cambiar al título del libro que buscas.
            FindBookByTitle(books, authors, bookTitleToFind);
            newLine();

            // Ejemplo 5: Encontrar los 5 libros con más páginas.
            TitleExample("Ejemplo 5: Encontrar los 5 libros con más páginas");
            FindTop5BooksByPageCount(books);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("El archivo JSON no se encontró en la ubicación especificada.");
        }
        catch (JsonException)
        {
            Console.WriteLine("Ocurrió un error al deserializar el archivo JSON.");
        }
    }

    private static void newLine()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("===============================================================");
        Console.ResetColor();
    }

    private static void TitleExample(string title) {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{title}:");
        Console.ResetColor();
    }

    // Ejemplo 1: Seleccionar libros con más de 150 páginas.
    private static void SelectLongBooks(Book[] books)
    {
        var longBooks = books.Where(b => b.PageCount > 150);

        Console.WriteLine("Libros con más de 150 páginas:");
        foreach (var book in longBooks)
        {
            Console.WriteLine($"Título: {book.Title}, Páginas: {book.PageCount}");
        }
    }

    // Ejemplo 2: Seleccionar libros de un autor específico y mostrar información del autor.
    private static void SelectBooksByAuthor(Book[] books, Author[] authors, string authorNameToFind)
    {
        // Buscar al autor por nombre.
        var author = authors.FirstOrDefault(a => a.Name == authorNameToFind);

        if (author != null)
        {
            Console.WriteLine($"Información del autor {author.Name}:");
            Console.WriteLine($"Fecha de Nacimiento: {author.BirthDate:yyyy-MM-dd}");
            Console.WriteLine($"Nacionalidad: {author.Nationality}");
            Console.WriteLine();

            // Listar los libros escritos por el autor.
            var authorBooks = books.Where(b => b.AuthorId == author.Id);

            Console.WriteLine($"Libros escritos por {author.Name}:");
            foreach (var book in authorBooks)
            {
                Console.WriteLine($"Título: {book.Title}, Páginas: {book.PageCount}, Fecha de Lanzamiento: {book.ReleaseDate:yyyy-MM-dd}");
            }
        }
        else
        {
            Console.WriteLine($"No se encontró información para el autor: {authorNameToFind}");
        }
    }

    // Ejemplo 3: Contar los libros y agruparlos por autor.
    private static void CountBooksByAuthor(Book[] books, Author[] authors)
    {
        var booksByAuthor = books.GroupBy(b => b.AuthorId)
            .Select(g => new
            {
                Author = authors.FirstOrDefault(a => a.Id == g.Key),
                BookCount = g.Count()
            });

        Console.WriteLine("Libros por autor:");
        foreach (var item in booksByAuthor)
        {
            Console.WriteLine($"Autor: {item.Author.Name}, Libros: {item.BookCount}");
        }
    }

    // Ejemplo 4: Buscar un libro en específico por título.
    private static void FindBookByTitle(Book[] books, Author[] authors, string bookTitleToFind)
    {
        var bookInfo = books
            .Where(b => b.Title == bookTitleToFind)
            .Join(authors, book => book.AuthorId, author => author.Id, (book, author) => new
            {
                Book = book,
                Author = author
            })
            .FirstOrDefault();

        if (bookInfo != null)
        {
            Console.WriteLine($"Información del libro \"{bookTitleToFind}\":");
            Console.WriteLine($"Título: {bookInfo.Book.Title}");
            Console.WriteLine($"Páginas: {bookInfo.Book.PageCount}");
            Console.WriteLine($"Fecha de Lanzamiento: {bookInfo.Book.ReleaseDate:yyyy-MM-dd}");
            Console.WriteLine($"Autor: {bookInfo.Author.Name}");
        }
        else
        {
            Console.WriteLine($"No se encontró el libro con el título: \"{bookTitleToFind}\"");
        }
    }

    // Ejemplo 5: Encontrar los 5 libros con más páginas.
    private static void FindTop5BooksByPageCount(Book[] books)
    {
        var top5Books = books
            .OrderByDescending(b => b.PageCount)
            .Take(5);

        Console.WriteLine("Los 5 libros con más páginas:");
        foreach (var book in top5Books)
        {
            Console.WriteLine($"Título: {book.Title}, Páginas: {book.PageCount}");
        }
    }
}
