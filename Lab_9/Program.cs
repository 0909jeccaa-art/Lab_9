using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab9_Variant14
{
    // 1. Опис класу Book (Книга)
    public class Book
    {
        public string Title { get; set; }       // Назва[cite: 9]
        public string Author { get; set; }      // Автор[cite: 9]
        public string Genre { get; set; }       // Жанр[cite: 9]
        public int PageCount { get; set; }      // Кількість сторінок[cite: 9]
        public int Year { get; set; }           // Рік видання[cite: 9]
        public decimal Price { get; set; }      // Ціна[cite: 9]

        public Book(string title, string author, string genre, int pageCount, int year, decimal price)
        {
            Title = title;
            Author = author;
            Genre = genre;
            PageCount = pageCount;
            Year = year;
            Price = price;
        }

        public override string ToString()
        {
            return $"\"{Title}\" | Автор: {Author} | Жанр: {Genre} | Стор: {PageCount} | Рік: {Year} | Ціна: {Price:C}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Створення списку книг та заповнення його даними[cite: 9]
            List<Book> books = new List<Book>
            {
                new Book("Дюна", "Френк Герберт", "Фантастика", 700, 1965, 450.50m),
                new Book("Фундація", "Айзек Азімов", "Фантастика", 320, 1951, 380.00m),
                new Book("Я, Робот", "Айзек Азімов", "Фантастика", 250, 1950, 310.00m),
                new Book("1984", "Джордж Орвелл", "Антиутопія", 328, 1949, 290.00m),
                new Book("Колгосп тварин", "Джордж Орвелл", "Сатира", 120, 1945, 200.00m),
                new Book("Гіперіон", "Ден Сіммонс", "Фантастика", 672, 1989, 520.00m),
                new Book("Шерлок Холмс", "Артур Конан Дойл", "Детектив", 480, 1892, 350.00m)
            };

            Console.WriteLine("=== ПЕРВИННИЙ СПИСОК КНИГ ===");
            foreach (var b in books)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine(new string('-', 60));

            // 2. Виконання LINQ-запитів[cite: 9]

            // а) Отримати всі книги жанру "Фантастика"[cite: 9]
            var sciFiBooks = books.Where(b => b.Genre.Equals("Фантастика", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("\n1. Книги жанру 'Фантастика':");
            foreach (var book in sciFiBooks)
            {
                Console.WriteLine($"   - {book.Title} ({book.Author})");
            }

            // б) Відсортувати книги за ціною у порядку зростання[cite: 9]
            var sortedByPrice = books.OrderBy(b => b.Price);

            Console.WriteLine("\n2. Книги, відсортовані за ціною (зростання):");
            foreach (var book in sortedByPrice)
            {
                Console.WriteLine($"   - {book.Price:C} -- {book.Title}");
            }

            // в) Знайти найдорожчу книгу[cite: 9]
            var mostExpensiveBook = books.OrderByDescending(b => b.Price).FirstOrDefault();

            Console.WriteLine("\n3. Найдорожча книга:");
            if (mostExpensiveBook != null)
            {
                Console.WriteLine($"   {mostExpensiveBook.Title} (Ціна: {mostExpensiveBook.Price:C})");
            }

            // г) Підрахувати середню кількість сторінок у всіх книгах[cite: 9]
            double averagePages = books.Average(b => b.PageCount);

            Console.WriteLine($"\n4. Середня кількість сторінок у всіх книгах: {averagePages:F1}");

            // д) Групувати книги за автором[cite: 9]
            var groupedByAuthor = books.GroupBy(b => b.Author);

            Console.WriteLine("\n5. Групування книг за автором:");
            foreach (var group in groupedByAuthor)
            {
                Console.WriteLine($"   Автор: {group.Key}");
                foreach (var book in group)
                {
                    Console.WriteLine($"      • \"{book.Title}\" ({book.Genre})");
                }
            }

            Console.ReadKey();
        }
    }
}