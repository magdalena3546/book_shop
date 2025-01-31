using NUnit.Framework;
using BookStore.Models;

namespace BookStore.Tests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void CreateBook_WithValidData_ShouldHaveCorrectValues()
        {
            var book = new Book
            {
                Id = 1,
                Title = "Test Title",
                Author = "Test Author",
                Genre = "Fiction",
                Price = 29.99m,
                Stock = 10,
                CategoryId = 1
            };

            Assert.That(book.Id, Is.EqualTo(1));
            Assert.That(book.Title, Is.EqualTo("Test Title"));
            Assert.That(book.Author, Is.EqualTo("Test Author"));
            Assert.That(book.Genre, Is.EqualTo("Fiction"));
            Assert.That(book.Price, Is.EqualTo(29.99m));
            Assert.That(book.Stock, Is.EqualTo(10));
            Assert.That(book.CategoryId, Is.EqualTo(1));
        }

        [Test]
        public void Book_DefaultValues_ShouldBeZeroOrNull()
        {
            var book = new Book();

            Assert.That(book.Id, Is.EqualTo(0));
            Assert.That(book.Title, Is.Null);
            Assert.That(book.Author, Is.Null);
            Assert.That(book.Genre, Is.Null);
            Assert.That(book.Price, Is.EqualTo(0m));
            Assert.That(book.Stock, Is.EqualTo(0));
            Assert.That(book.CategoryId, Is.EqualTo(0));
        }

        [Test]
        public void SetBookTitle_ShouldUpdateTitle()
        {
            var book = new Book { Title = "Old Title" };

            book.Title = "New Title";

            Assert.That(book.Title, Is.EqualTo("New Title"));
        }
    }
}
