using NUnit.Framework;
using BookStore.Models;

namespace BookStore.Tests
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void CreateOrder_WithValidData_ShouldHaveCorrectValues()
        {
            var order = new Order
            {
                Id = 1,
                CustomerName = "John Doe",
                CustomerEmail = "john@example.com"
            };

            Assert.That(order.Id, Is.EqualTo(1));
            Assert.That(order.CustomerName, Is.EqualTo("John Doe"));
            Assert.That(order.CustomerEmail, Is.EqualTo("john@example.com"));
        }

        [Test]
        public void Order_DefaultValues_ShouldBeZeroOrNull()
        {
            var order = new Order();

            Assert.That(order.Id, Is.EqualTo(0));
            Assert.That(order.CustomerName, Is.Null);
            Assert.That(order.CustomerEmail, Is.Null);
        }
    }
}
