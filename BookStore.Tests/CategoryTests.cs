using NUnit.Framework;
using BookStore.Models;

namespace BookStore.Tests
{
    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void CreateCategory_WithValidData_ShouldHaveCorrectValues()
        {
            var category = new Category { Id = 1, Name = "Fiction" };

            Assert.That(category.Id, Is.EqualTo(1));
            Assert.That(category.Name, Is.EqualTo("Fiction"));
        }

        [Test]
        public void Category_DefaultValues_ShouldBeZeroOrNull()
        {
            var category = new Category();

            Assert.That(category.Id, Is.EqualTo(0));
            Assert.That(category.Name, Is.Null);
        }
    }
}
