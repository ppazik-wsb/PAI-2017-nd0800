# Zajêcia 5. - Entity Framework

## Aplikacja konsolowa + EF

1. Utworzenie pustego projektu aplikacji konsolowej o nazwie ```EF.ConsoleApp```
2. Instalacja Entity Framework przez NuGet przez [```Package Manager Console```](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console) (konsola PM) poleceniem ```Install-Package EntityFramework -ProjectName EF.ConsoleApp```
3. Definicja connection string do bazy danych (w tym przypadku ```mssqllocaldb```) w pliku konfiguracyjnym aplikacji ```App.config```
4. Dodanie nowego modelu o nazwie ```Dish``` (Danie).
5. Stworzenie ```DbContext``` (naszej furtki do bazy danych), która ³¹czy siê z baz¹ poprzez connection string zdefiniowany powy¿ej w pliku ```App.config```. Nowy DbContext udostêpnia Nam dostêp do obiektów ```Dish``` poprzez ```DbSet<Dish> Dishes```.
6. W³¹czenie mechanizmu migracji poprzez wywo³anie polecenia ```Enable-Migrations``` w konsoli PM.
7. Dodanie pierwszej migracji ```Add-Migration "Initial Create"``` w konsoli PM. Powstanie nowy folder w projekcie ```Migrations``` w kórym powstawaæ bêd¹ kolejne migracje.
8. Aktualizacja bazy danych ```Update-Database -Verbose``` w konsoli PM (parametr ```-Verbose``` powoduje wyœwietlenie zapytaæ SQL, które wykonywane s¹ na bazie danych.
9. W tej chwili mo¿na ju¿ dodaæ nowo utworzon¹ bazê do narzêdzia ```Server Explorer```:
   1. Prawym przyciskiem na ```Data connections```, wybierz ```Add Connection```.
   2. W ```Server name``` wpisaæ ```(localdb)\mssqllocaldb```
   3. Nastêpnie poni¿ej w ```Select or enter database name``` nale¿y wybraæ Nasz¹ bazê danych ```EFConsoleApp```
   4. W bazie danych powinna zostaæ ju¿ stworzona tabela dla DataSet-u z ostatio stworzonej migracji. Zawartoœæ migracji opisana jest w postaci kodu Ÿród³owego w pliku ```Migrations/201710291448013_Initial Create.cs```
10. Seed - posianie wstêpnych danych i/lub danych testowych.
11. Pobieranie dany poprzez ```DataSet<Dish>``` wewn¹trz utworzonego ```DbContext```. Przyk³ad w definicji cia³a programu.
```C#
using (var dbCtx = new DefaultAppDbConnection())
	{
		foreach (var item in dbCtx.Dishes)
		{
			Console.WriteLine($@"{item.DishId} {item.DishName} - {item.Price} \@ {item.CreatedBy}");
		}
	}
```