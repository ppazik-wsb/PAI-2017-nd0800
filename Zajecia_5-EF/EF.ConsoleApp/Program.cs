using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EF.ConsoleApp.DataContexts;
using EF.ConsoleApp.Models;

namespace EF.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
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
                do
                {
                    PrintAllDishes(dbCtx.Dishes.ToList());

                    Console.Write("Czy dodać nowe danie? (y/n) [Def n]: ");
                    if (Console.ReadLine()?.ToUpper() == "Y")
                    {
                        InsertNewManualDish(dbCtx.Dishes);
                        dbCtx.SaveChanges();
                    }

                    Console.Write("Czy powtórzyć? (y/n) [Def n]: ");
                } while (Console.ReadLine()?.ToUpper() == "Y");
            }

            Console.Write("Wciśnij <ENTER> by zakończyć program! ");
            Console.ReadLine();
        }


        /// <summary>
        /// Metoda do wypisania wszystkich potraw w kolekcji
        /// </summary>
        /// <param name="dishes">Kolekcja z potrawami</param>
        /// <param name="printSummary">Flaga czy wyświetlić podsumowanie kolekcji</param>
        static void PrintAllDishes(ICollection<Dish> dishes, bool printSummary = true)
        {
            // Iterujemy przez wszystkie wpisy w kolekcji przekazanej do funkcji. 
            foreach (var item in dishes)
            {
                Console.WriteLine($"{item.DishId} {item.DishName} - {item.Price} @ {item.CreatedBy}");
            }

            if (printSummary)
            {
                Console.WriteLine("****************");
                Console.WriteLine($"W bazie istniej aktualnie {dishes.Count()} dań!");
                Console.WriteLine($"\tSrednia cena dania to {dishes.Average(m => m.Price)}, " +
                                  $"przedzial cenowy od {dishes.Min(m => m.Price)} " +
                                  $"do {dishes.Max(m => m.Price)}");
                Console.WriteLine("****************");
            }
        }

        /// <summary>
        /// Ręczne dodanie (wpisując z konsoli) danie do bazy danych.
        /// </summary>
        /// <param name="dbSet">DbSet do którego należy dodać danie</param>
        static void InsertNewManualDish(DbSet<Dish> dbSet)
        {
            var newDish = new Dish();

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
    }
}
