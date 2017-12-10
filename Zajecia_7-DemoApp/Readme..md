1. Czysty projekt z Template MVC 5, z indywidualnymi użytkownikami
1. Dodanie modelu (pliki: Danie.cs, Zamowienie.cs)
1. Dodanie modelu / DataSet do dbContext w IdentityModels.cs
1. Enable-Migrations
1. Seed, dodanie danych testowych (plik: Configuration.cs)
	1. Utworzenie użytkownika testowego
	2. Utworzenie administratora testowego
	2. Utworzenie grupy foodAdmin i users
	3. Przypisanie usera testowego do grupy users, a administratora testowego do grupy foodAdmin
1. Add-Migration "Initial"
7. Update-Database
8. Nowy generowany kontroler (Scaffolded Controller) dla Dań i widoków
9. Dostęp dla grupy foodAdmin dla edycji Dań
10. Dostęp foodAdmin dla kontrolera Zamówień
11. Nowy kontroler z widokiem odpowiednim - tylko do składania zamówienia.
11. Dostęp dla grupy users dla kontrolera Złóż zamówienie
8. Publish Azure
