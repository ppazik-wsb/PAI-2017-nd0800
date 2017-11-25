using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EF.ConsoleApp.DataContexts;
using EF.ConsoleApp.Models;

namespace EF.ConsoleApp
{
    class Program
    {
        static int Main(string[] args)
        {
            // Korzystamy z bloku using () {}, by upewnić się, że wraz z zakończeniem bloku zostanie usunięty 
            // stworzony na potrzeby tego bloku kontekst do bazy danych. Za każdym razem gdy będziemy chcieli
            // zawartość bazy danych lub dostać się do zasobów w niej zawartych powinniśmy tworzyć nowy kontekst
            // W tym miejscu należy zaznaczyć, że nie będzie to błąd ani problem wydajnościowy, z powodu ciągłego
            // rozłączania się z bazą i ponowniego łączenia, ponieważ połączenia do bazy danych w większości są
            // wrzucane do wspóldzielonej puli, każde takie połączenie może być "za chwilę" ponownie użyte.
            // 
            // Zobacz więcej:
            //     > using () {} - https://www.dotnetperls.com/using
            //     > connection pooling - https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-connection-pooling

            using (var dbCtx = new DefaultAppDbConnection())
            {
                bool closeApp = false;
                while (closeApp == false)
                {
                    switch (Menu())
                    {
                        case 1: // Wyświetlanie wszystkich wpisów
                            PrintAllDishes(dbCtx.Dishes.ToList());
                            break;
                        case 2: // Create - Dodawanie nowego wpisu
                            InsertNewManualDish(dbCtx.Dishes);
                            dbCtx.SaveChanges();
                            Console.WriteLine();
                            break;
                        case 3: // Pobieranie konkretnego wpisu
                            Console.WriteLine(PrintDish(FindDishByName(dbCtx.Dishes)));
                            break;
                        case 4: // Aktualizacja wpisu
                            break;
                        case 5: // Usuwanie wpisu

                            break;
                        case 0: return 0;
                    }

                    Console.Write("\n\nWcisnij dowolny klawisz by wrócić do głównego menu!");
                    Console.ReadKey();
                }

                return 0;
            }
        }

        /// <summary>
        /// Metoda do wypisania wszystkich potraw w kolekcji
        /// </summary>
        /// <param name="dishes">Kolekcja z potrawami</param>
        /// <param name="printSummary">Flaga czy wyświetlić podsumowanie kolekcji</param>
        static void PrintAllDishes(ICollection<Dish> dishes, bool printSummary = true)
        {
            Console.Clear();
            // Iterujemy przez wszystkie wpisy w kolekcji przekazanej do funkcji. 
            foreach (var item in dishes)
            {
                Console.WriteLine(PrintDish(item));
            }

            if (printSummary)
            {
                Console.WriteLine("\n****************");

                Console.WriteLine(PrintSummary(dishes));

                Console.WriteLine("****************\n");
            }
        }

        static Dish FindDishByName(DbSet<Dish> dbSet)
        {
            Console.Clear();

            Console.Write("Podaj nazwę dania: ");
            string query = Console.ReadLine();

            return dbSet.Where(q => q.DishName.Contains(query)).FirstOrDefault();
        }

        static string PrintDish(Dish dish)
        {
            return $"{dish.DishId} {dish.DishName} - {dish.Price} @ {dish.CreatedBy}";
        }

        static string PrintSummary(ICollection<Dish> dishes)
        {
            StringBuilder outString = new StringBuilder();

            outString.Append($"W bazie istniej aktualnie {dishes.Count()} dań!\n");
            outString.Append($"Srednia cena dania to {dishes.Average(m => m.Price)}, " +
                             $"przedzial cenowy od {dishes.Min(m => m.Price)} " +
                             $"do {dishes.Max(m => m.Price)}");

            return outString.ToString();
        }

        /// <summary>
        /// Ręczne dodanie (wpisując z konsoli) danie do bazy danych.
        /// </summary>
        /// <param name="dbSet">DbSet do którego należy dodać danie</param>
        static void InsertNewManualDish(DbSet<Dish> dbSet)
        {
            var newDish = new Dish();

            Console.Clear();
            Console.WriteLine("*** Dodawanie nowego dania! ***");

            do
            {
                Console.Write("Podaj nazwę dania: ");

                newDish.DishName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(newDish.DishName));

            Console.Write("Podaj cenę dania: ");

            double price;
            if (double.TryParse(Console.ReadLine(), out price) && price > 0)
            {
                newDish.Price = price;
            }

            newDish.CreatedBy = Environment.UserName;

            dbSet.Add(newDish);
        }

        static int Menu()
        {
            Console.Clear();

            Console.WriteLine("\n***\nMenu Główne\n***\n\n");

            Console.WriteLine("1. Wyświetl zawartość bazy danych");
            Console.WriteLine("2. Utwórz wpis");
            Console.WriteLine("3. Znajdź wpis");
            Console.WriteLine("4. Zaktualizuj wpis");
            Console.WriteLine("5. Usuń wpis");

            Console.WriteLine("\n0. Wyjdź");

            Console.Write("\n\nCo chcesz zrobić: ");

            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Nie znane polecenie, spróbuj ponownie!");
                Console.WriteLine("Co chcesz zrobić: ");
            }

            return result;
        }
    }
}
