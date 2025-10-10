using Grocery.Core.Models;

namespace TestCore
{
    public class TestProductCategories
    {
        [SetUp]
        public void Setup()
        {
        }

        // Happy flow - Test dat Category correct wordt aangemaakt
        [Test]
        public void TestCategoryConstructor()
        {
            // Arrange
            int id = 1;
            string name = "Fruit";

            // Act
            Category category = new Category { Id = id, Name = name };

            // Assert
            Assert.AreEqual(id, category.Id);
            Assert.AreEqual(name, category.Name);
        }

        [TestCase(1, "Fruit")]
        [TestCase(2, "Groenten")]
        [TestCase(3, "Zuivel")]
        [TestCase(4, "Vlees")]
        public void TestCategoryConstructor(int id, string name)
        {
            // Arrange & Act
            Category category = new Category { Id = id, Name = name };

            // Assert
            Assert.AreEqual(id, category.Id);
            Assert.AreEqual(name, category.Name);
            Assert.IsFalse(string.IsNullOrWhiteSpace(category.Name));
        }

        // Happy flow - Test dat ProductCategory correct wordt aangemaakt
        [Test]
        public void TestProductCategoryConstructor()
        {
            // Arrange
            int id = 1;
            int productId = 10;
            int categoryId = 5;

            // Act
            ProductCategory productCategory = new ProductCategory
            {
                Id = id,
                ProductId = productId,
                CategoryId = categoryId
            };

            // Assert
            Assert.AreEqual(id, productCategory.Id);
            Assert.AreEqual(productId, productCategory.ProductId);
            Assert.AreEqual(categoryId, productCategory.CategoryId);
        }

        [TestCase(1, 10, 5)]
        [TestCase(2, 20, 3)]
        [TestCase(3, 15, 1)]
        [TestCase(4, 25, 7)]
        public void TestProductCategoryConstructor(int id, int productId, int categoryId)
        {
            // Arrange & Act
            ProductCategory productCategory = new ProductCategory
            {
                Id = id,
                ProductId = productId,
                CategoryId = categoryId
            };

            // Assert
            Assert.AreEqual(id, productCategory.Id);
            Assert.AreEqual(productId, productCategory.ProductId);
            Assert.AreEqual(categoryId, productCategory.CategoryId);
            Assert.IsTrue(productCategory.ProductId > 0);
            Assert.IsTrue(productCategory.CategoryId > 0);
        }

        // Happy flow - Test dat Category naam kan worden gewijzigd
        [Test]
        public void TestCategoryNameCanBeUpdated()
        {
            // Arrange
            Category category = new Category { Id = 1, Name = "Fruit" };
            string newName = "Tropisch Fruit";

            // Act
            category.Name = newName;

            // Assert
            Assert.AreEqual(newName, category.Name);
        }

        [TestCase("Fruit", "Tropisch Fruit")]
        [TestCase("Groenten", "Verse Groenten")]
        [TestCase("Zuivel", "Melkproducten")]
        public void TestCategoryNameCanBeUpdated(string oldName, string newName)
        {
            // Arrange
            Category category = new Category { Id = 1, Name = oldName };

            // Act
            category.Name = newName;

            // Assert
            Assert.AreEqual(newName, category.Name);
            Assert.AreNotEqual(oldName, category.Name);
        }

        // Unhappy flow - Test lege categorienaam
        [Test]
        public void TestCategoryWithEmptyName()
        {
            // Arrange
            int id = 1;
            string name = "";

            // Act
            Category category = new Category { Id = id, Name = name };

            // Assert
            Assert.AreEqual(id, category.Id);
            Assert.AreEqual(name, category.Name);
            Assert.IsTrue(string.IsNullOrWhiteSpace(category.Name));
        }

        // Unhappy flow - Test ProductCategory met ongeldige IDs
        [TestCase(0, 0, 0)]
        [TestCase(-1, -1, -1)]
        public void TestProductCategoryWithInvalidIds(int id, int productId, int categoryId)
        {
            // Arrange & Act
            ProductCategory productCategory = new ProductCategory
            {
                Id = id,
                ProductId = productId,
                CategoryId = categoryId
            };

            // Assert
            Assert.AreEqual(id, productCategory.Id);
            Assert.AreEqual(productId, productCategory.ProductId);
            Assert.AreEqual(categoryId, productCategory.CategoryId);
        }
    }
}