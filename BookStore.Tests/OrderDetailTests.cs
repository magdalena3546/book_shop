using NUnit.Framework;
using BookStore.Models;

namespace BookStore.Tests
{
    [TestFixture]
    public class OrderDetailTests
    {
        [Test]
        public void CreateOrderDetail_WithValidData_ShouldHaveCorrectValues()
        {
            var orderDetail = new OrderDetail
            {
                Id = 1,
                OrderId = 2,
                BookId = 3,
                Quantity = 5,
                UnitPrice = 19.99m
            };

            Assert.That(orderDetail.Id, Is.EqualTo(1));
            Assert.That(orderDetail.OrderId, Is.EqualTo(2));
            Assert.That(orderDetail.BookId, Is.EqualTo(3));
            Assert.That(orderDetail.Quantity, Is.EqualTo(5));
            Assert.That(orderDetail.UnitPrice, Is.EqualTo(19.99m));
        }

        [Test]
        public void OrderDetail_DefaultValues_ShouldBeZero()
        {
            var orderDetail = new OrderDetail();

            Assert.That(orderDetail.Id, Is.EqualTo(0));
            Assert.That(orderDetail.OrderId, Is.EqualTo(0));
            Assert.That(orderDetail.BookId, Is.EqualTo(0));
            Assert.That(orderDetail.Quantity, Is.EqualTo(0));
            Assert.That(orderDetail.UnitPrice, Is.EqualTo(0m));
        }
    }
}
