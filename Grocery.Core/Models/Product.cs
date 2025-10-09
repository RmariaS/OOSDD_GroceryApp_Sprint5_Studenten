using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    /// <summary>
    /// Representeert een product in de winkel.
    /// Bevat voorraad, prijs en THT-datum (ShelfLife).
    /// </summary>
    public partial class Product : Model
    {
        // Voorraad: observable via CommunityToolkit.Mvvm
        [ObservableProperty]
        private int stock;

        // Prijs: observable, gebruikt voor UC14
        [ObservableProperty]
        private decimal _price;

        // THT-datum (UC15): niet observable, maar wel bindbaar in XAML
        public DateOnly ShelfLife { get; set; }

        // 
        // Constructors (backwards compatible)
        // 

        /// <summary>
        /// Constructor voor compatibiliteit met bestaande code (bijv. fallback in GroceryListItem).
        /// Gebruikt standaardprijs 0 en geen THT-datum.
        /// </summary>
        public Product(int id, string name, int stock)
            : this(id, name, stock, 0) // roept 4-arg constructor aan
        {
        }

        /// <summary>
        /// Constructor zonder THT-datum.
        /// </summary>
        public Product(int id, string name, int stock, decimal price)
            : this(id, name, stock, price, default) // roept volledige constructor aan
        {
        }

        /// <summary>
        /// Volledige constructor met alle velden (gebruikt in ProductRepository).
        /// </summary>
        public Product(int id, string name, int stock, decimal price, DateOnly shelfLife)
            : base(id, name)
        {
            Stock = stock;
            Price = price;
            ShelfLife = shelfLife;
        }

        // 
        // Overrides
        // 

        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad, €{Price:F2}, THT: {ShelfLife:yyyy-MM-dd}";
        }
    }
}