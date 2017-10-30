using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.ConsoleApp.DataContexts;

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
                // Iterujemy przez wszystkie wpisy w zbiorze (DataSet) dotyczącym Dań. 
                foreach (var item in dbCtx.Dishes)
                {
                    Console.WriteLine($@"{item.DishId} {item.DishName} - {item.Price} \@ {item.CreatedBy}");
                }

                Console.WriteLine($"W bazie istniej aktualnie {dbCtx.Dishes.Count()} dań!");
                Console.WriteLine($"\tSrednia cena dania to {dbCtx.Dishes.Average( m => m.Price )}, " +
                                  $"przedzial cenowy od {dbCtx.Dishes.Min( m => m.Price )} " +
                                  $"do {dbCtx.Dishes.Max( m => m.Price )}");
            }

            Console.ReadLine();
        }
    }
}
