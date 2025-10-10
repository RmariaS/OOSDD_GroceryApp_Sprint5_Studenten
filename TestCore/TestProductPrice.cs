using Grocery.Core.Models;

using Grocery.Core.Models;

namespace TestCore
{
    public class TestProductPrice
    {
        [SetUp]
        public void Setup()
        {
        }

        // Happy flow - Test dat Product correct wordt aangemaakt met prijs
        [Test]
        public void TestProductConstructorWithPrice()
        {
            // Arrange
            int id = 1;
            string name = "Melk";
            int stock = 300;
            decimal price = 1.25m;
            DateOnly shelfLife = new DateOnly(2025, 9, 25);

            // Act
            Product product = new Product(id, name, stock, price, shelfLife);

            // Assert
            Assert.AreEqual(id, product.Id);
            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(stock, product.Stock);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(shelfLife, product.ShelfLife);
        }

        [TestCase(1, "Melk", 300, 1.25)]
        [TestCase(2, "Kaas", 100, 3.50)]
        [TestCase(3, "Brood", 400, 2.10)]
        [TestCase(4, "Cornflakes", 0, 4.99)]
        public void TestProductConstructorWithPrice(int id, string name, int stock, decimal price)
        {
            // Arrange
            DateOnly shelfLife = new DateOnly(2025, 9, 25);

            // Act
            Product product = new Product(id, name, stock, price, shelfLife);

            // Assert
            Assert.AreEqual(id, product.Id);
            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(stock, product.Stock);
            Assert.AreEqual(price, product.Price);
            Assert.IsTrue(product.Price > 0 || product.Price == 0);
        }

        // Happy flow - Test dat prijs correct wordt gewijzigd
        [Test]
        public void TestProductPriceCanBeUpdated()
        {
            // Arrange
            Product product = new Product(1, "Yoghurt", 20, 0.89m, new DateOnly(2025, 10, 10));
            decimal newPrice = 1.19m;

            // Act
            product.Price = newPrice;

            // Assert
            Assert.AreEqual(newPrice, product.Price);
        }

        [TestCase(1.25, 1.50)]
        [TestCase(3.50, 2.99)]
        [TestCase(2.10, 2.50)]
        [TestCase(4.99, 5.49)]
        public void TestProductPriceCanBeUpdated(decimal oldPrice, decimal newPrice)
        {
            // Arrange
            Product product = new Product(1, "TestProduct", 10, oldPrice, new DateOnly(2025, 9, 25));

            // Act
            product.Price = newPrice;

            // Assert
            Assert.AreEqual(newPrice, product.Price);
            Assert.AreNotEqual(oldPrice, product.Price);
        }
    }
}