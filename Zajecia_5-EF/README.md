# Zajêcia 5. - Entity Framework

## Aplikacja konsolowa + EF

1. Utworzenie pustego projektu aplikacji konsolowej o nazwie ```EF.ConsoleApp```
2. Instalacja Entity Framework przez NuGet przez [```Package Manager Console```](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console) poleceniem ```Install-Package EntityFramework -ProjectName EF.ConsoleApp```
3. Definicja connection string do bazy danych (w tym przypadku ```mssqllocaldb```) w pliku konfiguracyjnym aplikacji ```App.config```
4. Dodanie nowego modelu o nazwie ```Dish``` (Danie).