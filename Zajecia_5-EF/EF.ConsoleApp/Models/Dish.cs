using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.ConsoleApp.Models
{
    /// <summary>
    /// Klasa reprezentująca jedno danie w systemie.
    /// </summary>
    class Dish
    {
        /// <summary>
        /// Poprzez konwencję w EF wszystkie pola ID lub [NazwaKlasy]Id traktowane są jako Primary Key danej tabeli.
        /// 
        /// Więcej informacji o konwencjach w EF:
        /// Entity Framework Code First Conventions - https://msdn.microsoft.com/en-us/library/jj679962(v=vs.113).aspx
        /// Entity Framework Custom Code First Conventions (EF6 onwards) - https://msdn.microsoft.com/en-us/library/jj819164(v=vs.113).aspx
        /// </summary>
        public int DishId { get; set; }

        /// <summary>
        /// Nazwa dania, wymuszamy by nazwa została podana poprzez annotację "Required". Jeśli nie podamy tej annotacji może się okazać,
        /// że nazwa będzie pusta, ponieważ String jest obiektem (typem referencyjnym) przez co jego referencja nie będzie nullem ale jego,
        /// zawartość już może być pusta.
        /// Ograniczymy długość tekstu do maksimum 255 znaków oraz minimum 3.
        /// 
        /// Więcej o nvarchar: https://msdn.microsoft.com/pl-pl/library/ms186939(v=sql.110).aspx
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public String DishName { get; set; }

        /// <summary>
        /// Cena dania, dodaliśmy adnotację "Range" by zawężyć zakres ceny (walidacja).
        /// Ponad to zastosowaliśmy adnotację "DataType" ustawioną na Currency - zmienia to sposób formatowania / reprezentacji danych.
        /// 
        /// Więcej o adnotacji Range: 
        /// Więcej o adnotacji DataType: https://msdn.microsoft.com/pl-pl/library/system.componentmodel.dataannotations.datatype(v=vs.110).aspx
        /// </summary>
        [Range(0,double.MaxValue)]
        [DataType(DataType.Currency)]
        public double? Price { get; set; }

        /// <summary>
        /// Imię Nazwisko osoby, która dodała to danie.
        /// </summary>
        [Required]
        [StringLength(255)]
        public String CreatedBy { get; set; }
    }
}
